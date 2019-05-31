using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bym.UI.Models.Domain
{
    public class Usuario : EntidadeDominio
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}