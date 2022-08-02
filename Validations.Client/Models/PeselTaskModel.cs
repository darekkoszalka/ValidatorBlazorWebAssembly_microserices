using System;
using System.ComponentModel.DataAnnotations;

namespace Validations.Client.Models;

public class PeselTaskModel
{
    [Required(ErrorMessage = "Aby kontytuować wpisz pesel")]
    [MinLength(11, ErrorMessage ="Pesel musi mieć 11 cyfr")]
    [MaxLength(11, ErrorMessage ="Pesel nie może mieć więcej niż jedenaście cyfr")]
    public string? Pesel { get; set; }
    public string? ChoosedData { get; set; }
    


}

