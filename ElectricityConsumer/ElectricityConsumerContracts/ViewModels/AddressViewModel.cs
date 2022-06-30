using System.ComponentModel;

namespace ElectricityConsumerContracts.ViewModels
{
    /// <summary>
    /// Адрес электросчётчика
    /// </summary>
    public class AddressViewModel
    {
        public int Id { get; set; }

        public int ConsumerId { get; set; }

        [DisplayName("Улица")]
        public string Street { get; set; }

        [DisplayName("Дом")]
        public int House { get; set; }

        [DisplayName("Квартира")]
        public int Flat { get; set; }

        [DisplayName("Адрес")]
        public string FullAddress { get; set; }

        [DisplayName("ФИО потребителя")]
        public string ConsumerFIO { get; set; }

        [DisplayName("Номер счётчика")]
        public decimal? ElectricMeterNumber { get; set; }
    }
}
