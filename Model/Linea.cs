using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Model
{
    public class Linea
    {
        /// <summary>
        /// Representa una línea de autobús.
        /// </summary>
        private long NumeroLinea { set; get; }
        private string Origen { set; get; }
        private string Destino { set; get; }
        private DateTime HoraSalida { set; get; }
        private DateTime HoraLlegada { set; get; }
        private TimeSpan IntervaloSalida { set; get; }
        private Itinerario Itinerario { set; get; }

        public Linea()
        {
        }

        public Linea(long numeroLinea, string origen, string destino,
            DateTime horaSalida, DateTime horaLlegada, TimeSpan intervaloSalida, Itinerario itinerario)
        {
            NumeroLinea = numeroLinea;
            Origen = origen;
            Destino = destino;
            HoraSalida = horaSalida;
            HoraLlegada = horaLlegada;
            IntervaloSalida = intervaloSalida;
            Itinerario = itinerario;
        }

    }
}
