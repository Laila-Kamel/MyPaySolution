using System;
using System.Collections.Generic;
using System.IO;

namespace MyPayProject
{
    public class CsvImporter
    {
        /// <summary>
        /// get a list of all employees record
        /// </summary>
        /// <returns>list of type PayRecord</returns>

        public static List<PayRecord> ImportPayRecords(string file)
        {
            string record;
            int EmployeeId, previousId;
            double[] hour = new double[10];
            double[] rate = new double[10];

            List<PayRecord> payList = new List<PayRecord>();
            string[] strArray;
            StreamReader reader = new StreamReader(file);
            record = reader.ReadLine();
            record = reader.ReadLine(); // to skip reading the heading
            strArray = record.Split(',');

            int i = 0;
            while (record != null)
            {
                EmployeeId = int.Parse(strArray[0]);
                previousId = EmployeeId;
                string previousVisa = strArray[3];

                string previousYearToDate = strArray[4];
                while (record != null && previousId == int.Parse(strArray[0]))
                {
                    hour[i] = double.Parse(strArray[1]);
                    rate[i] = double.Parse(strArray[2]);
                    i++;
                    record = reader.ReadLine();

                    if (record != null && previousId == int.Parse(strArray[0]))
                    {

                        strArray = record.Split(',');
                    }
                }
                if (previousVisa == "")
                {
                    ResidentPayRecord resRec = new ResidentPayRecord(EmployeeId, hour, rate);
                    payList.Add(resRec);
                }
                else
                {

                    WorkingHolidayPayRecord workRes = new WorkingHolidayPayRecord(EmployeeId, hour, rate, int.Parse(previousVisa), int.Parse(previousYearToDate));
                    payList.Add(workRes);
                }
                i = 0;
                hour = new double[10];
                rate = new double[10];
            }
            reader.Close();
            return payList;
        }
    }

}
