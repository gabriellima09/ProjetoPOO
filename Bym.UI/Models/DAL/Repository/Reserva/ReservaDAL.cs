using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bym.UI.Models.DAL.Reserva
{
    public class ReservaDAL : IDao<Domain.Reserva>
    {
        StringBuilder Sql;

        public ReservaDAL()
        {
            Sql = new StringBuilder();
        }

        public void Alterar(Domain.Reserva entidade)
        {
            Sql.Append("UPDATE RESERVAS SET");
            Sql.Append(" DataHora = '" + entidade.DataHora.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            Sql.Append(" HorasReservadas = " + entidade.HorasReservadas + ",");
            Sql.Append(" IdSala = " + entidade.Sala.Id + ",");
            Sql.Append(" IdUsuario = " + entidade.Usuario.Id);
            Sql.Append(" WHERE Id = " + entidade.Id);

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public IList<Domain.Reserva> ConsultarTodos()
        {
            IList<Domain.Reserva> reservas = new List<Domain.Reserva>();

            Sql.Append("SELECT * FROM RESERVAS");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                while (reader.Read())
                {
                    Domain.Reserva reserva = new Domain.Reserva();

                    reserva = ObterEntidadeReader(reader);

                    reservas.Add(reserva);
                }
            }

            return reservas;
        }

        public Domain.Reserva ConsultarPorId(int id)
        {
            Domain.Reserva reserva = new Domain.Reserva();

            Sql.Append("SELECT * FROM RESERVAS WHERE Id = " + id);

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    reserva = ObterEntidadeReader(reader);
                }
            }

            return reserva;
        }

        public void Excluir(int id)
        {
            Sql.Append("DELETE FROM RESERVAS WHERE Id = " + id);

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public void Cadastrar(Domain.Reserva entidade)
        {
            Sql.Append("INSERT INTO RESERVAS (");
            Sql.Append(" DataHora,");
            Sql.Append(" HorasReservadas,");
            Sql.Append(" IdSala,");
            Sql.Append(" IdUsuario");
            Sql.Append(")");
            Sql.Append("VALUES (");
            Sql.Append("'" + entidade.DataHora.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            Sql.Append(entidade.HorasReservadas + ",");
            Sql.Append(entidade.Sala.Id + ",");
            Sql.Append(entidade.Usuario.Id);
            Sql.Append(")");

            DbContext.ExecuteQuery(Sql.ToString());
        }

        public Domain.Reserva ObterEntidadeReader(IDataReader reader)
        {
            Domain.Reserva reserva = new Domain.Reserva();
            reserva.Sala = new Domain.Sala();
            reserva.Usuario = new Domain.Usuario();

            reserva.Id = Convert.ToInt32(reader["Id"]);
            reserva.DataHora = Convert.ToDateTime(reader["DataHora"]);
            reserva.HorasReservadas = Convert.ToInt32(reader["HorasReservadas"]);
            reserva.Sala.Id = Convert.ToInt32(reader["IdSala"]);
            reserva.Usuario.Id = Convert.ToInt32(reader["IdUsuario"]);

            return reserva;
        }
    }
}