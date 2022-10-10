using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        protected double[] _hours;
        protected double[] _rates;
        protected int _id;
        private double _gross = 0;


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public double Gross
        {
            get
            {
                _gross = 0;
                for (int i = 0; i < _hours.Length; i++)
                {
     
                    _gross = _gross + (_hours[i] * _rates[i]);

                }
                return Math.Round(_gross, 2);
            }
        }
        public abstract double Tax
        {
            get;
        }

        public double Net
        {
            get { return Math.Round(Gross - Tax, 2); }

        }
        public PayRecord(int id, double[] hours, double[] rates)
        {
            _id = id;
            _hours = hours;
            _rates = rates;

        }
        /// <summary>
        /// displays the details (id, gross, net, tax) of the employee
        /// </summary>
        /// <returns>string</returns>
        public virtual string GetDetails()
        {
            //TODO	The GetDetails method must return the employee ID, gross, net and tax amounts.//

            return "================EMPLOYEE:" + Id.ToString() + "===================" + "\n" +
                "GROSS:   $" + Gross.ToString() + "\n" + "NET:     $" + Net.ToString() + "\n" + "TAX:     $" + Tax.ToString();
        }
    }
}
