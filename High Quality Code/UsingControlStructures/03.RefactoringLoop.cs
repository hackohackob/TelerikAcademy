using System;
class RefactoringLoop
{
    static void Main()
    {
        int i = 0;
        bool valueFound = false;

        for (i = 0; i < 10; i++)
        {
            if (array[i * 10] == expectedValue)
            {
                valueFound = true;
            }

            Console.WriteLine(array[i]);
        }
        // More code here
        if (valueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}