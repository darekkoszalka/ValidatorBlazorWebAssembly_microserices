using System;
namespace Validations.Pesel.IRepositories
{
    public interface IPeselUtilityRepository
    {
        string GetGender(string pesel);
        string GetYearOfDateOfBirth(string pesel);
        string GetMonthOfDateOfBirth(string pesel);
        string GetDayOfDateOfBirth(string pesel);
    }
}

