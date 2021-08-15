using System;
using System.Collections.Generic;

namespace Aerolinea.Models.Entidades
{
    public partial class ClaseTarifaria
    {
        public ClaseTarifaria()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int ClaseTarifariaId { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioBase { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
