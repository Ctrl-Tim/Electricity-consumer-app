using System.ComponentModel;

namespace ElectricityConsumerContracts.ViewModels
{
    /// <summary>
    /// Потребитель энергии
    /// </summary>
    public class ConsumerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string SurName { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
    }
}
