using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class Program
    {

        static double Adder(double myMoney)
        {
            myMoney = myMoney + 3.14;
            return myMoney;
        }

        static int Adder(int MyMoney)
        {
            MyMoney = MyMoney + 3;
            return MyMoney;
        }


        static void Main(string[] args)
        {
            //---------------------------------

            //Problem 1
            //Make a menu that prints "Press 1 to play or 2 to leave" then takes user input.
            //If 1 is pressed, clear the screen then print "Great!  Press any key to go back to the menu".
            //If 2 is pressed, clear the screen and print "Leaving now!  Press any key to exit".
            //If anything other than 1 or 2 is pressed, give the warning "You must enter 1 or 2" 
            //and go get the input again.
            //Use a While true loop and IF statements

            while (true)
            {
                Console.Write("Press 1 to play or 2 to leave: ");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Great! Press any key to go back to the menu\n");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Leaving now!  Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You must enter 1 or 2");
                }
            }

            //--------------------------------------------

            //Problem 2
            //Have the user enter an integer.  Check to make sure they didn't enter a
            //letter from the alphabet.
            //Use error handling to present the message "That is not an integer" if the
            //input is not an integer.  This only runs once, and will be tested with a 
            //letter from the alphabet.

            Console.Clear();
            try
            {
                Console.Write("Enter an integer: ");
                int userInput = Convert.ToInt32(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.WriteLine("That is not an integer");
                Console.ReadKey();
            }

            //--------------------------------

            //Problem 3
            //Fill a list of integers with the values 1 - 10 using a for loop.
            //Use foreach to iterate through that list to print out each integer

            Console.Clear();
            List<int> intList = new List<int>();

            for (int i = 1; i < 11 ; i = i + 1)
            {
                intList.Add(i);
            }
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            //--------------------------------

            //Problem 4
            //Create a new dictionary of names. Use first name as key and last name as value. 
            //Add Jim Halpert and Pam Beasley
            //Then use foreach to iterate through the dictionary to print out like
            //"First name: Bob"
            //"Last name: Andrews"
            //for each person in the dictionary

            Dictionary<string, string> myNames = new Dictionary<string, string>();
            myNames.Add("Jim", "Halpert");
            myNames.Add("Pam", "Beasley");

            foreach (KeyValuePair<string, string> i in myNames)
            {
                Console.WriteLine("First name: " + i.Key);
                Console.WriteLine("Last name: " + i.Value);
            }


            //--------------------------------

            //Problem 5
            //Make method Adder that adds 3.14 to a double parameter value passed to it
            //then returns that sum 
            //OR adds 3 to an integer parameter value passed to it
            //Call that method, passing it the double 7.12 and capture the result in a variable
            //Print that variable out
            //Call that method again, passing it the integer 7 and capture the result in a variable
            //Print that variable out

            double myDoubleResult = Adder(7.12);
            Console.WriteLine(myDoubleResult);

            int myIntResult = Adder(7);
            Console.WriteLine(myIntResult);


            //--------------------------------

            //Probem 6
            //Make a new class "dog".  A dog has a name. 
            //That name can only be changed and obtained via getter and setter.
            //Dogs have a method "bark".  If a dog barks it says "BORK BORK!"
            //Make the class, then here in the program class make a new dog named "Woofy"
            //Print out the dog's name
            //Make the dog bark

            Console.WriteLine();
            dog dog1 = new dog("Woofy");
            Console.WriteLine(dog1.getName());  //This should print dog1's name
            dog1.bark();  //This should make any dog bark

            Console.WriteLine();


            //--------------------------------

            //Problem 7
            //Make a new class "coyote".  A coyote is a dog.  All coyotes are named "A coyote"
            //coyotes should inherit name and the associated getter and setter.
            //When a coyote barks it says "AWOO!", so override bark method
            //Here in the program class make a coyote.
            //Print out the coyote's name
            //Make the coyote bark

            Coyote coyote1 = new Coyote();
            Console.WriteLine(coyote1.getName());    //This should print coyote1's name
            coyote1.bark();  //This should make any coyote bark

            Console.ReadKey();
        }
    }
}