using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Тип электросчётчика
    /// </summary>
    public class TypeElectricMeter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("TypeId")]
        public List<ElectricMeter> ElectricMeters { get; set; }
    }
}
