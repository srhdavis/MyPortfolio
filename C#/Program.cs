using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov05_Module09Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student aStudent = new Student("Corey", "junior");              //Create a new instance "aStudent"
            //aStudent.display();                                             //Display aStudent

            //aStudent.setGPA(3.6);                                           //Calls the "setGPA" method and can change the value of GPA
            //aStudent.display();

            List<Student> students = new List<Student>();

            for (int i = 0; i < 3; i = i + 1)
            {
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter year");
                string year = Console.ReadLine();
                Student aStudent = new Student(name, year);

                students.Add(aStudent);
            }

            foreach (Student e in students)
            {
                e.display();
            }

            Console.ReadKey();
        }
    }
}
