using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;
using ElectricityConsumerDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityConsumerDatabaseImplement.Implements
{
    public class ConsumerStorage : IConsumerStorage
    {
		public List<ConsumerViewModel> GetFullList()
        {
            using var context = new ElectricityConsumerDatabase();
            return context.Consumers
                .Select(CreateModel)
                .ToList();
        }

        public List<ConsumerViewModel> GetFilteredList(ConsumerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            return context.Consumers
                .Where(rec => rec.SurName.Contains(model.SurName) && rec.FirstName.Contains(model.FirstName) && rec.Patronymic.Contains(model.Patronymic))
                .Select(CreateModel)
                .ToList();
        }

        public ConsumerViewModel GetElement(ConsumerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            var component = context.Consumers.FirstOrDefault(rec => rec.Id == model.Id || rec.SurName == model.SurName);
            return component != null ? CreateModel(component) : null;
        }

        public void Insert(ConsumerBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            context.Consumers.Add(CreateModel(model, new Consumer()));
            context.SaveChanges();
        }

        public void Update(ConsumerBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.Consumers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Потребитель не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(ConsumerBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.Consumers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Consumers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Потребитель не найден");
            }
        }

        private static Consumer CreateModel(ConsumerBindingModel model, Consumer consumer)
        {
            consumer.SurName = model.SurName;
            consumer.FirstName = model.FirstName;
            consumer.Patronymic = model.Patronymic;
            return consumer;
        }

        private static ConsumerViewModel CreateModel(Consumer consumer)
        {
            return new ConsumerViewModel
            {
                Id = consumer.Id,
                SurName = consumer.SurName,
                FirstName = consumer.FirstName,
                Patronymic = consumer.Patronymic,
                FIO = consumer.SurName + " " + consumer.FirstName + " " + consumer.Patronymic
            };
        }
    }
}
