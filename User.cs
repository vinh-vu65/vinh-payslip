using System;

public class User 
{
    private string _userFirstname;
    private string _userSurname;
    private double _annualSalary;
    private double _superRate;

    public User(string userFirstame, string userSurname, double annualSalary, double superRate)
    {
        _userFirstname = userFirstame;
        _userSurname = userSurname;
        _annualSalary = annualSalary;
        _superRate = superRate;
    }

}