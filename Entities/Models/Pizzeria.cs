using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Pizzeria
    {
        [Column("Номер пиццерии")]
        public Guid Id { get; set; }
        [Column("Название")]
        [Required(ErrorMessage = "Это поле является обязательным")]
        public string Name { get; set; }
        [Column("Адрес")]
        [Required(ErrorMessage = "Это поле является обязательным")]
        public string Address { get; set; }
        public string Country { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
