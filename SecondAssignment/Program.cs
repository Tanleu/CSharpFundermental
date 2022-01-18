using System;

namespace FirstAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Halo! Welcome to student management application");
            while(true){
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Menu");
                Console.WriteLine("1) Get all male students");
                Console.WriteLine("2) Find the oldest person");
                Console.WriteLine("3) Get list student's name");
                Console.WriteLine("4) Get three list of student who are born at, after and befor 2000");
                Console.WriteLine("5) Find all student who live in Ha Noi");
                Console.WriteLine("6) Insert a new student");
                Console.WriteLine("0) Stop program");
                Console.Write("Input your selection: ");
                string choice = Console.ReadLine();
                switch(choice){
                    case "1":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().ReturnListOfMaleMembers();
                        break;
                    case "2":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().GetOldestPeroson();
                        break;
                    case "3":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().GetAllNameOfStudent();
                        break;
                    case "4":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().GetThreeListStudentDependOnYearOfBirth();
                        break;
                    case "5":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().GetPersonWhoLiveInHaNoi();      
                        break;
                    case "6":
                        ProgramSingletonObject.GetProgramProgramSingletonObject().AddANewStudent();
                        break;
                    case "0":
                        Console.WriteLine("Program close");
                        return;
                    default:
                        Console.WriteLine("Your selection doesn't exists ~ Please try again");
                        break;
                }
                
            }
        }
    }
}
