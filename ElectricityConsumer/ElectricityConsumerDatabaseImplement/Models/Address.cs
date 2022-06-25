using System.ComponentModel.DataAnnotations;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Адрес электросчётчика
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        public int ConsumerId { get; set; }

        public int ElectricMeterId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int House { get; set; }

        [Required]
        public int Flat { get; set; }

        public virtual Consumer Consumer { get; set; }

        public virtual ElectricMeter ElectricMeter { get; set; }
    }
}
