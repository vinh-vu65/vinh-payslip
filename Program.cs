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
        bool nameIsValid = false;
        bool salaryIsValid = false;
        bool superIsValid = false;
        bool payPeriodIsValid = false;
        
        Console.WriteLine("Welcome to the payslip generator! \n");
        
        do
        {
            Console.Write("Please enter your first name: ");
            userFirstname = Console.ReadLine();
            nameIsValid = ValidateName(userFirstname);
        } while (!nameIsValid);
        
        do
        {
            Console.Write("Please enter your surname: ");
            userSurname = Console.ReadLine();
            nameIsValid = ValidateName(userSurname);
        } while (!nameIsValid);

        while (!salaryIsValid) 
        {
            Console.Write("Please enter your annual salary: ");
            Double.TryParse(Console.ReadLine(), out yearlyIncome);
            salaryIsValid = ValidateSalary(yearlyIncome);
        }
        
        while (!superIsValid)
        {
            Console.Write("Please enter your super rate (%): ");
            bool superValidate = Double.TryParse(Console.ReadLine(), out superRate);
            if (superValidate)
            {
                superIsValid = ValidateSuper(superRate);
            } else
                Console.WriteLine("-- Please enter a number between 0 and 50 -- \n");
        }
        
        while (!payPeriodIsValid)
        {
            Console.Write("Please enter pay period month as a number (1-12): ");
            Int32.TryParse(Console.ReadLine(), out payPeriod);
            payPeriodIsValid = ValidatePayPeriod(payPeriod);
        }
        
        User u = new User(userFirstname, userSurname, yearlyIncome, superRate);
        TaxCalculator t = new TaxCalculator(yearlyIncome, superRate);
        Payslip p = new Payslip(u, t, payPeriod);
        p.DetermineMonth(payPeriod);
        p.DisplayPayslip();
    }

    public static bool ValidateName(string userInput)
    {
        if (!String.IsNullOrWhiteSpace(userInput))
            {
                return true;
            } else 
                Console.WriteLine("-- Name field cannot be empty -- \n");
                return false;
    }

    public static bool ValidateSalary(double salary)
    {
        if (salary > 0) 
            {
                return true;
            } else
                Console.WriteLine("-- Please enter a number greater than zero -- \n");
                return false;
    }

    public static bool ValidateSuper(double super)
    {
        if (super >= 0 && super <= 50)
            {
                return true;
            } else
                Console.WriteLine("-- Please enter a number between 0 and 50 -- \n");
                return false;
    }

    public static bool ValidatePayPeriod(int month)
    {
        if (month >= 1 && month <= 12)
            {
                return true;
            } else
                Console.WriteLine("-- Please enter a number between 1 and 12 -- \n");
                return false;
    }
}