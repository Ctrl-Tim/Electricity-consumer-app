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
    public class AddressStorage : IAddressStorage
    {
        public List<AddressViewModel> GetFullList()
        {
            using var context = new ElectricityConsumerDatabase();

            return context.Addresses
                .Include(rec => rec.Consumer)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<AddressViewModel> GetFilteredList(AddressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ElectricityConsumerDatabase();
            return context.Addresses
                .Include(rec => rec.Consumer)
                .Where(rec => rec.Street.Contains(model.Street) && rec.House == model.House && rec.Flat == model.Flat)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public AddressViewModel GetElement(AddressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new ElectricityConsumerDatabase();
            var component = context.Addresses
                .Include(rec => rec.Consumer)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return component != null ? CreateModel(component) : null;
        }

        public void Insert(AddressBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Addresses.Add(CreateModel(model, new Address()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(AddressBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var element = context.Addresses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Адрес не найден");
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

        public void Delete(AddressBindingModel model)
        {
            using var context = new ElectricityConsumerDatabase();
            Address element = context.Addresses.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Addresses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Адрес не найден");
            }
        }

        private static Address CreateModel(AddressBindingModel model, Address address)
        {
            address.Street = model.Street;
            address.House = model.House;
            address.Flat = model.Flat;
            address.ConsumerId = (int)model.ConsumerId;
            address.ElectricMeterId = (int)model.ElectricMeterId;

            return address;
        }

        private static AddressViewModel CreateModel(Address address)
        {
            return new AddressViewModel
            {
                Id = address.Id,
                ConsumerId = (int)address.ConsumerId,
                ConsumerFIO = address.Consumer.SurName + " " + address.Consumer.FirstName + " " + address.Consumer.Patronymic,
                ElectricMeterId = (int)address.ElectricMeterId,
                Street = address.Street,
                House = address.House,
                Flat = address.Flat
            };
        }
    }
}
