using System;

namespace ElectricityConsumerContracts.BindingModels
{
    /// <summary>
    /// Показания счётчика
    /// </summary>
    public class CounterReadingsBindingModel
    {
        public int? Id { get; set; }

        public int ElectricMeterId { get; set; }

        public DateTime Date { get; set; }

        public float BeginningOfMonth { get; set; }

        public float EndOfMonth { get; set; }
    }
}
