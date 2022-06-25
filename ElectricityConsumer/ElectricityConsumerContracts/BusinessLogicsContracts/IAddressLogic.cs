using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.BusinessLogicsContracts
{
    public interface IAddressLogic
    {
        List<AddressViewModel> Read(AddressBindingModel model);

        void CreateOrUpdate(AddressBindingModel model);

        void Delete(AddressBindingModel model);
    }
}
