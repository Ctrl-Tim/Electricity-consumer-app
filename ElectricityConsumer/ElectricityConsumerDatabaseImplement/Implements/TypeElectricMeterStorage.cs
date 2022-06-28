using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;
using ElectricityConsumerDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityConsumerDatabaseImplement.Implements
{
    public class TypeElectricMeterStorage : ITypeElectricMeterStorage
    {
        public List<TypeElectricMeterViewModel> GetFullList()
        {
            using var context = new ElectricityConsumerDatabase();
            return context.Types
                .Select(CreateModel)
                .ToList();
        }

        public List<TypeElectricMeterViewModel> GetFilteredList(TypeElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            return context.Types
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public TypeElectricMeterViewModel GetElement(TypeElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ElectricityConsumerDatabase();
            var component = context.Types.FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return component != null ? CreateModel(component) : null;
        }

        public void Insert(TypeElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            context.Types.Add(CreateModel(model, new TypeElectricMeter()));
            context.SaveChanges();
        }

        public void Update(TypeElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.Types.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Тип не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(TypeElectricMeterBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            var element = context.Types.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Types.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Тип не найден");
            }
        }

        private static TypeElectricMeter CreateModel(TypeElectricMeterBindingModel model, TypeElectricMeter type)
        {
            type.Name = model.Name;
            return type;
        }

        private static TypeElectricMeterViewModel CreateModel(TypeElectricMeter type)
        {
            return new TypeElectricMeterViewModel
            {
                Id = type.Id,
                Name = type.Name
            };
        }
    }
}
