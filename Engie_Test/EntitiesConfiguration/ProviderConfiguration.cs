using Engie_Test.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engie_Test.EntitiesConfiguration.EntitiesConfiguration
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasKey(prop => prop.Id);

            builder.HasData(
             new Provider { Id = 1, Name = "SOLARIAN" },
             new Provider { Id = 2, Name = "FUTURA" },
             new Provider { Id = 3, Name = "CENTRAL GERADORA FAZENDA MODELO" },
             new Provider { Id = 4, Name = "NOVA MUNDO" },
             new Provider { Id = 5, Name = "SOLARE" },
             new Provider { Id = 6, Name = "UNISOL" });
        }
    }
}
