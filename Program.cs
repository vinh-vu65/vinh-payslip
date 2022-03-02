using System.Transactions;
using System;

public class Program
{    public static void Main(string[] args)
    {
        string userFirstname, userSurname, startDate, endDate;
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
        

        Console.Write("Please enter your payment start date: ");
        startDate = Console.ReadLine();

        Console.Write("Please enter your payment end date: ");
        endDate = Console.ReadLine();

        User u = new User(userFirstname, userSurname, yearlyIncome, superRate);
        TaxCalculator t = new TaxCalculator(yearlyIncome, superRate);
        
        
        //monthlyGrossIncome = Math.Round(yearlyIncome / 12, MidpointRounding.AwayFromZero);
        
        
        

        //monthlyTax = Math.Round(totalTax / 12, MidpointRounding.AwayFromZero);
        //monthlyNetIncome = monthlyGrossIncome - monthlyTax;
        //monthlySuper = Math.Round((monthlyGrossIncome * superRate) / 100, MidpointRounding.AwayFromZero);

        Console.WriteLine("\n Your payslip has been generated: \n");
        Console.WriteLine($"Name: {u._userFirstname} {u._userSurname}");
        Console.WriteLine($"Pay period: {startDate} -- {endDate}");
        Console.WriteLine($"Gross Income: {t.monthlyGrossIncome}");
        Console.WriteLine($"Income Tax: {t.monthlyTax}");
        Console.WriteLine($"Net Income: {t.monthlyNetIncome}");
        Console.WriteLine($"Super: {t.monthlySuper}");
        Console.WriteLine("\n Thank you for using MYOB!");
    }
}





/* TODO: Seperate into classes:
User class
    Constructor: first name + last name
    properties: 
    - First name
    - Last name
    - Annual Salary
    - Super rate

Tax Calc Class
    properties:
    - Annual salary (put in as constructor parameter?)
    - Monthly Gross salary
    - Annual Tax
    - Monthly Tax
    - Net Monthly income
    - Super amount (?maybe group with payslip class)

Payslip class
    Properties:
    - Inherit user details (ie. Name)  user = contructor parameter?
    - Calendar month for pay period (customise month end date)
    - Display Gross income, income tax and net income
    - Super
*/