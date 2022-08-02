using System;
using System.ComponentModel.DataAnnotations;

namespace Validations.Client.Models;

public class NipTaskModel
{
    [Required(ErrorMessage = "Aby kontytuować wpisz Nip")]
    [MinLength(10, ErrorMessage = "Nip musi mieć 10 cyfr")]
    [MaxLength(10, ErrorMessage = "Nip nie może mieć więcej niż 10 cyfr")]
    public string? Nip { get; set; }
}


