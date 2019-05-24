using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bym.UI.Models.Domain
{
    public class Usuario : EntidadeDominio
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}