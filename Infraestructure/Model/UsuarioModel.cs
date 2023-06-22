using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Model
{
    public  class UsuarioModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int IdPersona { get; set; }

        public string Estado { get; set; }
    }
}
