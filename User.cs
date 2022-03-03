using System;

public class User 
{
    public string _userFirstname;
    public string _userSurname;
    public double _annualSalary;
    public double _superRate;

    public User(string userFirstame, string userSurname, double annualSalary, double superRate)
    {
        _userFirstname = userFirstame;
        _userSurname = userSurname;
        _annualSalary = annualSalary;
        _superRate = superRate;
    }
}