using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPayProject
{
    public class PayRecordWriter
    {
        /// <summary>
        /// writes the Pay Record into a csv file
        /// </summary>
        /// <param name="records"></param>
        /// <param name="fileName"></param>
        /// <param name="writeConsole"></param>
        public static void Write(List<PayRecord> records, string fileName, bool writeConsole)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write("ID, Gross,Tax,Net\n");
            foreach (PayRecord rec in records)
            {
                writer.Write(rec.Id + "," + rec.Gross+","+rec.Tax + "," + rec.Net + "\n");
            }
            writer.Close();
            if (writeConsole == true)
            {
                foreach (PayRecord rec in records)
                {
                    Console.WriteLine(rec.GetDetails());
                }
            }
        }
    }
}
