using ConsoleTables;
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
        static decimal Tax(decimal TaxableIncome, decimal premium, decimal insuranceRelief)
        {
            decimal personalRelief = 2400;
            decimal payableTax = Convert.ToDecimal(0) - personalRelief - insuranceRelief;
                        
            if (TaxableIncome < Convert.ToDecimal(24000))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gross pay is less than the minimum taxable income");
                Console.ForegroundColor = ConsoleColor.White;
                payableTax = Convert.ToDecimal(0);
            }
            if(TaxableIncome >= Convert.ToDecimal(24000))
            {
                payableTax += Convert.ToDecimal(0.1 * 24000);
                TaxableIncome -= 24000;
            }
            if (TaxableIncome > Convert.ToDecimal(24000))
            {
                payableTax += Convert.ToDecimal(0.25 * 8333);
                TaxableIncome -= 8333;
            }
            if(TaxableIncome > Convert.ToDecimal(32333))
            {
                payableTax += Convert.ToDecimal(0.3) * TaxableIncome;
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
            var totalDeductions = TotalDeductions(pensionContribution, mortgageInterest);
            var taxableIncome = TaxableIncome(grossPay, pensionContribution, mortgageInterest);
            var tax = Tax(taxableIncome, PremiumPaid, insuranceRelief);

            var table = new ConsoleTable("Name", "Amount (Ksh)");
            table.AddRow("Gross Income", grossPay)
                 .AddRow("Pension Contribution", pensionContribution)
                 .AddRow("Mortgage Interest", mortgageInterest)
                 .AddRow("Total Deductions", totalDeductions)
                 .AddRow("Taxable Income", taxableIncome)
                 .AddRow("Personal Relief", personalRelief)
                 .AddRow("Insurance Relies", insuranceRelief)
                 .AddRow("PAYE", tax);

            table.Write();

            Console.WriteLine("press 1 to restart.press 2 end");
            ConsoleKeyInfo ch;
            ch = Console.ReadKey();
            if (ch.Key == ConsoleKey.NumPad2)
            {
                Environment.Exit(0);
            }
            else if (ch.Key == ConsoleKey.NumPad1)
            {
                Console.WriteLine("Error");
                
            }
                
        }
    }
}
