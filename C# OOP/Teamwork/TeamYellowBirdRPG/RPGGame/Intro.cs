namespace RPGGame
{
    using System;

    public static class Intro
    {
        public static void PrintYellowBird()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bird);
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }


        const string bird = @"
                



                                 $$$$                    
                               $$$$$$$                   
                              $$ $$$$$$                  
                         $$$$$$$$$$$$$$                  
                         $$$$$$$$$$$$$$                  
                              $$$$$$$$                   
                               $$$$$$    $$$$$           
                                 $$$$  $$$$$$$$$         
                                $$$$$$$$$$$$$$$$$$       
                                $$$$$$$$$$$$$$$$$$$$     
                                $$$$$$$$$$$$$$$$$$$$$$$$ 
                                $$$$$$$$$$$$$$$$$$$$$$$  
                                  $$$$$$$$$$$$$$$$$$     
                                    $$$$$$$$$$$$$$       
                                         $$              
                                         $$              
                                         $$              
                                      $$$$$$             
                
              __   __   _ _                 ____  _         _ 
              \ \ / /__| | | _____      __ | __ )(_)_ __ __| |
               \ V / _ \ | |/ _ \ \ /\ / / |  _ \| | '__/ _` |
                | |  __/ | | (_) \ V  V /  | |_) | | | | (_| |
                |_|\___|_|_|\___/ \_/\_/   |____/|_|_|  \__,_|
                                                                


";
    }
}
