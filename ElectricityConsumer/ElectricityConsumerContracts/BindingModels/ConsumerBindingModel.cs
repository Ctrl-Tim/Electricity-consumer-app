namespace ElectricityConsumerContracts.BindingModels
{
    /// <summary>
    /// Потребитель энергии
    /// </summary> 
    public class ConsumerBindingModel
    {
        public int? Id { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }
    }
}
