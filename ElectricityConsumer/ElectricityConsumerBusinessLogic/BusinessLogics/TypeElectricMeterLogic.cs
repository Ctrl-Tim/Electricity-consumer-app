using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class TypeElectricMeterLogic : ITypeElectricMeterLogic
    {
        private readonly ITypeElectricMeterStorage _typeStorage;

        public TypeElectricMeterLogic(ITypeElectricMeterStorage typeStorage)
        {
            _typeStorage = typeStorage;
        }

        public List<TypeElectricMeterViewModel> Read(TypeElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return _typeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TypeElectricMeterViewModel> { _typeStorage.GetElement(model) };
            }

            return _typeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TypeElectricMeterBindingModel model)
        {
            var element = _typeStorage.GetElement(new TypeElectricMeterBindingModel
            {
                Name = model.Name
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть тип с таким названием");
            }
            if (model.Id.HasValue)
            {
                _typeStorage.Update(model);
            }
            else
            {
                _typeStorage.Insert(model);
            }
        }

        public void Delete(TypeElectricMeterBindingModel model)
        {
            var element = _typeStorage.GetElement(new TypeElectricMeterBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Тип электросчётчика не найден!");
            }
            _typeStorage.Delete(model);
        }
    }
}
