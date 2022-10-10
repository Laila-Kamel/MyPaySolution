using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public class ResidentPayRecord : PayRecord
    {


        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {

        }
        public override double Tax
        {
            get { return TaxCalculator.CalculateResidentialTax(Gross); }
        }
        /// <summary>
        /// get the details of the employee
        /// </summary>
        /// <returns>string</returns>
        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
