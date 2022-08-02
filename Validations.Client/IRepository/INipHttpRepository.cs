using System;
using Validations.Client.Models;

namespace Validations.Client.IRepository
{
    public interface INipHttpRepository
    {
        Task<NipVM> CheckNip(string? nip);
    }
}

