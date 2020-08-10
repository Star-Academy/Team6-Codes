using System.Collections.Generic;
using System.Linq;

namespace app_console.model
{
    public class Student
    {
        public int StudentNumber {get; set;}
        public string FirstName  {get; set;}
        public string LastName   {get; set;}
        public List<Grade> grades = new List<Grade>();
        public float avarage        {get; set;}

        public void setAvarage(){
            avarage = grades.Average(grade => grade.Score);
        }
    }
} 