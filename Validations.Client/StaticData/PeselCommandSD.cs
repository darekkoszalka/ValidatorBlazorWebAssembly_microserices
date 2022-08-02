using System;
namespace Validations.Client.StaticData;

public static class PeselCommandSD
{
    public static string GetAllPeselData = "Pobierz wszystkie dane z pesel";
    public static string CheckPeselIsValid = "Sprawdź tylko czy pesel jest prawidłowy";
    public static string GetGender = "Pobierz płeć";
    public static string GetYearOfBirth = "Pobierz rok urodzenia";
    public static string GetMonthOfBirth = "Pobierz miesiąc urodzenia";
    public static string GetDayOfBirth = "Pobierz dzień urodzenia";

    public static List<string> PeselCommandList = new()
    {
        GetAllPeselData, CheckPeselIsValid, GetGender, GetYearOfBirth, GetMonthOfBirth, GetDayOfBirth
    };
}


        
        