using System.Collections.Generic;

namespace FirstAssignment
{
    class DataContext
    {
        public static DataContext dataContext;
        public static DataContext GetDataContext()
        {
            if (dataContext is null) dataContext = new DataContext();
            return dataContext;
        }

        public DataContext()
        {
            ListStudent = new List<Student>();

            Student firstStudent = new Student();
            firstStudent.FirstName = "Tan";
            firstStudent.LastName = "Leu Duy";
            firstStudent.Gender = Gender.Male;
            firstStudent.DateOfBirth = System.DateTime.Now;
            firstStudent.Age = 35;
            firstStudent.BirthPlace = "Hai Duong";
            firstStudent.PhoneNumber = "0922.11.09.96";
            firstStudent.IsGraduated = true;

            ListStudent.Add(firstStudent);

            Student sectStudent = new Student();
            sectStudent.FirstName = "Anh";
            sectStudent.LastName = "Nguyen Minh";
            sectStudent.Gender = Gender.Male;
            sectStudent.DateOfBirth = System.DateTime.Now.AddYears(-50);
            sectStudent.Age = 25;
            sectStudent.BirthPlace = "Hai Duong";
            sectStudent.PhoneNumber = "0922.11.09.96";
            sectStudent.IsGraduated = true;

            ListStudent.Add(sectStudent);
        }

        public List<Student> ListStudent;
    }
}