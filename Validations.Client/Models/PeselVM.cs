using System;
namespace Validations.Client.Models;

public class PeselVM
{
    public bool PeselIsValid { get; set; }
    public string? Pesel { get; set; }
    public string? Gender { get; set; }
    public string? Year { get; set; }
    public string? Month { get; set; }
    public string? Day { get; set; }
    public string? Message { get; set; }
}

