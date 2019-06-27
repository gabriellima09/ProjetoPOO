namespace Bym.UI.Models.BLL.Dashboard
{
    public interface IDashboardBLL
    {
        string SalaMaiorCapacidade();
        int TotalReservas();
        int TotalSalas();
        Domain.Reserva UltimaReserva();
        Domain.Sala UltimaSala();
        decimal ValorArrecadado();
    }
}
