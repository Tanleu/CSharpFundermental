using System;
using ThridAssigment.FunctionModel;

namespace ThridAssigment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Function.GetFunctionInstance().FindPrimeNumber(1,1000);
            // return;
            // Console.WriteLine("Hello World!");
            do{
                Console.WriteLine("1. Find prime number from a range");
                Console.WriteLine("2. Clock program");
                Console.WriteLine("0. End program");
                Console.Write("What's your choice: ");
                string userChoice = Console.ReadLine();

                switch(userChoice){
                    case "1":
                        Function.GetFunctionInstance().FindPrimeNumber(1,1000);
                        break;
                    case "2":
                        Function.GetFunctionInstance().ClockProgram();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("对不起, you select wrong answer! Please try again");
                        break;
                }
            }while(true);
        }
    }
}
