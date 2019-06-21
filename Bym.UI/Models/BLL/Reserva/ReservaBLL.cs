using System.Collections.Generic;
using System.Linq;
using Bym.UI.Models.DAL;
using Bym.UI.Models.DAL.Reserva;

namespace Bym.UI.Models.BLL.Reserva
{
    public class ReservaBLL : ICrud<Domain.Reserva>
    {
        private IDao<Domain.Reserva> ReservaDAL;

        public ReservaBLL()
        {
            ReservaDAL = new ReservaDAL();
        }
        public void Alterar(Domain.Reserva entidade)
        {
            ReservaDAL.Alterar(entidade);
        }

        public void Cadastrar(Domain.Reserva entidade)
        {
            ReservaDAL.Cadastrar(entidade);
        }

        public Domain.Reserva ConsultarPorId(int id)
        {
            return ReservaDAL.ConsultarPorId(id);
        }

        public List<Domain.Reserva> ConsultarTodos()
        {
            return ReservaDAL.ConsultarTodos().ToList();
        }

        public void Excluir(int id)
        {
            ReservaDAL.Excluir(id);
        }
    }
}