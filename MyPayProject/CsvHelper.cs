using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace MyPayProject
{
    class CsvHelper
    {
        public static List<PayRecord> CsvHelperPayRecord(string file)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                int previousId = 1;
                List<PayRecord> payRec = new List<PayRecord>();
                double[] hour = new double[10];
                double[] rate = new double[10];
                string visa ="" ;
                string yearToDate="";
                int i = 1;
                csv.Read();

                while (csv.Read())
                {
                   

                    if (previousId != int.Parse(csv.GetField(0)))
                    {
                        if (visa == "")
                        {
                            payRec.Add(new ResidentPayRecord(previousId, hour, rate));
                        }
                        else
                        {
                            payRec.Add(new WorkingHolidayPayRecord(previousId, hour, rate, int.Parse(visa), int.Parse(yearToDate)));
                        }
                        hour = new double[10];
                        rate = new double[10];
                        i = 0;
                        previousId = int.Parse(csv.GetField(0));
                    }
                    visa = csv.GetField(3);
                    yearToDate = csv.GetField(4);
                    
                            hour[i] = double.Parse(csv.GetField(1));
                            rate[i] = double.Parse(csv.GetField(2));
                            i++;
                }
                if (visa.ToString() == "")
                {
                    payRec.Add(new ResidentPayRecord(previousId, hour, rate));
                }
                else
                {
                    payRec.Add(new WorkingHolidayPayRecord(previousId, hour, rate, int.Parse(visa), int.Parse(yearToDate)));
                }
                return payRec;

            }
        }
    }
}
