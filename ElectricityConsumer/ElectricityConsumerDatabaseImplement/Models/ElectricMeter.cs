﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Электросчётчик
    /// </summary>
    public class ElectricMeter
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public int AddressId { get; set; }

        [Required]
        public decimal Number { get; set; }

        public DateTime? DateOfCheck { get; set; }

        [Required]
        public int InspectionPeriod { get; set; }

        public DateTime? FinalInspection { get; set; }

        public Type Type { get; set; }

        public Address Address { get; set; }
    }
}
