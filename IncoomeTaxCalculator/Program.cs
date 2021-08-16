using System;

namespace IncoomeTaxCalculator
{
    class Program
    {
        static decimal TaxableIncome(decimal gross, decimal pension, decimal mortgage)
        {
            return gross - pension - mortgage;
        }
        static decimal TotalDeductions(decimal pension,decimal mortgage)
        {
            return pension + mortgage;
        }
        static decimal Tax(decimal TaxableIncome, decimal premium)
        {
            decimal personalRelief = 2400;
            decimal insuranceRelief = Convert.ToDecimal(0.15) * premium;
            decimal payableTax = Convert.ToDecimal(0) - personalRelief - insuranceRelief;
                        
            if (TaxableIncome < Convert.ToDecimal(24000))
            {
                Console.WriteLine("Gross pay is less than the minimum taxable income");
                payableTax = Convert.ToDecimal(0);
            }
            else if(TaxableIncome >= Convert.ToDecimal(24000))
            {
                payableTax += Convert.ToDecimal(0.1 * 24000);
            }
            else if (TaxableIncome > Convert.ToDecimal(24000) && TaxableIncome < Convert.ToDecimal(3233))
            {
                payableTax += Convert.ToDecimal(0.25 * 8333);
            }
            else 
            {
                payableTax += Convert.ToDecimal(0.3) * (TaxableIncome - Convert.ToDecimal(3233));
            }

            if (Tax(TaxableIncome, premium) < Convert.ToDecimal(0))
            {
                payableTax = Convert.ToDecimal(0);
            }

            return payableTax ;
        }
        static void Main(string[] args)
        {
            decimal personalRelief = Convert.ToDecimal(2400);

            Console.Write("Enter the gross pay: ");
            decimal grossPay = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the NSSF Contribution / Pension amount: ");
            decimal pensionContribution = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the Interest on Mortgage paid amount: ");
            decimal mortgageInterest = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the Insurance Premium paid amount: ");
            decimal PremiumPaid = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine();

            decimal insuranceRelief = Convert.ToDecimal(0.15) * PremiumPaid;

            Console.WriteLine("Grosspay: " + grossPay);
            Console.WriteLine("Pension Contribution: " + pensionContribution);
            Console.WriteLine("Mortgage interest: " + mortgageInterest);
            Console.WriteLine("Total deductions: " + TotalDeductions(pensionContribution, mortgageInterest));
            Console.WriteLine("Taxable income: " + TaxableIncome(grossPay, pensionContribution, mortgageInterest));
            Console.WriteLine("Peronal relief: " + personalRelief);
            Console.WriteLine("Insurance relief: " + insuranceRelief);
            Console.WriteLine("Tax: " + Tax(TaxableIncome(grossPay, pensionContribution, mortgageInterest), PremiumPaid));
        }
    }
}
