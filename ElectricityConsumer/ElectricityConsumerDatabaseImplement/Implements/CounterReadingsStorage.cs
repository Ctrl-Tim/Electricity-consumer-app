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
            return context.CounterReadingss
                .Include(rec => rec.ElectricMeter)
                .Include(rec => rec.ElectricMeter.Address)
                .Include(rec => rec.ElectricMeter.Address.Consumer)
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
            return context.CounterReadingss
                .Include(rec => rec.ElectricMeter)
                .Include(rec => rec.ElectricMeter.Address)
                .Include(rec => rec.ElectricMeter.Address.Consumer)
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
            var component = context.CounterReadingss
                .Include(rec => rec.ElectricMeter)
                .Include(rec => rec.ElectricMeter.Address)
                .Include(rec => rec.ElectricMeter.Address.Consumer)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return component != null ? CreateModel(component) : null;
        }

		public void Insert(CounterReadingsBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.CounterReadingss.Add(CreateModel(model, new CounterReadings()));
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
                var element = context.CounterReadingss.FirstOrDefault(rec => rec.Id == model.Id);
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
            var element = context.CounterReadingss.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.CounterReadingss.Remove(element);
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
                ConsumerId = counter.ElectricMeter.Address.ConsumerId,
                Number = Math.Round(counter.ElectricMeter.Number),
                FullAddress = "ул." + counter.ElectricMeter.Address.Street + ", дом." + counter.ElectricMeter.Address.House + ", кв." + counter.ElectricMeter.Address.Flat,
                Date = counter.Date,
                BeginningOfMonth = counter.BeginningOfMonth,
                EndOfMonth = counter.EndOfMonth
            };
        }
    }
}
