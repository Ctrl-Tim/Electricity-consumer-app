using System;
using System.ComponentModel.DataAnnotations;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Показания счётчика
    /// </summary>
    public class CounterReadings
    {
        public int Id { get; set; }

        public int ElectricMeterId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float BeginningOfMonth { get; set; }

        [Required]
        public float EndOfMonth { get; set; }

        public virtual ElectricMeter ElectricMeter { get; set; }
    }
}
