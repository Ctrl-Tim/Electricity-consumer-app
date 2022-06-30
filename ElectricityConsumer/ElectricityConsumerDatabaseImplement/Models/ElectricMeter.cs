using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Электросчётчик
    /// </summary>
    public class ElectricMeter
    {
        [Key]
        [ForeignKey("Address")]
        public int Id { get; set; }

        public int TypeId { get; set; }

        [Required]
        public decimal Number { get; set; }

        public DateTime? DateOfCheck { get; set; }

        [Required]
        public int InspectionPeriod { get; set; }

        public DateTime? FinalInspection { get; set; }

        public virtual TypeElectricMeter TypeElectricMeter { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey("ElectricMeterId")]
        public virtual List<CounterReadings> CounterReadingss { get; set; }
    }
}
