using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Project._04_LineasAutobuses.Utils
{
    public class CsvDataService<T>
    {
        private readonly string FileName;
        private readonly string FilePath;

        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string DataFolder = "Data";

        public CsvConfiguration Configuration { get; }

        public CsvDataService(string fileName)
        {
            FileName = fileName;
            FilePath = System.IO.Path.Combine(Path, DataFolder, FileName);

            Configuration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = ",",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = true // Indica si el archivo CSV tiene un encabezado
            };
        }

        public ObservableCollection<T> ReadFromCsv()
        {
            try
            {
                using (var reader = new StreamReader(FilePath, Encoding.UTF8))
                using (var csv = new CsvReader(reader, Configuration))
                {
                    return (ObservableCollection<T>) csv.GetRecords<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer desde el archivo CSV {FilePath}: {ex.Message}");
                return new ObservableCollection<T>();
            }
        }

        public void WriteToCsv(List<T> records)
        {
            try
            {
                using (var writer = new StreamWriter(FilePath, false, Encoding.UTF8))
                using (var csv = new CsvWriter(writer, Configuration))
                {
                    csv.WriteRecords(records);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo CSV {FilePath}: {ex.Message}");
            }
        }
    }
}
