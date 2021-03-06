using System;
using System.Linq;
using System.Collections.Generic;

namespace FirstAssignment
{

    class ProgramFunction
    {
        public static ProgramFunction programFunction;
        public List<Student> listStudent;
        public static ProgramFunction GetProgramFunctionInstance()
        {
            if (programFunction is null) programFunction = new ProgramFunction();
            return programFunction;
        }
        public ProgramFunction()
        {
            listStudent = DataContext.GetDataContext().ListStudent;
        }
        private void printStudent(Student student)
        {
            foreach (var prop in student.GetType().GetProperties())
            {
                if(prop.Name == "IsGraduated")
                    // Console.Write((bool)prop.GetValue(student, null)); 
                    Console.Write("{0, -20}|", (bool)prop.GetValue(student, null) == true ? "Graduated" : "Non-graduated");
                else
                    Console.Write("{0, -20}|", prop.GetValue(student, null));
            }
            Console.Write("\n");

        }
        private void PrintListStudent(string title, List<Student> students)
        {
            Console.WriteLine(title);
            foreach (var prop in typeof(Student).GetProperties())
            {
                Console.Write("{0, -20}|", prop.Name);
            }
            Console.Write("\n");

            if (students.Count <= 0)
            {
                Console.WriteLine("There is no result");
                return;
            }
            students.ForEach(x => printStudent(x));

        }
        private T GetUserInput<T>(string message){
            Console.Write(message);
            string userInput = Console.ReadLine();
            if(typeof(T).IsEnum)
                return (T) Enum.Parse(typeof(T), userInput, true);
            else if(typeof(T) == typeof(bool))
            {
                if(userInput == "0") return (T)(object)false;
                else return (T)(object)false;;
            } 
            return (T)Convert.ChangeType(userInput, typeof(T));
        }
        public void ReturnListOfMaleMembers()
        {
            Console.WriteLine("1). List of male student");
            foreach (var prop in typeof(Student).GetProperties())
            {
                Console.Write("{0, -20}|", prop.Name);
            }
            Console.Write("\n");


            listStudent.ForEach(x =>
                {
                    if (x.Gender == Gender.Male)
                        printStudent(x);
                }
            );
        }
        public void GetOldestPeroson()
        {
            Console.WriteLine("2). Get oldest student");
            foreach (var prop in typeof(Student).GetProperties())
            {
                Console.Write("{0, -20}|", prop.Name);
            }
            Console.Write("\n");

            Student oldestStudent = new Student();
            oldestStudent.Age = 0;
            oldestStudent.DateOfBirth = DateTime.Now;

            listStudent.ForEach(x => {
                if(x.Age > oldestStudent.Age)
                    oldestStudent = x;
            });

            // Uses age for comparision solution
            // listStudent.ForEach(x => {
            //     if(x.DateOfBirth > oldestStudent.DateOfBirth)
            //         oldestStudent = x;
            // });

            // Linq solution
            // oldestStudent = listStudent
            //     .OrderByDescending(x => DateTime.Now.Subtract(x.DateOfBirth))
            //     .FirstOrDefault();

            printStudent(oldestStudent);
        }
        public void GetAllNameOfStudent()
        {
            Console.WriteLine("3). Get all student's name");
            Console.WriteLine("Full Name");
            listStudent
                .ForEach(x => Console.WriteLine(x.LastName + " " + x.FirstName));
        }
        public void GetThreeListStudentDependOnYearOfBirth()
        {
            Console.WriteLine("4). Get three list of student");
            List<Student> listStudent2000 = new List<Student>();
            List<Student> listStudentUp2000 = new List<Student>();
            List<Student> listStudentBelow2000 = new List<Student>();

            listStudent.ForEach(x =>
                {
                    Console.WriteLine(x.DateOfBirth.Year);
                    switch (x.DateOfBirth.Year)
                    {
                        case 2000:
                            listStudent2000.Add(x);
                            break;
                        case > 2000:
                            listStudentUp2000.Add(x);
                            break;
                        default:
                            listStudentBelow2000.Add(x);
                            break;
                    }
                });

            PrintListStudent("4.1). Get student whose year of birth is 2000", listStudent2000);
            PrintListStudent("4.2). Get student whose year of birth is higher than 2000", listStudentUp2000);
            PrintListStudent("4.3). Get student whose year of birth is lowwer than 2000", listStudentBelow2000);

        }
        public void GetPersonWhoLiveInHaNoi()
        {
            Console.WriteLine("5). List of student who lives in Ha Noi");
            foreach (var prop in typeof(Student).GetProperties())
            {
                Console.Write("{0, -20}|", prop.Name);
            }
            Console.Write("\n");

            listStudent.ForEach(x=> {
                if(x.BirthPlace == "Ha Noi") printStudent(x);
            });
            //Linq
            // var filteredStudents = listStudent.Where(x => x.BirthPlace == "Ha Noi").ToList();
            // PrintListStudent("5) List of student who lives in Ha Noi", filteredStudents);
        }
        public void AddANewStudent(){
            Student student = new Student();
            Console.WriteLine("Please input these belowing infomations");
            try
            {
                student.FirstName = GetUserInput<string>("Student's name :");
                student.Gender = GetUserInput<Gender>("Gender (0: Male|1: Female|2: Bisexual|3: Trans) :");
                student.DateOfBirth = GetUserInput<DateTime>("Date of Birth (dd/mm/yyyy) :");
                student.BirthPlace = GetUserInput<string>("Birth Place :");
                student.PhoneNumber = GetUserInput<string>("Phone number :");
                student.IsGraduated = GetUserInput<bool>("Is graduated ( 1:Yes/ 0:No ) :");

                listStudent.Add(student);
                Console.WriteLine("Successfully add new student");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        
        }

    }
}