using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.StoragesContracts
{
    public interface IElectricMeterStorage
    {
		List<ElectricMeterViewModel> GetFullList();
		List<ElectricMeterViewModel> GetFilteredList(ElectricMeterBindingModel model);
		ElectricMeterViewModel GetElement(ElectricMeterBindingModel model);
		void Insert(ElectricMeterBindingModel model);
		void Update(ElectricMeterBindingModel model);
		void Delete(ElectricMeterBindingModel model);
	}
}
