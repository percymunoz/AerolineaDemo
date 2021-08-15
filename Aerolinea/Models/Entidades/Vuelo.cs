using System;
using System.Collections.Generic;

namespace Aerolinea.Models.Entidades
{
    public partial class Vuelo
    {
        public Vuelo()
        {
            ReservaVueloIdaNavigation = new HashSet<Reserva>();
            ReservaVueloRetornoNavigation = new HashSet<Reserva>();
        }

        public int VueloId { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public TimeSpan? HoraLlegada { get; set; }
        public int? AeropuertoOrigen { get; set; }
        public int? AeropuertoDestino { get; set; }

        public virtual Aeropuerto AeropuertoDestinoNavigation { get; set; }
        public virtual Aeropuerto AeropuertoOrigenNavigation { get; set; }
        public virtual ICollection<Reserva> ReservaVueloIdaNavigation { get; set; }
        public virtual ICollection<Reserva> ReservaVueloRetornoNavigation { get; set; }
    }
}
