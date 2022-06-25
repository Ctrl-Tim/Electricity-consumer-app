using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class AddressLogic : IAddressLogic
    {
        private readonly IAddressStorage _addressStorage;

        public AddressLogic(IAddressStorage addressStorage)
        {
            _addressStorage = addressStorage;
        }

        public List<AddressViewModel> Read(AddressBindingModel model)
        {
            if (model == null)
            {
                return _addressStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AddressViewModel> { _addressStorage.GetElement(model) };
            }

            return _addressStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AddressBindingModel model)
        {
            var element = _addressStorage.GetElement(new AddressBindingModel
            {
                Street = model.Street,
                House = model.House,
                Flat = model.Flat
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой адрес");
            }
            if (model.Id.HasValue)
            {
                _addressStorage.Update(model);
            }
            else
            {
                _addressStorage.Insert(model);
            }
        }

        public void Delete(AddressBindingModel model)
        {
            var element = _addressStorage.GetElement(new AddressBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Адрес не найден!");
            }
            _addressStorage.Delete(model);
        }
    }
}
