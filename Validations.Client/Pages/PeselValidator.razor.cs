using System;
using Microsoft.AspNetCore.Components;
using Validations.Client.IRepository;
using Validations.Client.Models;
using Validations.Client.StaticData;

namespace Validations.Client.Pages;

public partial class PeselValidator
{
    [Inject]
    public IPeselHttpRepository _peselHttpRepository { get; set; }
    
    public string? Title { get; set; }
    public bool EditFormIsVisible { get; set; } = false;
    public PeselTaskModel? PeselTaskModel { get; set; }
    public PeselVM? PeselVM { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Title = "Sprawdź pesel";
        PeselTaskModel = new();
        PeselTaskModel.ChoosedData = PeselCommandSD.GetAllPeselData;
        EditFormIsVisible = true;
    }

    private async Task CheckPesel()
    {

        if (PeselTaskModel.ChoosedData == PeselCommandSD.GetAllPeselData)
            await GetAllPeselData(PeselTaskModel.Pesel);

        if (PeselTaskModel.ChoosedData == PeselCommandSD.CheckPeselIsValid)
            await CheckPeselIsValid(PeselTaskModel.Pesel);

        if (PeselTaskModel.ChoosedData == PeselCommandSD.GetGender)
            await GetGender(PeselTaskModel.Pesel);

        if (PeselTaskModel.ChoosedData == PeselCommandSD.GetYearOfBirth)
            await GetYear(PeselTaskModel.Pesel);

        if (PeselTaskModel.ChoosedData == PeselCommandSD.GetMonthOfBirth)
            await GetMonth(PeselTaskModel.Pesel);

        if (PeselTaskModel.ChoosedData == PeselCommandSD.GetDayOfBirth)
            await GetDay(PeselTaskModel.Pesel);
    }

    private async Task GetAllPeselData(string pesel)
    {
        PeselVM = await _peselHttpRepository.GetAllPeselData(pesel);
    }

    private async Task CheckPeselIsValid(string pesel)
    {
        PeselVM = await _peselHttpRepository.PeselIsValid(pesel);
    }

    private async Task GetGender(string pesel)
    {
        PeselVM = await _peselHttpRepository.GetGender(pesel);
    }

    private async Task GetYear(string pesel)
    {
        PeselVM = await _peselHttpRepository.GetYearOfBirth(pesel);
    }

    private async Task GetMonth(string pesel)
    {
        PeselVM = await _peselHttpRepository.GetMonthOfBirth(pesel);
    }

    private async Task GetDay(string pesel)
    {
        PeselVM = await _peselHttpRepository.GetDayOfBirth(pesel);
    }
}

