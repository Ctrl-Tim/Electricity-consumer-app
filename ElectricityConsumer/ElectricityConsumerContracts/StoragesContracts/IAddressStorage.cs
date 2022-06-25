using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.StoragesContracts
{
    public interface IAddressStorage
    {
		List<AddressViewModel> GetFullList();
		List<AddressViewModel> GetFilteredList(AddressBindingModel model);
		AddressViewModel GetElement(AddressBindingModel model);
		void Insert(AddressBindingModel model);
		void Update(AddressBindingModel model);
		void Delete(AddressBindingModel model);
	}
}
