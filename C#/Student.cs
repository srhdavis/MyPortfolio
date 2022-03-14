using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov05_Module09Exercise
{
    class Student
    {
        //Variables
        protected string name;
        protected string year;
        protected int CWID;
        protected double GPA;                                               //Not accessible from the Program class
        public static Random rn = new Random();                             //Accessible from the Program class

        //Constructor
        public Student(string n, string y)
        {
            name = n;
            year = y;
            CWID = rn.Next(10000, 100000);
            GPA = 0;
        }

        public void setGPA(double g)                                        //Public method that is accessible from the Program class; When called, can access the protected GPA value
        {
            GPA = g;                                                        
        }

        public void display()
        {
            Console.WriteLine(name + " is a " + year + ". CWID is " + CWID + ". GPA is " + GPA);
        }
    }
}
