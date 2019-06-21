using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bym.UI.Models.Domain
{
    public class Reserva : EntidadeDominio
    {
        public DateTime DataHora { get; set; }
        public decimal HorasReservadas { get; set; }
        public Sala Sala { get; set; }
        public Usuario Usuario { get; set; }
    }
}