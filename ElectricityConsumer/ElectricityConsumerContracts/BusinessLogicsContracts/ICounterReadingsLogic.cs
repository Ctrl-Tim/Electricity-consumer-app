﻿using System.Collections.Generic;
using ElectricityConsumerContracts.BindingModels;
using ElectricityConsumerContracts.ViewModels;

namespace ElectricityConsumerContracts.BusinessLogicsContracts
{
    public interface ICounterReadingsLogic
    {
        List<CounterReadingsViewModel> Read(CounterReadingsBindingModel model);

        void CreateReading(CounterReadingsBindingModel model);

        //List<CounterReadingsViewModel> SaveReadings(CounterReadingsBindingModel model);
    }
}
