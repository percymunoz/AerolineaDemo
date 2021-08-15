using Aerolinea.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Paso2
    {
        public List<Vuelo> VuelosIda { get; set; } = new List<Vuelo>();
        public List<Vuelo> VuelosRetorno { get; set; } = new List<Vuelo>();
        public DateTime FechaIda { get; set; }
        public DateTime FechaRetorno { get; set; }
    }
}
