using System;

//Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

class WorkDays
{
    static DateTime[] holidays = { new DateTime(2012, 12, 24), new DateTime(2012, 12, 25), new DateTime(2012, 12, 30),new DateTime(2012, 12, 31), new DateTime(2013, 01, 01) };
    static void Main()
    {
        DateTime start = new DateTime(2012, 1, 14);
        DateTime end = new DateTime(2013, 1, 25);

        if(start>end)
        {
            DateTime temp;
            temp = start;
            start = end;
            end = temp;
        }
        DateTime[] myDays = new DateTime[(int)end.Subtract(start).TotalDays];

        int daysToSubstract = 0;
        for (DateTime i = start; i <=end; )
        {
            for (int j = 0; j < holidays.Length; j++)
            {
                if(i==holidays[j])
                {
                    daysToSubstract++;
                }
            }
            if (i.DayOfWeek.ToString() == "Saturday" || i.DayOfWeek.ToString() == "Sunday")
            {
                daysToSubstract++;
            }
            i=i.AddDays(1);
        }

        Console.WriteLine("There are {0} days between {1:dd.MMMM.yyyy} and {2:dd.MMMM.yyyy}", end.Subtract(start).TotalDays,start,end);
        Console.WriteLine("{0} of these days are either a holiday or a weekend day",daysToSubstract);
        Console.WriteLine("So the total amount of work days is: {0}", end.Subtract(start).TotalDays-daysToSubstract);

    }
}