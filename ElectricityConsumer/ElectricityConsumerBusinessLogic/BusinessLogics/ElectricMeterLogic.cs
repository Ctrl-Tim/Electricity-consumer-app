using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class ElectricMeterLogic : IElectricMeterLogic
    {
        private readonly IElectricMeterStorage _electricmeterStorage;

        public ElectricMeterLogic(IElectricMeterStorage electricmeterStorage)
        {
            _electricmeterStorage = electricmeterStorage;
        }

        public List<ElectricMeterViewModel> Read(ElectricMeterBindingModel model)
        {
            if (model == null)
            {
                return _electricmeterStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ElectricMeterViewModel> { _electricmeterStorage.GetElement(model) };
            }

            return _electricmeterStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ElectricMeterBindingModel model)
        {
            var element = _electricmeterStorage.GetElement(new ElectricMeterBindingModel
            {
                Number = model.Number
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть электросчётчик с таким номером");
            }
            if (model.Id.HasValue)
            {
                _electricmeterStorage.Update(model);
            }
            else
            {
                _electricmeterStorage.Insert(model);
            }
        }

        public void Delete(ElectricMeterBindingModel model)
        {
            var element = _electricmeterStorage.GetElement(new ElectricMeterBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Электросчётчика не найден!");
            }
            _electricmeterStorage.Delete(model);
        }
    }
}
