using System;

public class Payslip
{
    public User u;
    public TaxCalculator t;
    public string _payPeriod;
    public string monthEndDate;

    public Payslip (User user, TaxCalculator TC, string payPeriod)
    {
        u = user;
        t = TC;
        _payPeriod = payPeriod;
        monthEndDate = DetermineMonthEndDate(payPeriod);

    }

    public string DetermineMonthEndDate (string s)
    {
        if (s.ToLower() == "january" || s.ToLower() == "march" || s.ToLower() == "may" || s.ToLower() == "july" || s.ToLower() == "august" || s.ToLower() == "october" || s.ToLower() == "december")
        {
            return "31";
        } else if (s.ToLower() == "april" || s.ToLower() == "june" || s.ToLower() == "september" || s.ToLower() == "november")
        {
            return "30";
        } else if (s.ToLower() == "february")
        {
            return "28";
        } else return "null";
        // TODO: error handling if month input isunexpected
    }

    public void DisplayPayslip ()
    {
        Console.WriteLine("\n Your payslip has been generated: \n");
        Console.WriteLine($"Name: {u._userFirstname} {u._userSurname}");
        Console.WriteLine($"Pay period: 01 {_payPeriod} -- {monthEndDate} {_payPeriod}");
        Console.WriteLine($"Gross Income: {t.monthlyGrossIncome}");
        Console.WriteLine($"Income Tax: {t.monthlyTax}");
        Console.WriteLine($"Net Income: {t.monthlyNetIncome}");
        Console.WriteLine($"Super: {t.monthlySuper}");
        Console.WriteLine("\n Thank you for using MYOB!");
    }
}