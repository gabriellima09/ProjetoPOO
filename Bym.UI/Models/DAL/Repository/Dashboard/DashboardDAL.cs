using Bym.UI.Models.DAL.Dashboard;
using Bym.UI.Models.DAL.Reserva;
using Bym.UI.Models.DAL.Sala;
using Bym.UI.Models.DAL.Usuario;
using System;
using System.Text;

namespace Bym.UI.Models.DAL.Repository.Dashboard
{
    public class DashboardDAL : IDashboardDao
    {
        StringBuilder Sql;

        public DashboardDAL()
        {
            Sql = new StringBuilder();
        }

        public Domain.Reserva UltimaReserva()
        {
            Sql.Clear();

            int id = 0;

            Sql.Append("SELECT TOP 1 Id FROM RESERVAS ORDER BY Id DESC");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                }
            }

            Domain.Reserva reserva = new ReservaDAL().ConsultarPorId(id);
            reserva.Sala = new SalaDAL().ConsultarPorId(reserva.Sala.Id);
            reserva.Usuario = new UsuarioDAL().ConsultarPorId(reserva.Usuario.Id);

            return reserva;
        }

        public Domain.Sala UltimaSala()
        {
            Sql.Clear();

            int id = 0;

            Sql.Append("SELECT TOP 1 Id FROM SALAS ORDER BY Id DESC");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                }
            }

            Domain.Sala sala = new SalaDAL().ConsultarPorId(id);

            return sala;
        }

        public string SalaMaiorCapacidade()
        {
            Sql.Clear();

            string nomeSala = string.Empty;

            Sql.Append("SELECT TOP 1 Nome FROM SALAS WHERE CapacidadeMaxima = (SELECT MAX(CapacidadeMaxima) FROM SALAS)");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    nomeSala = Convert.ToString(reader["Nome"]);
                }
            }

            return nomeSala;
        }

        public int TotalReservas()
        {
            Sql.Clear();

            int total = 0;

            Sql.Append("SELECT COUNT(Id) AS TOTAL FROM RESERVAS");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader["TOTAL"]);
                }
            }

            return total;
        }

        public int TotalSalas()
        {
            Sql.Clear();

            int total = 0;

            Sql.Append("SELECT COUNT(Id) AS TOTAL FROM SALAS");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader["TOTAL"]);
                }
            }

            return total;
        }

        public decimal ValorArrecadado()
        {
            Sql.Clear();
            
            decimal totalArrecadado = decimal.Zero;

            Sql.Append("SELECT((SELECT SUM(HORASRESERVADAS) AS HORAS FROM RESERVAS) * (SELECT SUM(VALORHORA) VALOR FROM RESERVAS R INNER JOIN SALAS S ON R.IDSALA = S.ID)) AS VALORARRECADADO");

            using (var reader = DbContext.ExecuteQueryReader(Sql.ToString()))
            {
                if (reader.Read())
                {
                    totalArrecadado = Convert.ToDecimal(reader["VALORARRECADADO"] != DBNull.Value ? reader["VALORARRECADADO"] : 0);
                }
            }

            return totalArrecadado;
        }
    }
}