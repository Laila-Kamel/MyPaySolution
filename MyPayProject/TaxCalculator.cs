using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public class TaxCalculator
    {
        /// <summary>
        /// calculate the tax of the resident employee
        /// </summary>
        /// <param name="gross"></param>
        /// <returns>double</returns>
        public static double CalculateResidentialTax(double gross)
        {

            double valueA = 0;
            double valueB = 0;
            double tax;

            if(gross > -1 && gross <= 72)
            {
                valueA = 0.19;
                valueB = 0.19;
            }
            else if (gross > 72 && gross <= 361)
            {
                valueA = 0.2342;
                valueB = 3.213;
            }
            else if (gross > 361 && gross <= 932)
            {
                valueA = 0.3477;
                valueB = 44.2476;
            }
            else if (gross > 932 && gross <= 1380)
            {
                valueA = 0.345;
                valueB = 41.73111;
            }
            else if (gross > 1380 && gross <= 3111)
            {
                valueA = 0.39;
                valueB = 103.8657;
            }
            else if (gross > 3111 && gross <= 999999)
            {
                valueA = 0.47;
                valueB = 352.7888;
            }
            tax = Math.Round(valueA * gross - valueB,2);
            return tax;
        }
        /// <summary>
        /// Calculate the tax of the working holiday employee
        /// </summary>
        /// <param name="yearToDate"></param>
        /// <param name="grossValue"></param>
        /// <returns>double</returns>
        public static double CalculateWorkingHolidayTax(double yearToDate, double grossValue)
        {
            // double yearToDate;
            double rate = 0;
            double tax;
            double grossSum;
            grossSum = grossValue + yearToDate;
            if(grossSum>-1 && grossSum<37000)
            {
                rate = 0.15;
            }
            if (grossSum > 37000 && grossSum < 90000)
            {
                rate = 0.32;
            }
            if (grossSum > 90000 && grossSum < 180000)
            {
                rate = 0.37;
            }
            if (grossSum > 180000 && grossSum < 9999999)
            {
                rate = 0.45;
            }
            tax = Math.Round(grossValue * rate,2);
            return tax;
        }
    }
}
