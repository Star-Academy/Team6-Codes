using System.Collections.Generic;
using System.Linq;
using System;

namespace AppConsole.Model
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Grade> Grades = new List<Grade>();
        public float Average { get; private set; }

        public void CalculateAvarage()
        {
            Average = Grades.Average(grade => grade.Score);
        }

        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName} {Average}");
        }

        public override int GetHashCode()
        {
            return this.StudentNumber.GetHashCode();
        }
    }
}