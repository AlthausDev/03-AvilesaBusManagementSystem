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
    /// <summary>
    /// Clase genérica para leer y escribir datos desde/hacia archivos CSV.
    /// </summary>
    /// <typeparam name="T">El tipo de datos que se leerán o escribirán desde/hacia el archivo CSV.</typeparam>
    public class CsvDataService<T>
    {
        private readonly string FileName;
        private readonly string FilePath;

        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string DataFolder = "Data";

        /// <summary>
        /// Configuración para el lector y escritor CSV.
        /// </summary>
        public CsvConfiguration Configuration { get; }

        /// <summary>
        /// Constructor de la clase CsvDataService.
        /// </summary>
        /// <param name="fileName">Nombre del archivo CSV.</param>
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

        /// <summary>
        /// Lee los datos desde el archivo CSV y los carga en una colección observable.
        /// </summary>
        /// <returns>Una colección observable de tipo T.</returns>
        public ObservableCollection<T> ReadFromCsv()
        {
            try
            {
                using (var reader = new StreamReader(FilePath, Encoding.UTF8))
                using (var csv = new CsvReader(reader, Configuration))
                {
                    return new ObservableCollection<T>(csv.GetRecords<T>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer desde el archivo CSV {FilePath}: {ex.Message}");
                return new ObservableCollection<T>();
            }
        }

        /// <summary>
        /// Escribe los registros en el archivo CSV.
        /// </summary>
        /// <param name="records">La lista de registros a escribir en el archivo CSV.</param>
        public void WriteToCsv(ObservableCollection<T> records)
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
