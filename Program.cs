using System.Transactions;
using System;

public class Program
{    public static void Main(string[] args)
    {
        string userFirstname, userSurname, startDate, endDate;
        double yearlyIncome, monthlyGrossIncome, totalTax, monthlyTax, monthlyNetIncome, superRate, monthlySuper;
        
        Console.WriteLine("Welcome to the payslip generator! \n");
        Console.Write("Please enter your name: ");
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

        monthlyGrossIncome = Math.Round(yearlyIncome / 12, MidpointRounding.AwayFromZero);
        
        totalTax = 0;
        if (yearlyIncome >= 18201 && yearlyIncome <= 37000)
        {
            totalTax = (yearlyIncome - 18200) * 0.19;
        } else if (yearlyIncome >= 37001 && yearlyIncome <= 87000)
        {
            totalTax = (yearlyIncome - 37000) * 0.325;
            totalTax += 3572;
        } else if (yearlyIncome >=87001 && yearlyIncome <= 180000)
        {
            totalTax = (yearlyIncome - 87000) * 0.37;
            totalTax += 19822;
        } else if (yearlyIncome >= 180001)
        {
            totalTax = (yearlyIncome - 180000) * 0.45;
            totalTax += 54232;
        }

        monthlyTax = Math.Round(totalTax / 12, MidpointRounding.AwayFromZero);
        monthlyNetIncome = monthlyGrossIncome - monthlyTax;
        monthlySuper = Math.Round((monthlyGrossIncome * superRate) / 100, MidpointRounding.AwayFromZero);

        Console.WriteLine("\n Your payslip has been generated: \n");
        Console.WriteLine($"Name: {userFirstname} {userSurname}");
        Console.WriteLine($"Pay period: {startDate} -- {endDate}");
        Console.WriteLine($"Gross Income: {monthlyGrossIncome}");
        Console.WriteLine($"Income Tax: {monthlyTax}");
        Console.WriteLine($"Net Income: {monthlyNetIncome}");
        Console.WriteLine($"Super: {monthlySuper}");
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