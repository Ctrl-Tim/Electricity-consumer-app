using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.StoragesContracts
{
    public interface ICounterReadingsStorage
    {
		List<CounterReadingsViewModel> GetFullList();
		List<CounterReadingsViewModel> GetFilteredList(CounterReadingsBindingModel model);
		CounterReadingsViewModel GetElement(CounterReadingsBindingModel model);

		void Insert(CounterReadingsBindingModel model);
		void Update(CounterReadingsBindingModel model);
		void Delete(CounterReadingsBindingModel model);
	}
}
