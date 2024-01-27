using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Model
{
    internal class Itinerario
    {

        /// <summary>
        /// Representa un itinerario de una línea de autobús.
        /// </summary>

        private int Id { get; set; }
        private Dictionary <int, String> Municipios { get; set; }
        private TimeSpan IntervaloDesdeSalida { get; set; }
        public Parada[] Paradas { get; set; }

        public Itinerario()
        {
        }

        public Itinerario(int id, Dictionary<int, string> municipios, TimeSpan intervaloDesdeSalida, Parada[] paradas)
        {
            Id = id;
            Municipios = municipios;
            IntervaloDesdeSalida = intervaloDesdeSalida;
            Paradas = paradas;
        }
    }
}
