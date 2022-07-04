using System;
using System.ComponentModel;

namespace ElectricityConsumerContracts.ViewModels
{
    /// <summary>
    /// Показания счётчика
    /// </summary>
    public class CounterReadingsViewModel
    {
        public int Id { get; set; }

        public int ElectricMeterId { get; set; }

        public int ConsumerId { get; set; }

        [DisplayName("Номер счётчика")]
        public decimal Number { get; set; }

        [DisplayName ("Адрес")]
        public string FullAddress { get; set; }

        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [DisplayName("Начало месяца")]
        public float BeginningOfMonth { get; set; }

        [DisplayName("Конец месяца")]
        public float EndOfMonth { get; set; }
    }
}
