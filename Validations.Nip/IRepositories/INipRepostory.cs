using System;
namespace Validations.Nip.IRepositories;

public interface INipRepostory
{
    bool NipIsValid(string? nip);
}

