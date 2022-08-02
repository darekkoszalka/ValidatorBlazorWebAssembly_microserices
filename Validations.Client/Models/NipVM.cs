using System;
namespace Validations.Client.Models;

public class NipVM
{
    public bool NipIsValid { get; set; }
    public string? Nip { get; set; }
    public string? Message { get; set; }
}

