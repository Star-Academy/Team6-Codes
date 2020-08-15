using System;
using System.Collections.Generic;
using AppConsole.Model;
using System.Linq;

namespace AppConsole.View
{
    public class TopStudent
    {
        public static void ShowTop(List<Student> students, int topLength)
        {

            foreach (Student student in students.Take(topLength))
            {

                Console.WriteLine(student);
            }

        }
    }
}