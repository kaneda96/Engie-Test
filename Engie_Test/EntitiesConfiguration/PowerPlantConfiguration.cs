using Engie_Test.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engie_Test.EntitiesConfiguration.EntitiesConfiguration
{
    public class PowerPlantConfiguration : IEntityTypeConfiguration<PowerPlant>
    {
        public void Configure(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.ToTable("Usinas");  

            builder.HasKey(p => p.PowerPlantId);
            builder.Navigation(p => p.Provider).AutoInclude();
            builder.HasIndex(i => i.PowerPlantUC).IsUnique();

            builder.Property(p => p.PowerPlantUC).IsRequired().HasMaxLength(10);

            var powerPlantsPaginationTest = new List<PowerPlant>();

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                powerPlantsPaginationTest.Add(new PowerPlant {PowerPlantId = i+1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Enabled = true, ProviderId = random.Next(1, 5), PowerPlantUC = "TESTE" + (i + 1)});
            }

            builder.HasData(powerPlantsPaginationTest);
        }

       
    }
}
