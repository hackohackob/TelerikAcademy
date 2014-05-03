using System;

//Write a program that finds the maximal increasing sequence in an array.
class MaxIncreasingSequance
{
    static void Main()
    {
        Console.Write("Input the length of the array:"); 
        int n = int.Parse(Console.ReadLine());              //Inputting the length of the array
        int currentNumberSequance = 0;                      //defining a avariable to help us know which sequance we print
        int maxSequance = 0;                                //Defining a variable in which we will store the max sequance

        int[] array = new int[n];                           //Defining an array for the numbers
        int[] arraySequance = new int[n];                   //Defining an array in which we will store how many numbers after the same number in the first array are continuous

                                                            //Example: 1st array: {2,3,1,2,3,4,5} 2nd array: {1,0,4,3,2,1,0}
        for (int i = 0; i < n; i++)                         //Filling the array
        {
            Console.Write("Input {0} number:",i+1);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n-1; i++)                       //With currentNumberSequance we see check for every number, how many numbers it has after it that are continuous 
        {                           
            currentNumberSequance = 0;

            for (int j = i+1; j < n; j++)
            {
                if(array[i]==(array[j]-(j-i)))
                {
                    currentNumberSequance++;
                }
            }
            arraySequance[i] = currentNumberSequance;
            if(currentNumberSequance>maxSequance)          //We save the max continuous sequance in the variable "maxSequance"
            {
                maxSequance = currentNumberSequance;
            }
        }

        int currentPrinted = 0;                             //Defining a variable to help us know which sequance we are printing
        int numberOfSequances = 0;                          //Defining a variable to help us know how many sequances there are in the array
        for (int i = 0; i < n; i++)                         //Calculatin "numberOfSequances"
        {
            if(arraySequance[i]==maxSequance)
            {
                numberOfSequances++;
            }
        }

        if(numberOfSequances==1)                            //If numberOfSequances is 1, there is exactly 1 seqance of continuous numbers. In the variable currentPrinted we 
        {                                                   //save the index of the first number in that sequance. This is the number with maximum value of "maxSequance"
            Console.WriteLine("There is 1 sequance of {0} numbers",maxSequance+1);
            for (int i = 0; i < n; i++)
            {
                if(arraySequance[i]==maxSequance)
                {
                    currentPrinted = i;
                    break;
                }
            }

            Console.Write("The numbers are: ");             //We know the index of the first number of the sequance and how many numbers after it are continuous. So we 
            for (int i = currentPrinted; i <=currentPrinted+maxSequance; i++)                           //print them out
            {
                Console.Write(array[i]+" ");
            }
        }
        else //numberOfSequances>1 
        {                                                //If there are more than one sequances of continuous numbers and they are equal by length we should print all of them
            Console.WriteLine("There are {0} equal by length sequances with {1} numbers.",numberOfSequances,maxSequance+1); //First we print how many sequances there are 
            for (int i = 0; i < numberOfSequances; i++)//we use for operator to print out information about all the sequances                //and how many numbers they are 
            {
                currentPrinted = 0;
                Console.Write("The numbers of the {0} sequance are: ",i+1); 
                for (int j = 0; j < n; j++)
                {
                    if(arraySequance[j]==maxSequance && array[j]!=0) //From all the sequances we find wich is the first number of the first sequance
                    {
                        currentPrinted = j;
                        break;
                    }
                }

                for (int j = 0; j <=maxSequance; j++)  //we know which is the first number of the sequance and how many numbers the sequance has, so we print them
                {
                    Console.Write(array[currentPrinted+j]+" ");
                    array[currentPrinted + j] = 0;              //after that we make them equal to 0, because we have already used them and they are no longer needed
                }

                
                Console.WriteLine();
            }
        }
    }
}