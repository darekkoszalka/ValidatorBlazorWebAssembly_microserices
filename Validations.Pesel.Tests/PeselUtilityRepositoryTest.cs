using System;
using Validations.Pesel.Repositories;

namespace Validations.Pesel.Tests;

public class PeselUtilityRepositoryTest
{
    [Theory]
    [InlineData("80071323237", "Mężczyzna")]
    [InlineData("98011774179", "Mężczyzna")]
    [InlineData("52081554321", "Kobieta")]
    [InlineData("65091696323", "Kobieta")]
    public void GetGender_ReturnCorrectGender(string pesel, string gender)
    {
        //arrange
        PeselUtilityRepository repository = new();

        //act
        var result = repository.GetGender(pesel);

        //assert
        Assert.Equal(gender,result);
    }

    [Theory]
    [InlineData("72052842567", "1972")]
    [InlineData("72111148755", "1972")]
    [InlineData("07232668653", "2007")]
    [InlineData("07272672494", "2007")]
    public void GeGetYearOfDateOfBirthTest_ReturnCorrectYear(string pesel, string year)
    {
        //arrange
        PeselUtilityRepository repository = new();
        //act
        var result = repository.GetYearOfDateOfBirth(pesel);

        //assert
        Assert.Equal(year, result);
    }

    [Theory]
    [InlineData("07211082384", "01")]
    [InlineData("07212369255", "01")]
    public void GetMonthOfDateOfBirthTest_ReturnCorrectMonth(string pesel, string month)
    {
        //arrange
        PeselUtilityRepository repository = new();
        //act
        var result = repository.GetMonthOfDateOfBirth(pesel);

        //assert
        Assert.Equal(month, result);
    }

    [Theory]
    [InlineData("07211082384", "10")]
    [InlineData("07212369255", "23")]
    public void GetDayOfDateOfBirthTest_ReturnCorrectDay(string pesel, string day)
    {
        //arrange
        PeselUtilityRepository repository = new();
        //act
        var result = repository.GetDayOfDateOfBirth(pesel);

        //assert
        Assert.Equal(day, result);
    }


}

