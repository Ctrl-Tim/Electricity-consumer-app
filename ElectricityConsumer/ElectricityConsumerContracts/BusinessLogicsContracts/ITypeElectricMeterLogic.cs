using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.BusinessLogicsContracts
{
    public interface ITypeElectricMeterLogic
    {
        List<TypeElectricMeterViewModel> Read(TypeElectricMeterBindingModel model);

        void CreateOrUpdate(TypeElectricMeterBindingModel model);

        void Delete(TypeElectricMeterBindingModel model);
    }
}
