//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUToDoList
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblBoard = new HashSet<tblBoard>();
        }

        
        [Display(Name = "Jefe ")]
        public int id_user { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nombres requeridos"), MaxLength(55)]
        [Display(Name = "Nombres")]
        public string first_name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Apellidos Requeridos requeridos"), MaxLength(55)]
        [Display(Name = "Apellidos")]
        public string last_name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Requerido"), MaxLength(55)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Requerido requeridos"), MaxLength(55)]
        [Display(Name = "Password")]
        public string pass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBoard> tblBoard { get; set; }
    }
}
