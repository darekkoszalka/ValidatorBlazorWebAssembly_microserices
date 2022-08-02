using System;
namespace Validations.Pesel.Validations;

public static class PeselUtility
{
    public static string Gender(string pesel)
    {
        int number = (int)pesel[9];

        string gender = (number % 2) switch
        {
            0 => "Kobieta",
            _ => "Mężczyzna"
        };

        return gender;

    }

    public static string GetYearOfDateOfBirth(string pesel)
    {
        string year = pesel.Substring(0, 2);

        var thirdChar = pesel[2];

        string fullYear = thirdChar switch
        {
            '2' => "20" + year,
            '3' => "20" + year,
            '4' => "21" + year,
            '5' => "21" + year,
            '6' => "22" + year,
            '7' => "22" + year,
            '8' => "18" + year,
            '9' => "18" + year,
            _ => "19" + year

        };

        return fullYear;
    }

    public static string GetMonthOfDateOfBirth(string pesel)
    {
        string fourthChar = pesel[3].ToString();

        int thirdChar = (int)pesel[2];
        string fullMonth = "";

        if (thirdChar % 2 == 0)
        {
            return fullMonth = "0" + fourthChar;
        }
        else return fullMonth = "1" + fourthChar;

    }

    public static string GetDayOfDateOfBirth(string pesel)
    {
        return pesel.Substring(4, 2);
    }
}

