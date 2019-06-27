using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Bym.UI.Models.Domain;

namespace Bym.UI.Models.DAL.Sala
{
    public class SalaDAL : IDao<Domain.Sala>
    {
        StringBuilder Sql;

        public SalaDAL()
        {
            Sql = new StringBuilder();
        }

        public void Alterar(Domain.Sala entidade)
        {
            Sql.Append("UPDATE SALAS SET");
            Sql.Append(" CapacidadeMaxima = " + entidade.CapacidadeMaxima + ",");
            Sql.Append(" Descricao = '" + entidade.Descricao + "',");
            Sql.Append(" Nome = '" + entidade.Nome + "',");
            Sql.Append(" ValorHora = " + entidade.ValorHora + ",");
            Sql.Append(" Logradouro = '" + entidade.Endereco.Logradouro + "',");
            Sql.Append(" Numero = '" + entidade.Endereco.Numero + "',");
            Sql.Append(" Complemento = '" + entidade.Endereco.Complemento + "'");
            Sql.Append(" WHERE Id = " + entidade.Id);

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public IList<Domain.Sala> ConsultarTodos()
        {
            IList<Domain.Sala> salas = new List<Domain.Sala>();

            Sql.Append("SELECT * FROM SALAS");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                while (reader.Read())
                {
                    Domain.Sala sala = new Domain.Sala();

                    sala = ObterEntidadeReader(reader);

                    salas.Add(sala);
                }
            }

            return salas;
        }

        public Domain.Sala ConsultarPorId(int id)
        {
            Domain.Sala sala = new Domain.Sala
            {
                Endereco = new Endereco()
            };

            Sql.Append("SELECT * FROM SALAS WHERE Id = " + id);

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    sala = ObterEntidadeReader(reader);
                }
            }

            return sala;
        }

        public void Excluir(int id)
        {
            Sql.Append("DELETE FROM SALAS WHERE Id = " + id);

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public void Cadastrar(Domain.Sala entidade)
        {
            Sql.Append("INSERT INTO SALAS (");
            Sql.Append(" CapacidadeMaxima,");
            Sql.Append(" Descricao,");
            Sql.Append(" Nome,");
            Sql.Append(" ValorHora,");
            Sql.Append(" Logradouro,");
            Sql.Append(" Numero,");
            Sql.Append(" Complemento");
            Sql.Append(")");
            Sql.Append("VALUES (");
            Sql.Append(entidade.CapacidadeMaxima + ",");
            Sql.Append("'" + entidade.Descricao + "',");
            Sql.Append("'" + entidade.Nome + "',");
            Sql.Append(entidade.ValorHora + ",");
            Sql.Append("'" + entidade.Endereco.Logradouro + "',");
            Sql.Append("'" + entidade.Endereco.Numero + "',");
            Sql.Append("'" + entidade.Endereco.Complemento + "'");
            Sql.Append(")");

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public Domain.Sala ObterEntidadeReader(IDataReader reader)
        {
            Domain.Sala sala = new Domain.Sala();
            sala.Endereco = new Endereco();

            sala.Id = Convert.ToInt32(reader["Id"]);
            sala.CapacidadeMaxima = Convert.ToInt32(reader["CapacidadeMaxima"]);
            sala.Descricao = Convert.ToString(reader["Descricao"]);
            sala.Nome = Convert.ToString(reader["Nome"]);
            sala.ValorHora = Convert.ToDecimal(reader["ValorHora"]);
            sala.Endereco.Logradouro = Convert.ToString(reader["Logradouro"]);
            sala.Endereco.Numero = Convert.ToString(reader["Numero"]);
            sala.Endereco.Complemento = Convert.ToString(reader["Complemento"]);

            return sala;
        }
    }
}