using System;
using System.Collections.Generic;

namespace Aerolinea.Models.Entidades
{
    public partial class Aeropuerto
    {
        public Aeropuerto()
        {
            VueloAeropuertoDestinoNavigation = new HashSet<Vuelo>();
            VueloAeropuertoOrigenNavigation = new HashSet<Vuelo>();
        }

        public int? AeropuertoId { get; set; }
        public string CodigoIata { get; set; }
        public string Ciudad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vuelo> VueloAeropuertoDestinoNavigation { get; set; }
        public virtual ICollection<Vuelo> VueloAeropuertoOrigenNavigation { get; set; }
    }
}
