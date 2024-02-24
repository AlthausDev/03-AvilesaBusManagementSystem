using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project._04_LineasAutobuses.Model
{
    public class Itinerario : IEditableObject, INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private Dictionary<int, string> _municipios;
        public Dictionary<int, string> Municipios
        {
            get { return _municipios; }
            set
            {
                if (_municipios != value)
                {
                    _municipios = value;
                    OnPropertyChanged(nameof(Municipios));
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
                    OnPropertyChanged(nameof(IntervaloDesdeSalida));
                }
            }
        }

        public Itinerario()
        {
        }

        public Itinerario(int id, Dictionary<int, string> municipios, TimeSpan intervaloDesdeSalida)
        {
            Id = id;
            Municipios = municipios;
            IntervaloDesdeSalida = intervaloDesdeSalida;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Itinerario _backupCopy;
        private bool _inEdit;

        public void BeginEdit()
        {
            if (!_inEdit)
            {
                _backupCopy = this.MemberwiseClone() as Itinerario;
                _inEdit = true;
            }
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
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
