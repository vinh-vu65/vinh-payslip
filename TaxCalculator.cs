using System;

public class TaxCalculator
{
    public double _annualSalary;
    public double monthlyGrossIncome;
    public double monthlyNetIncome;
    public double monthlyTax;
    public double monthlySuper;

    public TaxCalculator(double annualSalary, double superRate)
    {
        _annualSalary = annualSalary;
        monthlyGrossIncome = Math.Round(_annualSalary / 12, MidpointRounding.AwayFromZero);
        monthlyTax = CalculateMonthlyIncomeTax(_annualSalary);
        monthlyNetIncome = monthlyGrossIncome - monthlyTax;
        monthlySuper = Math.Round((monthlyGrossIncome * superRate) / 100, MidpointRounding.AwayFromZero);
    }

    public double CalculateMonthlyIncomeTax(double annualSalary)
    {
        double totalTax = 0;
        if (annualSalary >= 18201 && annualSalary <= 37000)
        {
            totalTax = (annualSalary - 18200) * 0.19;
        } else if (annualSalary >= 37001 && annualSalary <= 87000)
        {
            totalTax = (annualSalary - 37000) * 0.325;
            totalTax += 3572;
        } else if (annualSalary >=87001 && annualSalary <= 180000)
        {
            totalTax = (annualSalary - 87000) * 0.37;
            totalTax += 19822;
        } else if (annualSalary >= 180001)
        {
            totalTax = (annualSalary - 180000) * 0.45;
            totalTax += 54232;
        }

        return Math.Round(totalTax / 12, MidpointRounding.AwayFromZero);
    }

    public double CalculateMonthlySuper(double monthlyGrossIncome, double superRate)
    {
        return Math.Round((monthlyGrossIncome * superRate) / 100, MidpointRounding.AwayFromZero);
    }
}