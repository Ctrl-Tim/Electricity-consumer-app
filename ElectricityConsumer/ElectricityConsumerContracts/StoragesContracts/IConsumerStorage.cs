using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.StoragesContracts
{
    public interface IConsumerStorage
    {
		List<ConsumerViewModel> GetFullList();
		List<ConsumerViewModel> GetFilteredList(ConsumerBindingModel model);
		ConsumerViewModel GetElement(ConsumerBindingModel model);
		void Insert(ConsumerBindingModel model);
		void Update(ConsumerBindingModel model);
		void Delete(ConsumerBindingModel model);
	}
}
