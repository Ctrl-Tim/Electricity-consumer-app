using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.BusinessLogicsContracts
{
    public interface IConsumerLogic
    {
        List<ConsumerViewModel> Read(ConsumerBindingModel model);

        void CreateOrUpdate(ConsumerBindingModel model);

        void Delete(ConsumerBindingModel model);
    }
}
