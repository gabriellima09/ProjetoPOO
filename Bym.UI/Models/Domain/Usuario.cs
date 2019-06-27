using System.ComponentModel.DataAnnotations;

namespace Bym.UI.Models.Domain
{
    public class Usuario : EntidadeDominio
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}