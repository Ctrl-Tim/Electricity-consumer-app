namespace ElectricityConsumerContracts.BindingModels
{
    /// <summary>
    /// Адрес электросчётчика
    /// </summary>
    public class AddressBindingModel
    {
        public int? Id { get; set; }

        public int? ConsumerId { get; set; }

        public int? ElectricMeterId { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public int Flat { get; set; }
    }
}
