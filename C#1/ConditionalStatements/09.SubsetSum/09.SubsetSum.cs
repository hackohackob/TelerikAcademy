using System;

//We are given 5 integer numbers. 
//Write a program that checks if the sum of some subset of them is 0.
class SubsetSum
{
    static void Main()
    {
        int sum = 0, br = 0;
        int[] nums= new int[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Input {0} number:",i+1);             //Inputting the numbers into array 
            nums[i] = int.Parse(Console.ReadLine());
        }
                                        //We can represent the subset by using binary numbers: 01001 - subset of 2nd and 5th number 10101-subset of 1st 3rd and 5th number 
        for (int i = 1; i < 32; i++)    //Using a "for" operator to cycle trough all the posible subsets (from 00001 to 11111 which in decimal is from 1 to 32)
        {
            sum = 0;                    
            for (int j = 0; j < 5; j++) //Using a second "for" operator to cycle trough all the numbers in the array
            {
                sum = sum + ((i >> j) & 1) * nums[j]; //If the binary number is 1 we add the corresponding number from the array to the sum
            }
            if (sum==0)                               //If the sum is 0 this means that the sum of the checked subset equals 0 and we add 1 to "br" to count the subsets
            {
                br++;
            }
        }
        if(br==1)                                     //If "br"=1 there is only 1 subset sum which is 0 
        {
            Console.WriteLine("There is 1 subset that sum is 0");
        }
        else if (br > 1)                              //If the "br">1 there are more than 1 subsets and we print their count on  the console
        {
            Console.WriteLine("There are {0} subsets that sum is 0",br);
        }
        else                                          //In the other cases "br"=0 so there is no subset sum that equals 0
        {
            Console.WriteLine("There is no subset that sum is 0");  
        }

    }
}