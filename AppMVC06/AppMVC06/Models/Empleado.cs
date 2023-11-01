using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMVC06.Models
{
    public class Empleado
    {
        //propiedades
        public int IdEmpleado { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El password es requerido."),DisplayName("Password")]
        public string Apellidos { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string Nombre { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
