using Project._04_LineasAutobuses.Utils;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project._04_LineasAutobuses.Model
{
    public class Linea : IEditableObject, INotifyPropertyChanged, IHasNumeroLinea
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
                    OnPropertyChanged(nameof(NumeroLinea));
                }
            }
        }

        private string _origen;
        public string Origen
        {
            get { return _origen; }
            set
            {
                if (_origen != value)
                {
                    _origen = value;
                    OnPropertyChanged(nameof(Origen));
                }
            }
        }

        private string _destino;
        public string Destino
        {
            get { return _destino; }
            set
            {
                if (_destino != value)
                {
                    _destino = value;
                    OnPropertyChanged(nameof(Destino));
                }
            }
        }

        private DateTime _horaSalida;
        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set
            {
                if (_horaSalida != value)
                {
                    _horaSalida = value;
                    OnPropertyChanged(nameof(HoraSalida));
                }
            }
        }

        private DateTime _horaLlegada;
        public DateTime HoraLlegada
        {
            get { return _horaLlegada; }
            set
            {
                if (_horaLlegada != value)
                {
                    _horaLlegada = value;
                    OnPropertyChanged(nameof(HoraLlegada));
                }
            }
        }

        private TimeSpan _intervaloSalida;
        public TimeSpan IntervaloSalida
        {
            get { return _intervaloSalida; }
            set
            {
                if (_intervaloSalida != value)
                {
                    _intervaloSalida = value;
                    OnPropertyChanged(nameof(IntervaloSalida));
                }
            }
        }

        private Itinerario _itinerario;
        public Itinerario Itinerario
        {
            get { return _itinerario; }
            set
            {
                if (_itinerario != value)
                {
                    _itinerario = value;
                    OnPropertyChanged(nameof(Itinerario));
                }
            }
        }

        public Linea()
        {
        }

        public Linea(long numeroLinea, string origen, string destino,
            DateTime horaSalida, DateTime horaLlegada, TimeSpan intervaloSalida)
        {
            NumeroLinea = numeroLinea;
            Origen = origen;
            Destino = destino;
            HoraSalida = horaSalida;
            HoraLlegada = horaLlegada;
            IntervaloSalida = intervaloSalida;            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Linea _backupCopy;
        private bool _inEdit;

        public void BeginEdit()
        {
            if (!_inEdit)
            {
                // Crear una copia de seguridad del objeto actual
                _backupCopy = this.MemberwiseClone() as Linea;
                _inEdit = true;
            }
        }

        public void CancelEdit()
        {
            if (_inEdit)
            {
                // Restaurar el objeto desde la copia de seguridad
                if (_backupCopy != null)
                {
                    NumeroLinea = _backupCopy.NumeroLinea;
                    Origen = _backupCopy.Origen;
                    Destino = _backupCopy.Destino;
                    HoraSalida = _backupCopy.HoraSalida;
                    HoraLlegada = _backupCopy.HoraLlegada;
                    IntervaloSalida = _backupCopy.IntervaloSalida;
                    Itinerario = _backupCopy.Itinerario;
                }
                _inEdit = false;
            }
        }

        public void EndEdit()
        {
            if (_inEdit)
            {
                // Eliminar la copia de seguridad ya que se ha confirmado la edición
                _backupCopy = null;
                _inEdit = false;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
