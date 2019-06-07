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

        public bool Login(Domain.Usuario usuario)
        {
            Sql.Append("SELECT (SELECT COUNT(*) FROM USUARIOS ");
            Sql.Append("WHERE ");
            Sql.Append("USUARIOS.Login LIKE '%" + usuario.Login + "%' ");
            Sql.Append("AND USUARIOS.Senha LIKE '%" + usuario.Senha + "%') AS 'Exists'");

            var reader = DbContext.ExecuteQueryLogin(Sql.ToString());

            return reader;
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