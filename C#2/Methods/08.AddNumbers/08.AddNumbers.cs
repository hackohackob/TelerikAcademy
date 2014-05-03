using System;

//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

class PositiveIntegers
{
    static void Main(string[] args)
    {
        int[] number1 = {6,3,2,6,1,2,4};
        int[] number2 = {4,1,2,2,4};
        int[] added = Add(number1, number2);

        for (int i = added.Length - 1; i >= 0; i--)
        {
            Console.Write(added[i]);
        }
        Console.WriteLine();
    }

    static int[] Add(int[] number1, int[] number2)
    {
        int maxLength = Math.Max(number1.Length, number2.Length) ;
        int minLength = Math.Min(number1.Length, number2.Length);
        int[] added = new int[maxLength + 1];
        int carry = 0;

        for (int i = 0; i < minLength; i++)
        {
            added[i] = (number1[i] + number2[i] + carry) % 10;
            if (number1[i] + number2[i] + carry >= 10)
            {
                carry = 1;
            }
            else
            {
                carry = 0;
            }
        }

        if (number1.Length >= number2.Length)
        {
            for (int i = number2.Length; i < number1.Length; i++)
            {
                added[i] = number1[i] + carry;
                if (number1[i] + carry >= 10)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }
        }
        else
        {
            for (int i = number1.Length; i < number2.Length; i++)
            {
                added[i] = number2[i] + carry;
                if (number2[i] + carry >= 10)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }
        }
        if (carry == 0)
        {
            Array.Resize(ref added, added.Length - 1);
        }
        else
        {
            added[added.Length - 1] += carry;
        }

        return added;
    }


}