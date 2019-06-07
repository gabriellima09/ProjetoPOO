using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bym.UI.Models.DAL.Usuario;
using Bym.UI.Models.Domain;

namespace Bym.UI.Models.BLL.Usuario
{
    public class GestaoUsuario : IUsuarioBLL
    {
        private readonly IUsuarioDAL usuarioDAL;

        public GestaoUsuario()
        {
            usuarioDAL = new UsuarioDAL();
        }

        public void Cadastrar(Domain.Usuario usuario)
        {
            usuarioDAL.Cadastrar(usuario);
        }

        public bool Login(Domain.Usuario usuario)
        {
            return usuarioDAL.Login(usuario);
        }
    }
}