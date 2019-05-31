using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bym.UI.Models.DAL.Usuario
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private StringBuilder Sql = new StringBuilder();

        public UsuarioDAL()
        {
            if (Sql.Length > 0)
            {
                Sql.Clear();
            }
        }

        public void AlterarSenha()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Domain.Usuario usuario)
        {
            Sql.Append("INSERT INTO USUARIOS (");
            Sql.Append("Login, ");
            Sql.Append("Senha ");
            Sql.Append(")");
            Sql.Append("VALUES (");
            Sql.Append("'" + usuario.Login + "'" + ",");
            Sql.Append("'" + usuario.Senha + "'");
            Sql.Append(")");

            DbContext.ExecuteQuery(Sql.ToString());
        }
    }
}