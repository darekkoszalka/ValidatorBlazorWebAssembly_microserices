using System;
using Validations.Client.IRepository;
using Validations.Client.Models;

namespace Validations.Client.Repository;

public class NipHttpRepository : INipHttpRepository
{
    private readonly HttpClient _httpClient;

    public NipHttpRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<NipVM> CheckNip(string? nip)
    {
        var response = await _httpClient.GetAsync($"/gateway/nip/{nip}");
        NipVM nipVM = new() { Nip = nip };

        if(response.IsSuccessStatusCode)
        {
            nipVM.NipIsValid = true;
            nipVM.Message = "Nip jest prawidłowy";

            return nipVM;
        }
        else
        {
            nipVM.NipIsValid = false;
            nipVM.Message = "Nip jest nieprawidłowy";

            return nipVM;
        }

    }
}

