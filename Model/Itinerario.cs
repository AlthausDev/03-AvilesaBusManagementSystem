using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project._04_LineasAutobuses.Model
{  

    public class Itinerario : INotifyPropertyChanged
    {
        private long _numeroLinea;
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

        private List<Parada> _paradas;
        public List<Parada> Paradas
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

        private TimeSpan _intervaloDesdeSalida;
        public TimeSpan IntervaloDesdeSalida
        {
            get { return _intervaloDesdeSalida; }
            set
            {
                if (_intervaloDesdeSalida != value)
                {
                    _intervaloDesdeSalida = value;
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
