using System;
namespace Validations.Pesel.Validations;

public static class PeselValidator
{
    public static bool PeselIsValid(string pesel)
    {
        var result = false;
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        if (pesel != null && pesel.Length == 11)
        {
            int controlSum = CalculateControlSum(pesel, weights);
            int controlNum = controlSum % 10;
            controlNum = 10 - controlNum;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(pesel[pesel.Length - 1].ToString());
            result = controlNum == lastDigit;
        }

        return result;
    }

    private static int CalculateControlSum(string pesel, int[] weights, int offset = 0)
    {
        int controlSum = 0;
        for (int i = 0; i < pesel.Length - 1; i++)
        {
            controlSum += weights[i + offset] * int.Parse(pesel[i].ToString());
        }
        return controlSum;
    }
}

