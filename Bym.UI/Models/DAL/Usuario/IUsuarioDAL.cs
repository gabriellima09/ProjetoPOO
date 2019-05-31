using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bym.UI.Models.DAL.Usuario
{
    public interface IUsuarioDAL
    {
        void Cadastrar(Domain.Usuario usuario);
        void AlterarSenha();
    }
}
