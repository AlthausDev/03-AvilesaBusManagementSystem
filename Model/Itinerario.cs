using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvilesaBusManagementSystem.Model
{
    /// <summary>
    /// Representa el itinerario de una línea de autobús con sus paradas y tiempos.
    /// </summary>
    public class Itinerario : INotifyPropertyChanged
    {
        private long _numeroLinea;
        /// <summary>
        /// Obtiene o establece el número de la línea a la que se refiere el itinerario.
        /// </summary>
        public long NumeroLinea
        {
            get { return _numeroLinea; }
            set
            {
                if (_numeroLinea != value)
                {
                    _numeroLinea = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICollection<Parada> _paradas;
        /// <summary>
        /// Obtiene o establece las paradas por las que pasa el autobús en el itinerario.
        /// </summary>
        public ICollection<Parada> Paradas
        {
            get { return _paradas; }
            set
            {
                if (_paradas != value)
                {
                    _paradas = value;
                    OnPropertyChanged();
                }
            }
        }

        private TimeSpan _tiempoRecorrido;
        /// <summary>
        /// Obtiene o establece el tiempo que se tarda en recorrer el itinerario desde la salida hasta el destino.
        /// </summary>
        public TimeSpan TiempoRecorrido
        {
            get { return _tiempoRecorrido; }
            set
            {
                if (_tiempoRecorrido != value)
                {
                    _tiempoRecorrido = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
