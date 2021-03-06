﻿using System;
using System.Data;
using System.Text;
using Bym.UI.Models.Domain;

namespace Bym.UI.Models.DAL.Usuario
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private StringBuilder Sql;

        public UsuarioDAL()
        {
            Sql = new StringBuilder();
        }

        public bool Login(Domain.Usuario usuario)
        {
            bool existe = false;

            Sql.Append("SELECT (SELECT COUNT(*) FROM USUARIOS ");
            Sql.Append("WHERE ");
            Sql.Append("USUARIOS.Login LIKE '%" + usuario.Login + "%' ");
            Sql.Append("AND USUARIOS.Senha LIKE '%" + usuario.Senha + "%') AS 'Exists'");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    existe = Convert.ToInt32(reader["Exists"]) > 0;
                }
            }

            return existe;
        }

        public void Cadastrar(Domain.Usuario usuario)
        {
            Sql.Append("INSERT INTO USUARIOS (");
            Sql.Append("Nome, ");
            Sql.Append("Login, ");
            Sql.Append("Senha ");
            Sql.Append(")");
            Sql.Append("VALUES (");
            Sql.Append("'" + usuario.Nome + "',");
            Sql.Append("'" + usuario.Login + "',");
            Sql.Append("'" + usuario.Senha + "'");
            Sql.Append(")");

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public Domain.Usuario ConsultarPorId(int id)
        {
            Domain.Usuario usuario = new Domain.Usuario();

            Sql.Append("SELECT * FROM USUARIOS WHERE Id = " + id);

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    usuario = ObterEntidadeReader(reader);
                }
            }

            return usuario;
        }

        public Domain.Usuario ObterEntidadeReader(IDataReader reader)
        {
            Domain.Usuario usuario = new Domain.Usuario
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = Convert.ToString(reader["Nome"]),
                Login = Convert.ToString(reader["Login"]),
                Senha = Convert.ToString(reader["Senha"])
            };

            return usuario;
        }

        public Domain.Usuario RetornarDadosUsuario(string login, string senha)
        {
            Domain.Usuario usuario = null;

            Sql.Clear();

            Sql.Append("SELECT * FROM USUARIOS ");
            Sql.Append("WHERE ");
            Sql.Append("USUARIOS.Login LIKE '%" + login + "%' ");
            Sql.Append("AND USUARIOS.Senha LIKE '%" + senha + "%'");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    usuario = ObterEntidadeReader(reader);
                }
            }

            return usuario;
        }
    }
}