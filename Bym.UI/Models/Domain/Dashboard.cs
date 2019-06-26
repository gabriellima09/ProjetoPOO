namespace Bym.UI.Models.Domain
{
    public class Dashboard
    {
        public int TotalReservas { get; set; }
        public decimal ValorArrecadado { get; set; }
        public int TotalSalas { get; set; }
        public string SalaMaiorCapacidade { get; set; }
        public Reserva UltimaReserva { get; set; }
        public Sala UltimaSalaCadastrada { get; set; }
    }
}