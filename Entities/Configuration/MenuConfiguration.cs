using Entities.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData
            (
                new Menu
                {
                    Id = new Guid("86dfd7ea-71ac-401b-b3a5-59c907261578"),
                    Name = "Пепперони",
                    Price = "400",
                    PizzeriaId = new Guid("151b32c7-2e1a-4626-91de-7f1375b0fd9f")
                },
                new Menu
                {
                    Id = new Guid("f0e74f35-b741-4684-a8a1-f00df8979f5a"),
                    Name = "Гавайская",
                    Price = "600",
                    PizzeriaId = new Guid("151b32c7-2e1a-4626-91de-7f1375b0fd9f")
                },
                new Menu
                {
                    Id = new Guid("c639c30a-7b81-4b9b-bb7c-57a035b08da7"),
                    Name = "Мексиканская",
                    Price = "500",
                    PizzeriaId = new Guid("151b32c7-2e1a-4626-91de-7f1375b0fd9f")
                }
            );
        }
    }
}
