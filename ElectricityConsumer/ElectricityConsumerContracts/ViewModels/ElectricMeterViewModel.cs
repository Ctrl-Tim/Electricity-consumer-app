using System;
using System.ComponentModel;

namespace ElectricityConsumerContracts.ViewModels
{
    /// <summary>
    /// Электросчётчик
    /// </summary>
    public class ElectricMeterViewModel
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public int AddressId { get; set; }

        [DisplayName("Тип")]
        public string TypeName { get; set; }

        [DisplayName("Адрес")]
        public string FullAddress { get; set; }

        [DisplayName("ФИО владельца")]
        public string ConsumerFIO { get; set; }

        [DisplayName("Номер")]
        public decimal Number { get; set; }

        [DisplayName("Дата приёмки")]
        public DateTime? DateOfCheck { get; set; }

        [DisplayName("Срок госпроверки (лет)")]
        public int InspectionPeriod { get; set; }

        [DisplayName("Дата последней госпроверки")]
        public DateTime? FinalInspection { get; set; }
    }
}
