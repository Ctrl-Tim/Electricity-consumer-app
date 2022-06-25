using System;
using System.Collections.Generic;
using ElectricityConsumerContracts.BusinessLogicsContracts;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.StoragesContracts;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerBusinessLogic.BusinessLogics
{
    public class CounterReadingsLogic : ICounterReadingsLogic
    {
        private readonly ICounterReadingsStorage _readingsStorage;

        public CounterReadingsLogic(ICounterReadingsStorage readingsStorage)
        {
            _readingsStorage = readingsStorage;
        }

        public List<CounterReadingsViewModel> Read(CounterReadingsBindingModel model)
        {
            if (model == null)
            {
                return _readingsStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CounterReadingsViewModel> { _readingsStorage.GetElement(model) };
            }

            return _readingsStorage.GetFilteredList(model);
        }

        public void CreateReading(CreateReadingBindingModel model)
        {
            _readingsStorage.Insert(new CounterReadingsBindingModel
            {
                ElectricMeterId = model.ElectricMeterId,
                Date = DateTime.Now,
                BeginningOfMonth = model.BeginningOfMonth,
                EndOfMonth = model.EndOfMonth
            });
        }
    }
}
