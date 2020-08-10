
using System;
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
            Grade[] grades = new Deserializer<Grade[]>(scoresJsonFilePath).getObject();
            Student[] students = new Deserializer<Student[]>(studentsJsonFilePath).getObject();
            students = AssignGrades(students , grades);
            students.ToList().ForEach(student => student.setAvarage());
            students = students.OrderByDescending(student => student.avarage).ToArray();
            View.ShowTop(students, topLength);
        }

        public static Student[] AssignGrades(Student[] students , Grade[] grades){
            students = students.OrderBy(student => student.StudentNumber).ToArray();
            grades.ToList().ForEach(grade => students[grade.StudentNumber - 1].grades.Add(grade));
            return students;
        }

        
    }
}