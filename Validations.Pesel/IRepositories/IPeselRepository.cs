using System;
namespace Validations.Pesel.IRepositories;

public interface IPeselRepository
{
    bool PeselIsValid(string pesel);
}

