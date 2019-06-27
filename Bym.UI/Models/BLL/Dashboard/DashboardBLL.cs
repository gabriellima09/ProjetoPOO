using Bym.UI.Models.DAL.Dashboard;
using Bym.UI.Models.DAL.Repository.Dashboard;
using System;

namespace Bym.UI.Models.BLL.Dashboard
{
    public class DashboardBLL : IDashboardBLL
    {
        readonly IDashboardDao _repository;

        public DashboardBLL()
        {
            _repository = new DashboardDAL();
        }

        public Domain.Dashboard RetornarDashboard()
        {
            return new Domain.Dashboard
            {
                SalaMaiorCapacidade = SalaMaiorCapacidade(),
                TotalReservas = TotalReservas(),
                TotalSalas = TotalSalas(),
                UltimaReserva = UltimaReserva(),
                UltimaSalaCadastrada = UltimaSala(),
                ValorArrecadado = ValorArrecadado()
            };
        }

        public string SalaMaiorCapacidade()
        {
            return _repository.SalaMaiorCapacidade();
        }

        public int TotalReservas()
        {
            return _repository.TotalReservas();
        }

        public int TotalSalas()
        {
            return _repository.TotalSalas();
        }

        public Domain.Reserva UltimaReserva()
        {
            return _repository.UltimaReserva();
        }

        public Domain.Sala UltimaSala()
        {
            return _repository.UltimaSala();
        }

        public decimal ValorArrecadado()
        {
            return _repository.ValorArrecadado();
        }
    }
}