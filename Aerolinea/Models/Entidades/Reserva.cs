using System;
using System.Collections.Generic;

namespace Aerolinea.Models.Entidades
{
    public partial class Reserva
    {
        public int? ReservaId { get; set; }
        public DateTime? FechaReserva { get; set; }
        public int? VueloIda { get; set; }
        public int? VueloRetorno { get; set; }
        public int? PasajeroId { get; set; }
        public int? ClaseTarifariaId { get; set; }
        public decimal? PrecioReservado { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public virtual ClaseTarifaria ClaseTarifaria { get; set; }
        public virtual Pasajero Pasajero { get; set; }
        public virtual Vuelo VueloIdaNavigation { get; set; }
        public virtual Vuelo VueloRetornoNavigation { get; set; }
    }
}
