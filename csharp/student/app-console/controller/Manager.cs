
using System.Collections.Generic;
using System.Linq;
using app_console.model;
using app_console.view;

namespace app_console.controller
{
    public class Manager
    {

        public static string studentsJsonFilePath = "app-console/josn-files/Students.json";
        public static string scoresJsonFilePath = "app-console/josn-files/Scores.json";

        public static int topLength = 3;

        public static void Run()
        {
            List<Grade> grades = new Deserializer<List<Grade>>(scoresJsonFilePath).getObject();
            List<Student> students = new Deserializer<List<Student>>(studentsJsonFilePath).getObject();
            students = AssignGrades(students , grades);
            students.ForEach(student => student.setAvarage());
            students = students.OrderByDescending(student => student.avarage).ToList();
            View.ShowTop(students, topLength);
        }

        public static List<Student> AssignGrades(List<Student> students , List<Grade> grades){
            students = students.OrderBy(student => student.StudentNumber).ToList();
            grades.ForEach(grade => students[grade.StudentNumber - 1].grades.Add(grade));
            return students;
        }

        
    }
}