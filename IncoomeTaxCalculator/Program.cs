using ConsoleTables;
using System;

namespace IncoomeTaxCalculator
{
    class Program
    {
        
        static string Userchoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Write 'Continue' to enter new data for calculation. Write 'Exit' or 'Cancel' to terminate the calculation");
            Console.ForegroundColor = ConsoleColor.White;            
            string input = Console.ReadLine();
            string choice = input.ToUpper();
            if (choice == "CONTINUE")
            {
                Console.Clear();
            }
            else if (choice == "EXIT" || choice == "CANCEL")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Userchoice();
            }
            return choice;
        }
        static void Main(string[] args)
        {
            string choice;
            _Tax user = new _Tax();
            do
            {
                user.PersonalRelief = Convert.ToDecimal(2400);

                Console.Write("Enter the gross pay: ");
                user.GrossPay = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter the NSSF Contribution / Pension amount: ");
                user.PensionContribution = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter the Interest on Mortgage paid amount: ");
                user.MortgageInterest = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter the Insurance Premium paid amount: ");
                user.PremiumPaid = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine();

                decimal insuranceRelief = Convert.ToDecimal(0.15) * user.PremiumPaid;
                var totalDeductions = user.TotalDeductions(user.PensionContribution, user.MortgageInterest);
                var taxableIncome = user.TaxableIncome(user.GrossPay, user.PensionContribution, user.MortgageInterest);
                var tax = user.Tax(taxableIncome, insuranceRelief);

                var table = new ConsoleTable("Name", "Amount (Ksh)");
                table.AddRow("Gross Income", user.GrossPay)
                     .AddRow("Pension Contribution", user.PensionContribution)
                     .AddRow("Mortgage Interest", user.MortgageInterest)
                     .AddRow("Total Deductions", totalDeductions)
                     .AddRow("Taxable Income", taxableIncome)
                     .AddRow("Personal Relief", user.PersonalRelief)
                     .AddRow("Insurance Relies", insuranceRelief)
                     .AddRow("PAYE", tax);

                table.Write();

                choice = Userchoice();
            } while (choice == "CONTINUE");                               
        }
    }
}
