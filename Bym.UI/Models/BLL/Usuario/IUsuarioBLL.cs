using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bym.UI.Models.Domain;

namespace Bym.UI.Models.BLL.Usuario
{
    public interface IUsuarioBLL
    {
        void Cadastrar(Domain.Usuario usuario);
        bool Login(Domain.Usuario usuario);
    }
}
