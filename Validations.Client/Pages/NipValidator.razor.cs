
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Validations.Client.IRepository;
using Validations.Client.Models;
using Validations.Client.Repository;

namespace Validations.Client.Pages
{
    public partial class NipValidator
    {
        [Inject]
        public INipHttpRepository? _nipHttpRepository { get; set; }

        public string? Title { get; set; }
        public bool EditFormIsVisible { get; set; } = false;
        public NipVM? NipVM { get; set; }
        public NipTaskModel? NipTaskModel { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Title = "Sprawdź NIP";
            NipTaskModel = new();
            EditFormIsVisible = true;
        }


        private async Task CheckNipIsValid()
        {
            NipVM = await _nipHttpRepository.CheckNip(NipTaskModel.Nip);
            var i = 1;
        }
    }
}

