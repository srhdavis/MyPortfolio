using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project3_SelfCheckoutMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stacy Davis_Project 3- Self-Checkout Machine:

            int newSTotal = 0;
            int newKTotal = 0;
            int newCTotal = 0;
            int newBalance = 0;

            //Create lists:
            List<string> newInventory = new List<string>() { "sodas", "cookies", "chips" };
            List<int> newPrices = new List<int>() { 100, 200, 150 };
            List<int> soda = new List<int>() { };
            List<int> cookies = new List<int>() { };
            List<int> chips = new List<int>() { };

            //Primary loop:
            while (true)
            {
                Console.Clear();

                //Store quantities:
                newSTotal = 0;
                newKTotal = 0;
                newCTotal = 0;

                //Prevents quatities from being < 0:
                foreach (int i in soda)
                {
                    newSTotal = newSTotal + i;

                    if (newSTotal == 0 || newSTotal < 0)
                    {
                        newSTotal = 0;
                    }
                    else
                    {

                    }
                }

                foreach (int i in cookies)
                {
                    newKTotal = newKTotal + i;

                    if (newKTotal == 0 || newKTotal < 0)
                    {
                        newKTotal = 0;
                    }
                    else
                    {

                    }
                }

                foreach (int i in chips)
                {
                    newCTotal = newCTotal + i;

                    if (newCTotal == 0 || newCTotal < 0)
                    {
                        newCTotal = 0;
                    }
                    else
                    {

                    }
                }

                //Calculates current balance:
                newBalance = (newPrices[0] * newSTotal) + (newPrices[1] * newKTotal) + (newPrices[2] * newCTotal);

                //Displays current basket:
                Console.WriteLine("Your shopping cart contains: " +
                "\n" + newSTotal + " Sodas   @ $1.00 each..........$" + (newPrices[0] * newSTotal) / 100.00 +
                "\n" + newKTotal + " Cookies @ $2.00 each..........$" + (newPrices[1] * newKTotal) / 100.00 +
                "\n" + newCTotal + " Chips   @ $1.50 each..........$" + (newPrices[2] * newCTotal) / 100.00 +
                "\n\nYour total balance is..........$" + newBalance / 100.00);

                Console.Write("\n\n************************************************************\n\n" +
                    "WELCOME!  Please select from the following list:\n" +
                    "(S)for soda, (K) for cookies, (c) for chips: ");

                string newInputInv = Console.ReadLine();
                string newInputQty;
                int newQty;

                //User selects an item:
                if (newInputInv == "s" || newInputInv == "S")
                {
                    //Asks user quantity needed:
                    Console.Write("\nYou have selected " + newInventory[0] + ". They are $" + newPrices[0] / 100 + " each.\nHow many would you like? ");

                    //Catches invalid input:
                    try
                    {
                        newInputQty = Console.ReadLine();
                        newQty = Convert.ToInt32(newInputQty);
                    }
                    catch
                    {
                        Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\nPress any key to continue.");
                        Console.ReadKey();
                        continue;
                    }

                    //Adds quantity to the basket:
                    soda.Add(newQty);

                    Console.WriteLine("\n************************************************************\n" +
                        newQty + " " + newInventory[0] + " have been added to your cart.");
                }
                else if (newInputInv == "k" || newInputInv == "K")
                {
                    Console.WriteLine("\nYou have selected " + newInventory[1] + ". They are $" + newPrices[1] / 100 + " each.");

                    Console.Write("How many would you like? ");

                    try
                    {
                        newInputQty = Console.ReadLine();
                        newQty = Convert.ToInt32(newInputQty);
                    }
                    catch
                    {
                        Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\nPress any key to continue.");
                        Console.ReadKey();
                        continue;
                    }

                    cookies.Add(newQty);

                    Console.WriteLine("\n************************************************************\n" +
                        newQty + " " + newInventory[1] + " have been added to your cart.");
                }
                else if (newInputInv == "c" || newInputInv == "C")
                {
                    Console.WriteLine("\nYou have selected " + newInventory[2] + ". They are $" + newPrices[2] / 100 + "." + newPrices[2] % 100 + " each.");

                    Console.Write("How many would you like? ");

                    try
                    {
                        newInputQty = Console.ReadLine();
                        newQty = Convert.ToInt32(newInputQty);
                    }
                    catch
                    {
                        Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\nPress any key to continue.");
                        Console.ReadKey();
                        continue;
                    }

                    chips.Add(newQty);

                    Console.WriteLine("\n************************************************************\n" +
                        newQty + " " + newInventory[2] + " have been added to your cart.");
                }
                else
                {
                    //Catches invalid input:
                    Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\nPress any key to continue.");
                    Console.ReadKey();
                    continue;
                }

                //Asks the user to checkout:
                Console.Write("\n\nEnter (q) to checkout or any other key to keep shopping: ");
                string newInputQuit = Console.ReadLine();

                if (newInputQuit == "q" || newInputQuit == "Q")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            //Recalculates final balance:
            newSTotal = 0;
            newKTotal = 0;
            newCTotal = 0;

            foreach (int i in soda)
            {
                newSTotal = newSTotal + i;
            }

            foreach (int i in cookies)
            {
                newKTotal = newKTotal + i;
            }

            foreach (int i in chips)
            {
                newCTotal = newCTotal + i;
            }

            newBalance = (newPrices[0] * newSTotal) + (newPrices[1] * newKTotal) + (newPrices[2] * newCTotal);

            //Loop for payment:
            while (true)
            {
                string uInput = "";
                if (newBalance > 0)
                {
                    //Check for correct currency:
                    while (true)
                    {
                        Console.Clear();

                        //Display final balance:
                        Console.WriteLine("Your shopping cart contains: " +
                            "\n" + newSTotal + " Sodas   @ $1.00 each..........$" + (newPrices[0] * newSTotal) / 100.00 +
                            "\n" + newKTotal + " Cookies @ $2.00 each..........$" + (newPrices[1] * newKTotal) / 100.00 +
                            "\n" + newCTotal + " Chips   @ $1.50 each..........$" + (newPrices[2] * newCTotal) / 100.00 +
                            "\n\nYour total balance is..........$" + newBalance / 100.00);

                        Console.WriteLine("How would you like to pay?\n\nThe following currency is accepted: (10) dollar bill, (5) dollar bill, (1) dollar bill, " +
                            "(Q)uarter, (D)ime, (N)ickel");

                        //User selects payment:
                        Console.Write("\nTendered currency: ");
                        uInput = Console.ReadLine();

                        //Catches invalid input:
                        if (uInput == "10" || uInput == "5" || uInput == "1" || uInput == "q" || uInput == "Q" || uInput == "d" || uInput == "D" || uInput == "n" || uInput == "N")
                        {
                            break;
                        }
                        else
                        {                            
                            Console.WriteLine("\nSorry, that is not a valid currency. Please try again.\nPress any key to continue.");
                            Console.ReadKey();
                            continue;
                        }
                    }

                    int payment = 0;

                    if (uInput == "10")
                    {
                        payment = 1000;
                    }
                    else if (uInput == "5")
                    {
                        payment = 0500;
                    }
                    else if (uInput == "1")
                    {
                        payment = 0100;
                    }
                    else if (uInput == "q" || uInput == "Q")
                    {
                        payment = 0025;
                    }
                    else if (uInput == "d" || uInput == "D")
                    {
                        payment = 0010;
                    }
                    else if (uInput == "n" || uInput == "N")
                    {
                        payment = 0005;
                    }
                    else
                    {
                        //Catches invalid input:
                        Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\nPress any key to continue.");
                        Console.ReadKey();
                        continue;
                    }
                    
                    //Displays the user's payment:
                    Console.WriteLine("\nYou paid $" + payment / 100 + "." + payment % 100 + "\nEnter any key");
                    Console.ReadKey();

                    //Calculates the remaining balance, less payment:
                    newBalance = newBalance - (payment);
                    continue;
                }
                else if (newBalance < 0)
                {
                    //Displays if the user has a refund:
                    Console.Clear();

                    Console.Write("******************************\nYour balance is $0.00\n******************************\n\n" +
                        "You may take your purchase.\n\n" +
                        "Your refund is $" + (newBalance * (-1)) / 100 + "." + (newBalance * (-1)) % 100 + "\n\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else if (newBalance == 0)
                {
                    //Displays if the user has no refund:
                    Console.Clear();

                    Console.Write("******************************\nYour balance is $0.00\n******************************\n\n" +
                        "Thank you for shopping. You may take your purchase.\n\n" +
                        "Press any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    //Displays if something unexpected happens:
                    Console.WriteLine("\nSorry, that is not a valid entry. Please try again.\n" +
                        "Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }
            }
            
            //FIN
            Console.ReadKey();
        }
    }
}

