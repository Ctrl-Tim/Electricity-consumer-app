using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.StoragesContracts
{
    public interface ITypeElectricMeterStorage
    {
		List<TypeElectricMeterViewModel> GetFullList();
		List<TypeElectricMeterViewModel> GetFilteredList(TypeElectricMeterBindingModel model);
		TypeElectricMeterViewModel GetElement(TypeElectricMeterBindingModel model);

		void Insert(TypeElectricMeterBindingModel model);
		void Update(TypeElectricMeterBindingModel model);
		void Delete(TypeElectricMeterBindingModel model);
	}
}
