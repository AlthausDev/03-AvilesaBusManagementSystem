using AvilesaBusManagementSystem.Utils;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvilesaBusManagementSystem.Model
{
    /// <summary>
    /// Representa una línea de autobús con sus detalles.
    /// </summary>
    public class Linea : IEditableObject, INotifyPropertyChanged, IHasNumeroLinea
    {
        private long _numeroLinea;
        /// <summary>
        /// Obtiene o establece el número de la línea.
        /// </summary>
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

        private Parada _origen;
        /// <summary>
        /// Obtiene o establece el municipio de origen de la línea.
        /// </summary>
        public Parada Origen
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

        private Parada _destino;
        /// <summary>
        /// Obtiene o establece el municipio de destino de la línea.
        /// </summary>
        public Parada Destino
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

        private DateTime _horaInicialSalida;
        /// <summary>
        /// Obtiene o establece la hora inicial de salida de los autobuses.
        /// </summary>
        public DateTime HoraInicialSalida
        {
            get { return _horaInicialSalida; }
            set
            {
                if (_horaInicialSalida != value)
                {
                    _horaInicialSalida = value;
                    OnPropertyChanged(nameof(HoraInicialSalida));
                }
            }
        }

        private TimeSpan _intervaloEntreBuses;
        /// <summary>
        /// Obtiene o establece el intervalo de tiempo entre la salida de los autobuses.
        /// </summary>
        public TimeSpan IntervaloEntreBuses
        {
            get { return _intervaloEntreBuses; }
            set
            {
                if (_intervaloEntreBuses != value)
                {
                    _intervaloEntreBuses = value;
                    OnPropertyChanged(nameof(IntervaloEntreBuses));
                }
            }
        }

        public Linea()
        {
        }

        public Linea(long numeroLinea, Parada municipioOrigen, Parada municipioDestino,
            DateTime horaInicialSalida, TimeSpan intervaloEntreBuses)
        {
            NumeroLinea = numeroLinea;
            Origen = municipioOrigen;
            Destino = municipioDestino;
            HoraInicialSalida = horaInicialSalida;
            IntervaloEntreBuses = intervaloEntreBuses;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Linea _backupCopy;
        private bool _inEdit;

        public void BeginEdit()
        {
            if (!_inEdit)
            {
                _backupCopy = this.MemberwiseClone() as Linea;
                _inEdit = true;
            }
        }

        public void CancelEdit()
        {
            if (_inEdit)
            {
                if (_backupCopy != null)
                {
                    NumeroLinea = _backupCopy.NumeroLinea;
                    Origen = _backupCopy.Origen;
                    Destino = _backupCopy.Destino;
                    HoraInicialSalida = _backupCopy.HoraInicialSalida;
                    IntervaloEntreBuses = _backupCopy.IntervaloEntreBuses;
                }
                _inEdit = false;
            }
        }

        public void EndEdit()
        {
            if (_inEdit)
            {
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

