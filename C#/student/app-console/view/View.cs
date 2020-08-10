using System;
using System.Collections.Generic;
using app_console.model;

namespace app_console.view
{
    public class View
    {
        public static void ShowTop(List<Student> students, int topLength){
            for (int i = 0; i < topLength; i++)
            {
                Console.WriteLine("{0}.{1} {2} {3}",i + 1, students[i].FirstName , students[i].LastName , students[i].avarage);
            }
        }
    }
}