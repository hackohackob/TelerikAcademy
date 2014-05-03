using System;

//Write a program that compares two char arrays lexicographically (letter by letter).

class ComparingCharArrays
{
    static void Main()
    {
        Console.Write("Input the first char array as string:"); //inputting the char array as string
        string firstArrayAsString = Console.ReadLine();
        firstArrayAsString=firstArrayAsString.ToLower();        //here we lower all the letters, so that we can compare the letters by themself, not comparing them if they 
                                                                //are capital
        Console.Write("Input the second char array as string:"); //inputting the char array as string
        string secondArrayAsString = Console.ReadLine();
        secondArrayAsString = secondArrayAsString.ToLower();    //lowering the letters again

        int firstL = firstArrayAsString.Length;                 //defininf a variable to store the first array length
        int secondL = secondArrayAsString.Length;               //defining a variable to store the second arrat length
        char[] firstArray = new char[firstL];                   //defining the two arrays
        char[] secondArray = new char[secondL];

        for (int i = 0; i < firstL; i++)                        //filling the first array with the chars from the string
        {
            firstArray[i]=firstArrayAsString[i];
        }
        for (int i = 0; i < secondL; i++)                       //filling the second array with the chars from the string
		{
            secondArray[i] = secondArrayAsString[i]; 
		}

        bool found = false;                                     //defining a variable to check if the first array is found
        int maxSymbol = Math.Min(firstArray.Length, secondArray.Length);    //defining a varibale which is the equal to the lenght of the smaller array. We will check both
                                                                            //arrays to this length
        for (int i = 0; i <maxSymbol; i++)                                  //start comparing the arrays
        {
            if (firstArray[i] == secondArray[i])                            //if the current char is equal we continue to the next one
            {
                continue;
            }
            if(firstArray[i]<secondArray[i])                                //if the current char from the first array is smaller than the current char from the second array 
            {                                                               //this means the first array is firts. We print out "First array is first" and break;
                found = true;
                Console.WriteLine("First array is first");
                break;
            }
            if (firstArray[i] > secondArray[i])                             //if the current char from the second array is smaller than the current char from the first array 
            {                                                               //this means the second array is firts. We print out "Second array is first" and break;
                found = true;
                Console.WriteLine("Second array is first");
                break;
            }

        }

        if((found==false)&&(firstArray.Length!=secondArray.Length))         //If we have not found yet the first array this means that either one of the arrays is shorter and 
        {                                                                   //and the other array is the first array + more character, or the two arrays are equal. Here we
            if (firstArray.Length<secondArray.Length)                       //check if one of the arrays is shorter and if one of them is shorter we print out that this array 
	        {                                                               //is first
		        Console.WriteLine("The first array is first");
	        }
            else if(firstArray.Length>secondArray.Length)
            {
                Console.WriteLine("The second array is first");
            }
            else
            {
                Console.WriteLine("The arrays are equal");
            }
        }
        if((found==false)&&(firstArray.Length==secondArray.Length))         //Here we check if the arrays are equal
        {
            Console.WriteLine("The arrays are equal");
        }

    }
}