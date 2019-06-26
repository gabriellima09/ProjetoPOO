using System;

namespace Bym.UI.Models.Domain
{
    public class Reserva : EntidadeDominio
    {
        public DateTime DataHora { get; set; }
        public int HorasReservadas { get; set; }
        public Sala Sala { get; set; }
        public Usuario Usuario { get; set; }
    }
}