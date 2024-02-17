using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Model
{
    public class Itinerario : IEditableObject, INotifyPropertyChanged
    {

        /// <summary>
        /// Representa un itinerario de una línea de autobús.
        /// </summary>

        private int Id { get; set; }
        private Dictionary <int, String> Municipios { get; set; }
        private TimeSpan IntervaloDesdeSalida { get; set; }       

        public Itinerario()
        {
        }

        public Itinerario(int id, Dictionary<int, string> municipios, TimeSpan intervaloDesdeSalida)
        {
            Id = id;
            Municipios = municipios;
            IntervaloDesdeSalida = intervaloDesdeSalida;

        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private Itinerario BackupCopy;
        private bool inEdit;

        public void BeginEdit()
        {
            if(!inEdit)
            {
                BackupCopy = this.MemberwiseClone() as Itinerario;
                inEdit = true;
            }
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            if (inEdit)
            {
                BackupCopy = null;
                inEdit = false;
            }
        }
    }
}
