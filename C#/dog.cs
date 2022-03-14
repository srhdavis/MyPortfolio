using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class dog
    {

        protected string name;

        public string getName()
        {
            return name;
        }

        public void setName(string n)
        {
            name = n;
        }

        public dog(string n)
        {
            name = n;
        }

        public dog() { }

        public virtual void bark()
        {
            Console.WriteLine("BORK BORK!");
        }

    }
}