using System.ComponentModel;

namespace ElectricityConsumerContracts.ViewModels
{
    /// <summary>
    /// Тип электросчётчика
    /// </summary>
    public class TypeElectricMeterViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
