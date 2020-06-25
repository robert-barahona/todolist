using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todolist.Models
{
    public class UserLogin
    {
        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        public string email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        public string password { get; set; }

    }
}