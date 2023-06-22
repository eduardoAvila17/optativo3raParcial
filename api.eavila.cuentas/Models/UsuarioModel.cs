using System.ComponentModel.DataAnnotations;

namespace api.eavila.cuentas.Models
{
    public class UsuarioModel
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
