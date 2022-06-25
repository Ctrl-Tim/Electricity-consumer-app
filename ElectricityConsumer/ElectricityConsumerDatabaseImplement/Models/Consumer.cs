using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityConsumerDatabaseImplement.Models
{
    /// <summary>
    /// Потребитель энергии
    /// </summary>
    public class Consumer
    {
        public int Id { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string Patronymic { get; set; }

        [ForeignKey("ConsumerId")]
        public List<Address> Addresses { get; set; }
    }
}
