using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Util
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Vuelo
    {
        [JsonProperty]
        public int VueloId { get; set; }
        [JsonProperty]
        public string HoraSalida { get; set; }
        [JsonProperty]
        public string HoraLlegada { get; set; }
        [JsonProperty]
        public string OrigenIATA { get; set; }
        [JsonProperty]
        public string DestinoIATA { get; set; }
        [JsonProperty]
        public string OrigenCiudad { get; set; }
        [JsonProperty]
        public string DestinoCiudad { get; set; }
        [JsonProperty]
        public decimal Precio { get; set; }
        [JsonProperty]
        public string FechaVuelo { get; set; }

    }
}
