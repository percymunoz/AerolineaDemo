using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Paso3
    {
        public DateTime FechaIda { get; set; }
        public DateTime FechaRetorno { get; set; }
        public int IDVueloIda { get; set; }
        public int IDVueloRetorno { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }
    }
}
