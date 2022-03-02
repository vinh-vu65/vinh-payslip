using System.Transactions;
using System;

public class Program
{    public static void Main(string[] args)
    {
        string userFirstname, userSurname, payPeriod;
        double yearlyIncome, superRate;
        
        Console.WriteLine("Welcome to the payslip generator! \n");
        Console.Write("Please enter your first name: ");
        userFirstname = Console.ReadLine();

        Console.Write("Please enter your surname: ");
        userSurname = Console.ReadLine();

        try 
        {
            Console.Write("Please enter your annual salary: ");
            yearlyIncome = Convert.ToDouble(Console.ReadLine());
        }
        catch 
        {
            Console.Write("Please enter a valid number, try again: ");
            yearlyIncome = Convert.ToDouble(Console.ReadLine());
        }
        
        try
        {
            Console.Write("Please enter your super rate (%): ");
            superRate = Convert.ToDouble(Console.ReadLine());
        }
        catch 
        {
            Console.Write("Please enter a number from 0 - 100, try again: ");
            superRate = Convert.ToDouble(Console.ReadLine());
        }
        

        Console.Write("Please enter pay period month in full: ");
        payPeriod = Console.ReadLine();

        User u = new User(userFirstname, userSurname, yearlyIncome, superRate);
        TaxCalculator t = new TaxCalculator(yearlyIncome, superRate);
        Payslip p = new Payslip(u, t, payPeriod);
        p.DisplayPayslip();

    }
}
