using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class PizzeriaConfiguration : IEntityTypeConfiguration<Pizzeria>
    {
        public void Configure(EntityTypeBuilder<Pizzeria> builder)
        {
            builder.HasData
            (
                new Pizzeria
                {
                    Id = new Guid("151b32c7-2e1a-4626-91de-7f1375b0fd9f"),
                    Name = "Lora della Pizza",
                    Address = "Ульянова 78",
                    Country = "Россия"
                }
            );
        }
    }

}
