using System;

namespace ElectricityConsumerContracts.BindingModels
{
    /// <summary>
    /// Электросчётчик
    /// </summary>
    public class ElectricMeterBindingModel
    {
        public int? Id { get; set; }

        public int TypeId { get; set; }

        public decimal Number { get; set; }

        public DateTime? DateOfCheck { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime? FinalInspection { get; set; }
    }
}
