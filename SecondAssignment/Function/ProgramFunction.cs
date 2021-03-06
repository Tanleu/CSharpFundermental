using System;
using System.Linq;
using System.Collections.Generic;

namespace FirstAssignment
{
    class ProgramSingletonObject
    {
        public static ProgramSingletonObject programFunction;
        public List<Student> listStudent;
        public static ProgramSingletonObject GetProgramProgramSingletonObject()
        {
            if (programFunction is null) programFunction = new ProgramSingletonObject();
            return programFunction;
        }
        public ProgramSingletonObject()
        {
            listStudent = DataContext.GetDataContext().ListStudent;
        }

        /// <summary>
        ///    Helper Function
        /// </summary>
        private void printStudent(Student student)
        {
            Console.Write("{0, -10}|", student.FirstName);
            Console.Write("{0, -20}|", student.LastName);
            Console.Write("{0, -10}|", Enum.GetName(typeof(Gender), student.Gender));
            Console.Write("{0, -5}|", student.Age);
            Console.Write("{0, -25}|", student.DateOfBirth);
            Console.Write("{0, -20}|", student.BirthPlace);
            Console.Write("{0, -20}|", student.PhoneNumber);
            Console.Write("{0, -15}|", student.IsGraduated == true ? "Graduated" : "Non-Graduated");
            Console.Write("\n");
        }
        private void PrintListStudent(string title, List<Student> students)
        {
            Console.WriteLine(title);
            Console.Write("{0, "+ ((-10) + "First Name".Length).ToString() +"}|","First Name");
            Console.Write("{0, "+ ((-20) + "Last Name".Length).ToString() +"}|","Last Name");
            Console.Write("{0, "+ ((-10) + "Gender".Length).ToString() +"}|","Gender");
            Console.Write("{0, "+ ((-5) + "Age".Length).ToString() +"}|","Age");
            Console.Write("{0, "+ ((-25) + "Date Of Birth".Length).ToString() +"}|","Date Of Birth");
            Console.Write("{0, "+ ((-20) + "Birth Place".Length).ToString() +"}|","Birth Place");
            Console.Write("{0, "+ ((-20) + "Phone number".Length).ToString() +"}|","Phone Number");
            Console.Write("{0, "+ ((-15) + "Graduated".Length).ToString() +"}|","Graduated");
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
        
        /// <summary>
        ///    Main function
        /// </summary>
        public void ReturnListOfMaleMembers()
        {
            var listOfStudents = listStudent.Where(x=> x.Gender == Gender.Male).ToList();
            PrintListStudent("List of male students", listOfStudents);
        }
        public void GetOldestPeroson()
        {
            var oldestStudent = listStudent
                .OrderByDescending(x => DateTime.Now.Subtract(x.DateOfBirth)).FirstOrDefault();

            List<Student> listOfStudent = new List<Student>();
            listOfStudent.Add(oldestStudent);

            PrintListStudent("The oldest person is: ", listOfStudent);
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
            List<Student> listStudent2000 = listStudent.Where(x=> x.DateOfBirth.Year == 2000).ToList();
            List<Student> listStudentUp2000 = listStudent.Where(x=> x.DateOfBirth.Year  > 2000).ToList();
            List<Student> listStudentBelow2000 = listStudent.Where(x=> x.DateOfBirth.Year  < 2000).ToList();

            // This is faster way than linq because we only need to loop through the array one time.
            // listStudent.ForEach(x =>
            //     {
            //         Console.WriteLine(x.DateOfBirth.Year);
            //         switch (x.DateOfBirth.Year)
            //         {
            //             case 2000:
            //                 listStudent2000.Add(x);
            //                 break;
            //             case > 2000:
            //                 listStudentUp2000.Add(x);
            //                 break;
            //             default:
            //                 listStudentBelow2000.Add(x);
            //                 break;
            //         }
            //     });

            PrintListStudent("4.1). Get student whose year of birth is 2000", listStudent2000);
            PrintListStudent("4.2). Get student whose year of birth is higher than 2000", listStudentUp2000);
            PrintListStudent("4.3). Get student whose year of birth is lowwer than 2000", listStudentBelow2000);

        }
        public void GetPersonWhoLiveInHaNoi()
        {
            var listOfStudentLiveInHaNoi = listStudent.Where(x=> x.BirthPlace.ToLower() == "ha noi").ToList();
            //Linq
            // var filteredStudents = listStudent.Where(x => x.BirthPlace == "Ha Noi").ToList();
            // PrintListStudent("5) List of student who lives in Ha Noi", filteredStudents);

            PrintListStudent("List of student who live in Ha Noi", listOfStudentLiveInHaNoi);
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