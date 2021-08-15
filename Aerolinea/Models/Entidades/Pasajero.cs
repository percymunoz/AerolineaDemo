using System;
using System.Collections.Generic;

namespace Aerolinea.Models.Entidades
{
    public partial class Pasajero
    {
        public Pasajero()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int? PasajeroId { get; set; }
        public int? TipoDoc { get; set; }
        public string NroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
