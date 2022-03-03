using System;

public class TaxCalculator
{
    public double _annualSalary;
    public double monthlyGrossIncome;
    public double monthlyNetIncome;
    public double monthlyTax;
    public double monthlySuper;

    //Set variables for tax calulations.
    //Only ceiling values are set because we are only dealing with whole numbers.
    private const double taxFreeCeiling = 18200;
    private const double taxTier1Ceiling = 37000;
    private const double taxTier2Ceiling = 87000;
    private const double taxTier3Ceiling = 180000;

//Tax rates for each bracket
    private const double taxTier1Rate = 0.19;
    private const double taxTier2Rate = 0.325;
    private const double taxTier3Rate = 0.37;
    private const double taxTier4Rate = 0.45;

//Culmulative tax values for each tier
    private const double taxFromTier1 = 3572;
    private const double taxFromTier2 = 19822;
    private const double taxFromTier3 = 54232;

    public TaxCalculator (double annualSalary, double superRate)
    {
        _annualSalary = annualSalary;
        monthlyGrossIncome = CalculateMonthlyGrossIncome(_annualSalary);
        monthlyTax = CalculateMonthlyIncomeTax(_annualSalary);
        monthlyNetIncome = monthlyGrossIncome - monthlyTax;
        monthlySuper = CalculateMonthlySuper(monthlyGrossIncome, superRate);
    }

    public double CalculateMonthlyIncomeTax(double annualSalary)
    {
        double totalTax = 0;
        if (annualSalary > taxFreeCeiling && annualSalary <= taxTier1Ceiling)
        {
            totalTax = (annualSalary - taxFreeCeiling) * taxTier1Rate;
        } 
        else if (annualSalary > taxTier1Ceiling && annualSalary <= taxTier2Ceiling)
        {
            totalTax = (annualSalary - taxTier1Ceiling) * taxTier2Rate;
            totalTax += taxFromTier1;
        } 
        else if (annualSalary > taxTier2Ceiling && annualSalary <= taxTier3Ceiling)
        {
            totalTax = (annualSalary - taxTier2Ceiling) * taxTier3Rate;
            totalTax += taxFromTier2;
        } 
        else if (annualSalary > taxTier3Ceiling)
        {
            totalTax = (annualSalary - taxTier3Ceiling) * taxTier4Rate;
            totalTax += taxFromTier3;
        }

        return Math.Round(totalTax / 12, MidpointRounding.AwayFromZero);
    }

    public double CalculateMonthlySuper(double monthlyGrossIncome, double superRate)
    {
        return Math.Round((monthlyGrossIncome * superRate) / 100, MidpointRounding.AwayFromZero);
    }

    public double CalculateMonthlyGrossIncome(double annualSalary)
    {
        return Math.Round(annualSalary / 12, MidpointRounding.AwayFromZero);
    }
}