using System;

class ComparingArrays
{
    static void Main()
    {
        Console.Write("Input the lenght of the arrays:");
        int n = int.Parse(Console.ReadLine());              //asking the user for the lenght of the arrays

        int[] firstArray = new int[n];                      //defining the arrays
        int[] secondArray = new int[n];

        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("Input number with index {0} from first array:",i);   //inputting the first array
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.Write("Input number with index {0} from second array:",i);  //inputting the second array
            secondArray[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("Comparing arrays");

        for (int i = 0; i < firstArray.Length; i++)                             //Cycling trough all of the numbers
        {
            if(firstArray[i]>secondArray[i])                                    //checking if the number from the first array is bigger
            {
                Console.WriteLine("The number with index {0} from the FIRST array is bigger.", i);
            }
            else if(secondArray[i]>firstArray[i])                               //checking if the number from the second array is bigger
            {
                Console.WriteLine("The number with index {0} from the SECOND array is bigger.", i);
            }
            else                                                                //in other case the numbers are equal
            {
                Console.WriteLine("The numbers with index {0} from both arrays are equal",i);
            }
        }
    }
}