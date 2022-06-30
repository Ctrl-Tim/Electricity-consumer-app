﻿using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;
using ElectricityConsumerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityConsumerDatabaseImplement.Implements
{
    public class ElectricMeterStorage : IElectricMeterStorage
    {
        public List<ElectricMeterViewModel> GetFullList()
        {
            using var context = new ElectricityConsumerDatabase();
            return context.ElectricMeters
                .Include(rec => rec.TypeElectricMeter)
                .Include(rec => rec.Address)
                .Include(rec => rec.Address.Consumer)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<ElectricMeterViewModel> GetFilteredList(ElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            return context.ElectricMeters
                .Include(rec => rec.TypeElectricMeter)
                .Include(rec => rec.Address)
                .Include(rec => rec.Address.Consumer)
                .Where(rec => (rec.Number == model.Number) || (rec.TypeId == model.TypeId)
                                || (rec.InspectionPeriod == model.InspectionPeriod) || (!model.DateOfCheck.HasValue && !model.FinalInspection.HasValue))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public ElectricMeterViewModel GetElement(ElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            var component = context.ElectricMeters
                .Include(rec => rec.TypeElectricMeter)
                .Include(rec => rec.Address)
                .Include(rec => rec.Address.Consumer)
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Number == model.Number);
            return component != null ? CreateModel(component) : null;
        }

        public void Insert(ElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.ElectricMeters.Add(CreateModel(model, new ElectricMeter()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(ElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.ElectricMeters.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Электросчётчик не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(ElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.ElectricMeters.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.ElectricMeters.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Электросчётчик не найден");
            }
        }

        private static ElectricMeter CreateModel(ElectricMeterBindingModel model, ElectricMeter electricmeter)
        {
            electricmeter.Id = model.AddressId;
            electricmeter.TypeId = model.TypeId;
            electricmeter.Number = Math.Round(model.Number);
            electricmeter.DateOfCheck = model.DateOfCheck;
            electricmeter.InspectionPeriod = model.InspectionPeriod;
            electricmeter.FinalInspection = model.FinalInspection;
            return electricmeter;
        }

        private static ElectricMeterViewModel CreateModel(ElectricMeter electricmeter)
        {
            return new ElectricMeterViewModel
            {
                Id = electricmeter.Id,
                Number = Math.Round(electricmeter.Number),
                TypeId = electricmeter.TypeId,
                TypeName = electricmeter.TypeElectricMeter.Name,
                FullAddress = "ул. " + electricmeter.Address.Street + ", д." + electricmeter.Address.House + ", кв." + electricmeter.Address.Flat,
                ConsumerFIO = electricmeter.Address.Consumer.SurName + " " + electricmeter.Address.Consumer.FirstName + " " + electricmeter.Address.Consumer.Patronymic,
                DateOfCheck = electricmeter.DateOfCheck,
                InspectionPeriod = electricmeter.InspectionPeriod,
                FinalInspection = electricmeter.FinalInspection
            };
        }
    }
}
