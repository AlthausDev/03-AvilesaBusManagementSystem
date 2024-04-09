using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvilesaBusManagementSystem.Model
{
    /// <summary>
    /// Representa una parada en el itinerario de una línea de autobús.
    /// </summary>
    public class Parada
    {
        /// <summary>
        /// Obtiene o establece el número de la línea a la que pertenece la parada.
        /// </summary>
        public long NumeroLinea { get; set; }

        /// <summary>
        /// Obtiene o establece el número que indica el orden en que se suceden las paradas.
        /// </summary>
        public int OrdenParada { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio al que pertenece la parada.
        /// </summary>
        public string Municipio { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo que se tarda en llegar a esta parada desde el origen.
        /// </summary>
        public TimeSpan TiempoDesdeOrigen { get; set; }
    }
}
