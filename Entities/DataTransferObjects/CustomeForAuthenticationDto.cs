using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CustomerForAuthenticationDto
    {
        [Required(ErrorMessage = "Поле имя пользователя является обязательным")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле пароль является обязательным")]
        public string Password { get; set; }
    }
}
