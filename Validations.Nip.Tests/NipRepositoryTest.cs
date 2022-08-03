using System;
using Validations.Nip.Repositories;

namespace Validations.Nip.Tests;

public class NipRepositoryTest
{
    [Theory]
    [InlineData("6311156150", 154)]
    [InlineData("5260001884", 191)]
    public void CalculateControlSum_FromNip_ReturnCorrectCheckSum(string nip, int controlSum)
    {
        //arrange
        NipRepostiory repostiory = new();

        //act
        var result = repostiory.CalculateControlSum(nip);

        //assert
        Assert.Equal(controlSum, result);
    }

    [Theory]
    [InlineData("6311156150", 0)]
    [InlineData("5260001884", 4)]
    public void LastDigit_FromNip_ReturnCorrectLastDigitFromNip(string nip, int lastDigit)
    {
        //arrange
        NipRepostiory repostiory = new();

        //act
        var result = repostiory.LastDigit(nip);

        //assert
        Assert.Equal(lastDigit, result);
    }

    [Theory]
    [InlineData("6311156150", 0)]
    [InlineData("5260001884", 4)]
    public void NipControlNumber_FromNip_ReturnCorrectControlNumberFromNip(string nip, int controlNumber)
    {
        //arrange
        NipRepostiory repostiory = new();

        //act
        var result = repostiory.NipControlNumber(nip);

        //assert
        Assert.Equal(controlNumber, result);
    }

    [Theory]
    [InlineData("6311156150")]
    [InlineData("5260001884")]
    public void NipIsVali_ReturnTrue(string nip)
    {
        //arrange
        NipRepostiory repostiory = new();

        //act
        var result = repostiory.NipIsValid(nip);

        //assert
        Assert.True(result);
    }


}

