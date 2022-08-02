using System;
namespace Validations.Nip.Validations;

public class NipValidator
{
    public static bool NipIsValid(string nip)
    {
        var result = false;
        int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };

        if (nip is not null && nip.Length == 10)
        {
            int controlSum = CalculateControlSum(nip, weights);
            int controlNum = controlSum % 11;
            //controlNum = 10 - controlNum;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(nip[nip.Length - 1].ToString());
            result = controlNum == lastDigit;
        }
        return result;
    }

    private static int CalculateControlSum(string nip, int[] weights, int offset = 0)
    {
        int controlSum = 0;
        for (int i = 0; i < nip.Length - 1; i++)
        {
            controlSum += weights[i + offset] * int.Parse(nip[i].ToString());
            Console.WriteLine(controlSum);
        }
        return controlSum;
    }
}

