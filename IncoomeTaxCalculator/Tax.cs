using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncoomeTaxCalculator
{
    class _Tax
    {      
        public decimal PersonalRelief { get; set; }
        public decimal GrossPay { get; set; }
        public decimal PensionContribution { get; set; }
        public decimal MortgageInterest { get; set; }
        public decimal PremiumPaid { get; set; }
        public decimal TaxableIncome(decimal gross, decimal pension, decimal mortgage)
        {
            return gross - pension - mortgage;
        }
        public decimal TotalDeductions(decimal pension, decimal mortgage)
        {
            return pension + mortgage;
        }
        public decimal Tax(decimal TaxableIncome, decimal insuranceRelief)
        {
            const decimal personalRelief = 2400;
            decimal payableTax = Convert.ToDecimal(0) - personalRelief - insuranceRelief;

            if (TaxableIncome < Convert.ToDecimal(24000))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gross pay is less than the minimum taxable income");
                Console.ForegroundColor = ConsoleColor.White;
                payableTax = Convert.ToDecimal(0);
            }
            if (TaxableIncome >= Convert.ToDecimal(24000))
            {
                payableTax += Convert.ToDecimal(0.1 * 24000);
                TaxableIncome -= 24000;
            }
            if (TaxableIncome > Convert.ToDecimal(24000))
            {
                payableTax += Convert.ToDecimal(0.25 * 8333);
                TaxableIncome -= 8333;
            }
            if (TaxableIncome > Convert.ToDecimal(32333))
            {
                payableTax += Convert.ToDecimal(0.3) * TaxableIncome;
            }

            return payableTax;
        }
    }
}
