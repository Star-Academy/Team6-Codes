
using System.Collections.Generic;
using System.Linq;
using AppConsole.Model;
using AppConsole.View;

namespace AppConsole.Controller
{
    public class Manager
    {

        public static string StudentsJsonFilePath = "Json/Students.json";
        public static string ScoresJsonFilePath = "Json/Scores.json";

        public static int TopLength = 3;

        public static void Run()
        {
            var grades = new Deserializer<List<Grade>>(ScoresJsonFilePath).GetObject();
            var students = new Deserializer<List<Student>>(StudentsJsonFilePath).GetObject();
            var AssignGradesStudents = AssignGrades(students, grades);
            AssignGradesStudents.ForEach(student => student.CalculateAvarage());
            var OrderedStudents = AssignGradesStudents.OrderByDescending(student => student.Average).ToList();
            TopStudent.ShowTop(OrderedStudents, TopLength);
        }

        public static List<Student> AssignGrades(List<Student> students, List<Grade> grades)
        {
            var studentsMap = students.ToDictionary(student => student.StudentNumber, student => student);
            grades.ForEach(grade => studentsMap[grade.StudentNumber].Grades.Add(grade));
            return students.ToList();
        }


    }
}