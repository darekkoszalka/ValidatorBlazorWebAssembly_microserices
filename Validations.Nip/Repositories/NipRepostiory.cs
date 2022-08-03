using System;
using Validations.Nip.IRepositories;

namespace Validations.Nip.Repositories;

public class NipRepostiory : INipRepostory
{
    public bool NipIsValid(string? nip)
    {
        var result = false;
       if(nip is not null && nip.Length.Equals(10))
        {
            result = LastDigit(nip) == NipControlNumber(nip);
        }
        return result;
    }

    public int CalculateControlSum(string nip, int offset = 0)
    {
        int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        int controlSum = 0;
        for (int i = 0; i < nip.Length - 1; i++)
        {
            controlSum += weights[i + offset] * int.Parse(nip[i].ToString());
        }
        return controlSum;
    }

    public int LastDigit(string nip)
    {
        return int.Parse(nip[9].ToString());
    }

    public int NipControlNumber(string nip)
    {
        int controlSum = CalculateControlSum(nip);
        int controlNum = controlSum % 11;

        if (controlNum == 10)
        {
            controlNum = 0;
        }

        return controlNum;
    }
}

