using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Menu
    {
        [Column("Номер пиццы")]
        public Guid Id { get; set; }
        [Column("Названия")]
        [Required(ErrorMessage = "Это поле является обязательным")]
        public string Name { get; set; }
        [Column("Цена")]
        [Required(ErrorMessage = "Это поле является обязательным")]
        public string Price { get; set; }
        [ForeignKey(nameof(Pizzeria))]
        public Guid PizzeriaId { get; set; }
        public Pizzeria Pizzeria { get; set; }
    }
}
