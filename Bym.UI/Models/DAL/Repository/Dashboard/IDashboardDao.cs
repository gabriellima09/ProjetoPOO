namespace Bym.UI.Models.DAL.Dashboard
{
    public interface IDashboardDao
    {
        string SalaMaiorCapacidade();
        int TotalReservas();
        int TotalSalas();
        Domain.Reserva UltimaReserva();
        Domain.Sala UltimaSala();
        decimal ValorArrecadado();
    }
}
