using System;

class Program
{
    public void PrintStatistics(double[] array, int length)
    {
        PrintHandler.PrintMax(Max(array, length));
        PrintHandler.PrintMin(Min(array, length));

        PrintHandler.PrintAvg(Sum(array, length) / length);
    }

    private double Sum(double[] array, int length)
    {
        double sum = 0;
        for (int i = 0; i < length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    private double Min(double[] array, int length)
    {
        double min = array[0];
        for (int i = 0; i < length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        return min;
    }

    private double Max(double[] array, int length)
    {
        double max = array[0];


        for (int i = 0; i < length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

}

class PrintHandler
{
    internal static void PrintAvg(double avg)
    {
        throw new NotImplementedException();
    }

    internal static void PrintMin(double min)
    {
        throw new NotImplementedException();
    }

    internal static void PrintMax(double max)
    {
        throw new NotImplementedException();
    }
}