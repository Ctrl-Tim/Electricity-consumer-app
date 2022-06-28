using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;
using ElectricityConsumerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityConsumerDatabaseImplement.Implements
{
    public class CounterReadingsStorage : ICounterReadingsStorage
    {
		public List<CounterReadingsViewModel> GetFullList()
        {
            using var context = new ElectricityConsumerDatabase();
            return context.CounterReadings
                .Include(rec => rec.ElectricMeter)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

		public List<CounterReadingsViewModel> GetFilteredList(CounterReadingsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            return context.CounterReadings
                .Include(rec => rec.ElectricMeter)
                .Where(rec =>  (rec.ElectricMeterId == model.ElectricMeterId) || (rec.Date == model.Date)
                                || (rec.BeginningOfMonth == model.BeginningOfMonth) || (rec.EndOfMonth == model.EndOfMonth))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

		public CounterReadingsViewModel GetElement(CounterReadingsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            var component = context.CounterReadings
                .Include(rec => rec.ElectricMeter)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return component != null ? CreateModel(component) : null;
        }

		public void Insert(CounterReadingsBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.CounterReadings.Add(CreateModel(model, new CounterReadings()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

		public void Update(CounterReadingsBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.CounterReadings.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Показание не найдено");
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

		public void Delete(CounterReadingsBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.CounterReadings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.CounterReadings.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Показание не найдено");
            }
        }

        private CounterReadings CreateModel(CounterReadingsBindingModel model, CounterReadings counter)
        {
            counter.ElectricMeterId = model.ElectricMeterId;
            counter.Date = model.Date;
            counter.BeginningOfMonth = model.BeginningOfMonth;
            counter.EndOfMonth = model.EndOfMonth;

            return counter;
        }

        public CounterReadingsViewModel CreateModel(CounterReadings counter)
        {
            return new CounterReadingsViewModel
            {
                Id = counter.Id,
                ElectricMeterId = counter.ElectricMeterId,
                Number = counter.ElectricMeter.Number,
                FullAddress = counter.ElectricMeter.Address.Street + " " + counter.ElectricMeter.Address.House + " " + counter.ElectricMeter.Address.Flat,
                Date = counter.Date,
                BeginningOfMonth = counter.BeginningOfMonth,
                EndOfMonth = counter.EndOfMonth
            };
        }
    }
}
