using System.Text;

namespace Validations.Pesel.Tests;

public class StringBuilderTests
{
    [Fact]
    public void Append_ForTwoStrings_ReturnsConcatenatedString()
    {
        //arange
        StringBuilder sb = new StringBuilder();

        //act
        sb.Append("test")
            .Append("test2");
        string result = sb.ToString();

        //asert
        Assert.Equal("testtest2", result);
    }
}
