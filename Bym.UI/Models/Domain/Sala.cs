namespace Bym.UI.Models.Domain
{
    public class Sala : EntidadeDominio
    {
        public int CapacidadeMaxima { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal ValorHora { get; set; }
        public Endereco Endereco { get; set; }
    }
}