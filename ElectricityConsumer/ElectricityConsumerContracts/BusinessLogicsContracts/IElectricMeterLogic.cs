using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.BusinessLogicsContracts
{
    public interface IElectricMeterLogic
    {
        List<ElectricMeterViewModel> Read(ElectricMeterBindingModel model);

        void CreateOrUpdate(ElectricMeterBindingModel model);

        void Delete(ElectricMeterBindingModel model);

        void CheckInspection(ElectricMeterBindingModel model);

        void CreateReading(ElectricMeterBindingModel model);
    }
}
