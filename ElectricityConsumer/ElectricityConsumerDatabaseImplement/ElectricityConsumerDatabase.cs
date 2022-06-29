using ElectricityConsumerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricityConsumerDatabaseImplement
{
    public class ElectricityConsumerDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=Istyuk-PC\SQLEXPRESS;Initial Catalog=DatabaseElectricityConsumer;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Consumer> Consumers { set; get; }

        public virtual DbSet<Address> Addresses { set; get; }

        public virtual DbSet<TypeElectricMeter> Types { set; get; }

        public virtual DbSet<ElectricMeter> ElectricMeters { set; get; }

        public virtual DbSet<CounterReadings> CounterReadingss { set; get; }
    }
}
