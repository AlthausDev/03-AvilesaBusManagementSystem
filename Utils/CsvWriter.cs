using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project._04_LineasAutobuses.Utils
{
    internal class CsvWriter
    {
        public void WriteCsv(string filePath, char separator, string[][] data)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (string[] row in data)
                    {
                        string line = string.Join(separator.ToString(), row);
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
               
            }
        }
    }
}
