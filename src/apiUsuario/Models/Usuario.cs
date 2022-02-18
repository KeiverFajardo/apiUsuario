using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiUsuario.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
    }
}

