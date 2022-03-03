using System.Transactions;
using System;

public class Program
{    public static void Main(string[] args)
    {
        string userFirstname = "";
        string userSurname = "";
        double yearlyIncome = 0;
        double superRate = 0;
        int payPeriod = 0;
        bool firstnameIsValid = false;
        bool surnameIsValid = false;
        bool salaryIsValid = false;
        bool superIsValid = false;
        bool payPeriodIsValid = false;
        
        Console.WriteLine("Welcome to the payslip generator! \n");
        
        while (!firstnameIsValid)
        {
            Console.Write("Please enter your first name: ");
            userFirstname = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(userFirstname))
            {
                firstnameIsValid = true;
            } else 
                Console.WriteLine("First name field cannot be empty.");
        }
        
        while (!surnameIsValid)
        {
            Console.Write("Please enter your surname: ");
            userSurname = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(userSurname))
            {
                surnameIsValid = true;
            } else 
                Console.WriteLine("Surname field cannot be empty.");
        }

        while (!salaryIsValid) 
        {
            Console.Write("Please enter your annual salary: ");
            Double.TryParse(Console.ReadLine(), out yearlyIncome);
            if (yearlyIncome > 0) 
            {
                salaryIsValid = true;
            } else
                Console.WriteLine("Please enter a number greater than zero.");
        }
        
        while (!superIsValid)
        {
            Console.Write("Please enter your super rate (%): ");
            bool superValidate = Double.TryParse(Console.ReadLine(), out superRate);
            if (superRate >= 0 && superRate <= 50 && (superValidate))
            {
                superIsValid = true;
            } else
                Console.WriteLine("Please enter a number between 0 and 50.");
        }
        
        while (!payPeriodIsValid)
        {
            Console.Write("Please enter pay period month as a number (1-12): ");
            Int32.TryParse(Console.ReadLine(), out payPeriod);
            if (payPeriod >= 1 && payPeriod <= 12)
            {
                payPeriodIsValid = true;
            } else
                Console.WriteLine("Please enter a number between 1 and 12.");
        }
        
        User u = new User(userFirstname, userSurname, yearlyIncome, superRate);
        TaxCalculator t = new TaxCalculator(yearlyIncome, superRate);
        Payslip p = new Payslip(u, t, payPeriod);
        p.DetermineMonth(payPeriod);
        p.DisplayPayslip();
    }
}