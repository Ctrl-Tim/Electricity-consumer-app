using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityConsumerContracts.BindingModels
{
    /// <summary>
    /// Данные для снятия показаний
    /// </summary>   
    public class CreateReadingBindingModel
    {
        public int? Id { get; set; }

        public int ElectricMeterId { get; set; }

        public decimal ElectricMeterNumber { get; set; }

        public string FullAddress { get; set; }

        public string ConsumerFIO { get; set; }

        public float BeginningOfMonth { get; set; }

        public float EndOfMonth { get; set; }
    }
}
