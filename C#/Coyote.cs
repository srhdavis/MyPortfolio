using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class Coyote : dog
    {
        public Coyote()
        {
            name = "A coyote";
        }

        public override void bark()
        {
            Console.WriteLine("AWOO!");
        }
    }
}