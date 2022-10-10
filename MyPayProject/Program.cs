using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool writeToConsole = false;
            string answer;
            string fileRead = @"..\..\Import/employee-payroll-data.csv";
            string fileWrite = @"..\..\Export/" + DateTime.Now.Ticks.ToString() + "-records.csv";
            List<PayRecord> pay = new List<PayRecord>();
            //pay = CsvHelper.CsvHelperPayRecord(fileRead);
            pay = CsvImporter.ImportPayRecords(fileRead); // you can either use csvImporter.ImportPayRecord or csvHelper.CsvHelperPayRecord
            Console.WriteLine("Do you want to display the details on the console? (Y or N)");
            answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
                writeToConsole = true;
           // write in the file
             PayRecordWriter.Write(pay,fileWrite,writeToConsole);
            Console.ReadKey();
        }
    }
}
