using System;
using Validations.Pesel.IRepositories;

namespace Validations.Pesel.Repositories;

public class PeselRepository : IPeselRepository
{
    public bool PeselIsValid(string pesel)
    {
        var result = false;

        if(pesel is not null && pesel.Length.Equals(11))
        {
            result = PeselLastDigit(pesel) == PeselControlNumber(pesel);
        }

        return result;
    }

    public static int PeselControlSum(string pesel, int offset = 0)
    {
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int controlSum = 0;
        for (int i = 0; i < pesel.Length - 1; i++)
        {
            controlSum += weights[i + offset] * int.Parse(pesel[i].ToString());
        }
        return controlSum;
    }

    public static int PeselLastDigit(string pesel)
    {
        return int.Parse(pesel[10].ToString());
    }

    public static int PeselControlNumber(string pesel)
    {
        int controlSum = PeselControlSum(pesel);
        int controlNum = controlSum % 10;
        controlNum = 10 - controlNum;
        if (controlNum == 10)
        {
            controlNum = 0;
        }
        return controlNum;
    }
}

