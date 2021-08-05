
using Engie_Test.Entitites;
using Engie_Test.EntitiesConfiguration.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Engie_Test.ViewModels;

namespace Engie_Test.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options){


            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           

            modelBuilder.ApplyConfiguration(new PowerPlantConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());

        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<PowerPlant> PowerPlants { get; set; }       
        
    }
}
