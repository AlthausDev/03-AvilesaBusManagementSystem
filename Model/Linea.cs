using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Model
{
    public class Linea : IEditableObject, INotifyPropertyChanged
    {

        [Key]
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


        public event PropertyChangedEventHandler? PropertyChanged;

        private Linea BackupCopy;
        private bool inEdit;

        public void BeginEdit()
        {
            if (!inEdit)
            {
                // Crear una copia de seguridad del objeto actual
                BackupCopy = this.MemberwiseClone() as Linea;
                inEdit = true;
            }
        }

        public void CancelEdit()
        {
            if (inEdit)
            {
                // Restaurar el objeto desde la copia de seguridad
                if (BackupCopy != null)
                {
                    this.NumeroLinea = BackupCopy.NumeroLinea;
                    this.Origen = BackupCopy.Origen;
                    this.Destino = BackupCopy.Destino;
                    this.HoraSalida = BackupCopy.HoraSalida;
                    this.HoraLlegada = BackupCopy.HoraLlegada;
                    this.IntervaloSalida = BackupCopy.IntervaloSalida;
                    this.Itinerario = BackupCopy.Itinerario;
                }
                inEdit = false;
            }
        }

        public void EndEdit()
        {
            if (inEdit)
            {
                // Eliminar la copia de seguridad ya que se ha confirmado la edición
                BackupCopy = null;
                inEdit = false;
            }
        }
    }
}
