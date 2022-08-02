using System;
using Validations.Client.Models;

namespace Validations.Client.IRepository;

public interface IPeselHttpRepository
{
    Task<PeselVM> GetAllPeselData(string pesel);
    Task<PeselVM> PeselIsValid(string pesel);
    Task<PeselVM> GetGender(string pesel);
    Task<PeselVM> GetYearOfBirth(string pesel);
    Task<PeselVM> GetMonthOfBirth(string pesel);
    Task<PeselVM> GetDayOfBirth(string pesel);
}

