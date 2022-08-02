using System;
using System.Text.Json;
using Validations.Client.IRepository;
using Validations.Client.Models;

namespace Validations.Client.Repository;

public class PeselHttpRepository : IPeselHttpRepository
{

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public PeselHttpRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<PeselVM> GetAllPeselData(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/allpeseldata/{pesel}");
        var content = await response.Content.ReadAsStringAsync();
        PeselVM peselVM;
        if (!response.IsSuccessStatusCode)
        {
            peselVM = new()
            {
                Message = "Pesel jest nieprawidłowy",
                PeselIsValid = false
            };
            return peselVM;

        }
        peselVM = JsonSerializer.Deserialize<PeselVM>(content, _jsonSerializerOptions);
        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;

        return peselVM;
    }

    public async Task<PeselVM> GetDayOfBirth(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/getdayofbirth/{pesel}");
        var content = await response.Content.ReadAsStringAsync();
        PeselVM peselVM = new();
        if (!response.IsSuccessStatusCode)
        {
            peselVM.Message = "Pesel jest nieprawidłowy";
            peselVM.PeselIsValid = false;

            return peselVM;
        }

        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;
        peselVM.Day = content;

        return peselVM;

    }

    public async Task<PeselVM> GetGender(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/getgender/{pesel}");
        var content = await response.Content.ReadAsStringAsync();
        PeselVM peselVM = new();
        if (!response.IsSuccessStatusCode)
        {
            peselVM.Message = "Pesel jest nieprawidłowy";
            peselVM.PeselIsValid = false;

            return peselVM;
        }

        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;
        peselVM.Gender = content;

        return peselVM;
    }

    public async Task<PeselVM> GetMonthOfBirth(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/getmonthofbirth/{pesel}");
        var content = await response.Content.ReadAsStringAsync();
        PeselVM peselVM = new();
        if (!response.IsSuccessStatusCode)
        {
            peselVM.Message = "Pesel jest nieprawidłowy";
            peselVM.PeselIsValid = false;

            return peselVM;
        }

        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;
        peselVM.Month = content;

        return peselVM;
    }

    public async Task<PeselVM> GetYearOfBirth(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/getyearofbirth/{pesel}");
        var content = await response.Content.ReadAsStringAsync();
        PeselVM peselVM = new();
        if (!response.IsSuccessStatusCode)
        {
            peselVM.Message = "Pesel jest nieprawidłowy";
            peselVM.PeselIsValid = false;

            return peselVM;
        }

        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;
        peselVM.Year = content;

        return peselVM;
    }

    public async Task<PeselVM> PeselIsValid(string pesel)
    {
        var response = await _httpClient.GetAsync($"gateway/pesel/peselisvalid/{pesel}");
        PeselVM peselVM = new();
        if (!response.IsSuccessStatusCode)
        {
            peselVM.Message = "Pesel jest nieprawidłowy";
            peselVM.PeselIsValid = false;

            return peselVM;
        }

        peselVM.Message = "Pesel jest prawidłowy";
        peselVM.PeselIsValid = true;
        return peselVM;

    }
    
}

