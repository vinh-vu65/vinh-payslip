using System;

public class Payslip
{
    public User u;
    public TaxCalculator t;
    public int _payPeriod;
    public string? monthEndDate;
    public string? payslipMonth;

    public Payslip (User user, TaxCalculator TC, int payPeriod)
    {
        u = user;
        t = TC;
        _payPeriod = payPeriod;
    }

    public void DetermineMonth (int s)
    {
        switch (s)
        {
            case 1:
            monthEndDate = "31";
            payslipMonth = "January";
            break;

            case 2:
            monthEndDate = "28";
            payslipMonth = "February";
            break;

            case 3:
            monthEndDate = "31";
            payslipMonth = "March";
            break;

            case 4:
            monthEndDate = "30";
            payslipMonth = "April";
            break;

            case 5:
            monthEndDate = "31";
            payslipMonth = "May";
            break;

            case 6:
            monthEndDate = "30";
            payslipMonth = "June";
            break;

            case 7:
            monthEndDate = "31";
            payslipMonth = "July";
            break;

            case 8:
            monthEndDate = "31";
            payslipMonth = "August";
            break;

            case 9:
            monthEndDate = "30";
            payslipMonth = "September";
            break;

            case 10:
            monthEndDate = "31";
            payslipMonth = "October";
            break;

            case 11:
            monthEndDate = "30";
            payslipMonth = "November";
            break;

            case 12:
            monthEndDate = "31";
            payslipMonth = "December";
            break;
        }
    }

    public void DisplayPayslip ()
    {
        Console.WriteLine("\n Your payslip has been generated: \n");
        Console.WriteLine($"Name: {u._userFirstname} {u._userSurname}");
        Console.WriteLine($"Pay period: 01 {payslipMonth} -- {monthEndDate} {payslipMonth}");
        Console.WriteLine($"Gross Income: {t.monthlyGrossIncome}");
        Console.WriteLine($"Income Tax: {t.monthlyTax}");
        Console.WriteLine($"Net Income: {t.monthlyNetIncome}");
        Console.WriteLine($"Super: {t.monthlySuper}");
        Console.WriteLine("\n Thank you for using MYOB!");
    }
}