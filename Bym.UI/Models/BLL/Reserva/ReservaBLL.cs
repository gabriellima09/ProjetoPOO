﻿using System.Collections.Generic;
using System.Linq;
using Bym.UI.Models.BLL.Sala;
using Bym.UI.Models.BLL.Usuario;
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
            Domain.Reserva reserva = ReservaDAL.ConsultarPorId(id);
            reserva.Sala = new SalaBLL().ConsultarPorId(reserva.Sala.Id);
            reserva.Usuario = new UsuarioBLL().ConsultarPorId(reserva.Usuario.Id);

            return reserva;
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