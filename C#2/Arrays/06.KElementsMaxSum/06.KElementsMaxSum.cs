using System;

//Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

class KElementsMaxSum
{
    //
    //There is more simple way to do this. Only by sorting the array and printing the last K elements. However I wanted to do it hard way. This does NOT mean I dont know how
    //to do it more simple!
    //
    static void Main()
    {
        Console.Write("Input N:");              //inputting N
        int N = int.Parse(Console.ReadLine());
        Console.Write("Input K:");              //inputting K
        int K = int.Parse(Console.ReadLine());
        int currentSum = 0;                     //defining a variable to put in the current sum of numbers
        int maxSum = int.MinValue;              //defining a variable to hold the maximal sum          
        int maxMask = 0;                        //see explanation below
        int[] array = new int[N];               //defining an array 

        //We need to get K elements from the array. The way to cover all the posibilities is to use bit numbers.  If we have array of 6 numbers and we're looking for the max 
        //sum of 2 numbers (N=6, K=2) we have 30 possibilities. If N=6 and K=3 we have 120 possibilities. If we take the bonary numbers from 
        // 000001 to 111111 we will cover all the possibilities. This binary number will tell us which numbers we will sum. 
        //Example: when the binary number is 000001 we take the sum of only the last number in the array. 
        //when the binary number is 100101 we will take the sum of the 1st 4th and 6th number from the array
        //with this method we cover all the posibilities with K=1, K=2, K=3...K=N
        //but we want to check the sums only if K=3, so from all the binary numbers we will take this numbers that have exactly 3 bits with value of 1
        //Example: In the presented case(N=6, K=3) some of the numbers we will take will be 000111,001011,010011,100011,101010,101100....
        //So we define a helping variable (mask) to help us choose which numbers we will count for the sum.
        //The maximum number for the mask will be 111111 in case N=6. In case N=5 the maximum binary number will be 11111. 
        //We can calculate this maximal binary number very easy. If N=6, we shift the bits of 1(000001) 6 times left and we get 1000000. We substract 1 and we get 111111.


        for (int i = 0; i < N; i++) //inputting the array
        {
            Console.Write("Input {0} element:",i+1);
            array[i] = int.Parse(Console.ReadLine());
        }

        int mask = (1 << N) - 1;    //defining the mask
        int numbersIncluded = 0;    //defining a variable to help us know how many bit have a value of 1 in the current binary number

        for (int i = 1; i <=mask; i++)  //we use for operator to cycle trough all the possibilities. In case N=1, 
        {
            numbersIncluded = 0;
            currentSum = 0;

            for (int j = 0; j < N; j++)
            {
                if(((i >> j)&1)== 1)
                {
                    numbersIncluded++;
                }
            }

            if(numbersIncluded==K)
            {

                for (int j = 0; j <N ; j++)
                {
                    currentSum =currentSum+ (((i >> j) & 1) * array[N-j-1]);
                }
                if(currentSum>maxSum)
                {
                    maxSum = currentSum;
                    maxMask = i;
                }
            }
        }

        Console.WriteLine("The maximal sum of {0} numbers is: {1}",K,maxSum);
        Console.Write("The numbers are:");
        for (int i =N-1; i >=0; i--)
        {
            if(((maxMask>>i)&1)!=0)
            {
                Console.Write(array[N-i-1]+" ");
            }
        }
        Console.WriteLine();

    }
}