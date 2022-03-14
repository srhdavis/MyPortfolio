using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project5_HumanVsOrc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables:
            string cName;                                                               //Stores player's name
            int damage;                                                                 //Tracks current damage
            int round = 1;                                                              //Tracks current round
            int cChoice;                                                                //Stores player's action choice

            //Welcome Screen:
            Console.Write("Welcome, warrior, to the Land of Waste.\n\nWhat is your name? ");
            cName = Console.ReadLine();

            Human h1 = new Human(cName);
            Orc o1 = new Orc("Chewie");
            
            Console.Clear();
            Console.Write("Stacy,\n\nAs a Human, you have 3 skills: Attack, Heal, and Defend.\nYour mission is to fight with Orcs and protect your own kind.\nReady?\n\nPress any key to begin.");
            Console.ReadKey();

            //Display Round and Creature info:
            Console.Clear();            
            Console.WriteLine("\t\tRound " + round);
            h1.Display();
            Console.WriteLine();
            o1.Display();
            Console.WriteLine("\n");

            //Player chooses action:
            Console.Write("Stacy,\nyou have spotted the Orc called " + o1.GetName() + ". What would you like to do?\n" +
                "\n(1)    Attack" +
                "\n(2)    Heal" +
                "\n(3)    Defend\n");

            while (true)
            {
                while (true)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        cChoice = Convert.ToInt32(input);
                    }
                    catch (Exception)
                    {
                        Console.Write("\nInvalid input. Please enter a valid option: ");
                        //Console.ReadKey();
                        continue;
                    }
                    break;
                }
                
                if (cChoice != 1 && cChoice != 2 && cChoice != 3)
                {
                    Console.Write("\nInvalid input. Please enter a valid option: ");
                    //Console.ReadKey();
                    continue;
                }
                else
                {
                    break;
                }
            }
            
            while (true)
            {
                if (cChoice == 1)                                                       //Attack
                {
                    Console.WriteLine();

                    //Human attacks first:
                    damage = h1.Attack();
                    Console.WriteLine(h1.GetName() + " attacks and causes " + damage + " damage");
                    o1.SetHealth(damage);
                    Console.WriteLine(o1.GetName() + "'s health drops to " + o1.GetCurrentHealth());

                    Console.WriteLine("\nPress any key to continue: ");
                    Console.ReadKey();
                }
                else if (cChoice == 2)                                                  //Heal
                {
                    h1.Heal();

                    Console.WriteLine("\nPress any key to continue: ");
                    Console.ReadKey();
                }
                else { }                                                                //Defend

                //update battle stats:
                Console.Clear();
                Console.WriteLine("\t\tRound " + round);
                h1.Display();
                Console.WriteLine();
                o1.Display();
                Console.WriteLine("\n");

                //Determine if there is a winner:
                if (h1.GetCurrentHealth() <= 0)                                         //human loses
                {
                    Console.WriteLine("Fight ends. " + o1.GetName() + " has killed " + h1.GetName() + ".");
                    break;
                }
                else if (o1.GetCurrentHealth() <= 0)                                    //human wins
                {
                    Console.WriteLine("Congratulations! " + h1.GetName() + " has killed " + o1.GetName() + ".");
                    break;
                }
                else { }                                                                //default, fight continues                

                if (cChoice == 3)
                {
                    //Orc attacks after Human Defends:
                    damage = o1.Attack();
                    Console.Write(o1.GetName() + " attacks for " + damage + " damage");
                    h1.Defend(damage);
                    Console.Write(" but " + h1.GetName() + " defended and " + h1.GetName() + "'s health only drops to " + h1.GetCurrentHealth());
                }
                else
                {
                    //Orc attacks:
                    damage = o1.Attack();
                    Console.WriteLine(o1.GetName() + " attacks and causes " + damage + " damage");
                    h1.SetHealth(damage);
                    Console.WriteLine(h1.GetName() + "'s health drops to " + h1.GetCurrentHealth());
                }

                Console.WriteLine("\nPress any key to continue: ");
                Console.ReadKey();

                //update battle stats:
                Console.Clear();
                Console.WriteLine("\t\tRound " + round);
                h1.Display();
                Console.WriteLine();
                o1.Display();
                Console.WriteLine("\n\n");

                //Determine if there is a winner:
                if (h1.GetCurrentHealth() <= 0)                                         //human loses
                {
                    Console.WriteLine("Fight ends. " + o1.GetName() + " has killed " + h1.GetName() + ".");
                    break;
                }
                else if (o1.GetCurrentHealth() <= 0)                                    //human wins
                {
                    Console.WriteLine("Congratulations! " + h1.GetName() + " has killed " + o1.GetName() + ".");
                    break;
                }
                else { }                                                                //default, fight continues

                round += 1;                                                             //Increments round

                Console.Clear();

                //Display Round and Creature info
                Console.WriteLine("\t\tRound " + round);
                h1.Display();
                Console.WriteLine();
                o1.Display();
                Console.WriteLine("\n");

                //Player chooses action:
                Console.Write("What would you like to do?\n" +
                    "\n(1)    Attack" +
                    "\n(2)    Heal" +
                    "\n(3)    Defend\n");

                while (true)
                {
                    while (true)
                    {
                        try
                        {
                            string input = Console.ReadLine();
                            cChoice = Convert.ToInt32(input);
                        }
                        catch (Exception)
                        {
                            Console.Write("\nInvalid input. Please enter a valid option: ");
                            //Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    if (cChoice != 1 && cChoice != 2 && cChoice != 3)
                    {
                        Console.Write("\nInvalid input. Please enter a valid option: ");
                        //Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
