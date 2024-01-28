using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Utils
{
    internal class CsvReader
    {
        public List<string[]> ReadCsv(string filePath, char separator)
        {
            List<string[]> records = new List<string[]>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(separator);
                        records.Add(values);
                    }
                }
            }
            catch (IOException ex)
            {
                
            }
            return records;
        }
    }
}
