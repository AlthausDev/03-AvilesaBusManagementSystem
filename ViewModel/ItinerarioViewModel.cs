using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.ViewModel
{
  
    class ItinerarioViewModel
    {
        public ObservableCollection<Itinerario> Intinerarios { get; set; }

        public ItinerarioViewModel()
        {
            Intinerarios = new ObservableCollection<Itinerario>();

            var itinerariosCsv = new CsvDataService<Itinerario>("itinerarios.csv");
            var itinerarios = itinerariosCsv.ReadFromCsv();
        }
    }
}
