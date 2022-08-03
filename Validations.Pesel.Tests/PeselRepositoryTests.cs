using System;
using Validations.Pesel.Repositories;
using FluentAssertions;

namespace Validations.Pesel.Tests;

public class PeselRepositoryTests
{
    [Theory]
    [InlineData("74042879597", 7)]
    [InlineData("04253137481", 1)]
    public void PeselLastDigit_ReturnCorrectLastDigit(string pesel, int lastDigit)
    {
        //arrange
        //act
        var result = PeselRepository.PeselLastDigit(pesel);

        //assert
        //Assert.Equal(lastDigit, result);
        result.Should().Be(lastDigit);
    }

    [Theory]
    [InlineData("74042879597", 243)]
    [InlineData("04253137481", 189)]
    public void PeselControlSum_ReturnCorrectControlSum(string pesel, int controlSum)
    {
        //arrane
        //act
        var result = PeselRepository.PeselControlSum(pesel);

        //assert
        Assert.Equal(controlSum, result);
        //result.Should().Be(controlSum);
    }

    [Theory]
    [InlineData("74042879597", 7)]
    [InlineData("04253137481", 1)]
    public void PeselControlNumbert_ReturnCorrectControlNumber(string pesel, int controlNumber)
    {
        //arrane
        //act
        var result = PeselRepository.PeselControlNumber(pesel);

        //assert
        Assert.Equal(controlNumber, result);
    }

    [Theory]
    [InlineData("74042879597")]
    [InlineData("04253137481")]
    public void PeselIsValid_ReturnTrue(string pesel)
    {
        //arrane
        PeselRepository repository = new();

        //act
        var result = repository.PeselIsValid(pesel);

        //assert
        Assert.True(result);
    }
    
}

