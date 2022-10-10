using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public class WorkingHolidayPayRecord : PayRecord
    {
        private int visa;
        private int yearToDate;

        public int Visa
        {
            get { return visa; }
            private set { visa = value; }
        }
        public int YearToDate
        {
            get
            {
                return yearToDate;
            }
            private set { yearToDate = value; }
        }
        public override double Tax
        {
            get { return TaxCalculator.CalculateWorkingHolidayTax(YearToDate, Gross); }
        }

        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }
        /// <summary>
        /// get the details of the employee
        /// </summary>
        /// <returns>string</returns>
        public override string GetDetails()
        {
            //TODO must return as well the visa and yeartodate
            return base.GetDetails() + "\n" + "VISA:    " + Visa.ToString() + "\n" + "YTD:     $" + (YearToDate + (int)Gross).ToString();
        }
    }


}
