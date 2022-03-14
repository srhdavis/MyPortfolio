using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project2_Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Project 2 Blackjack
            while (true)
            {
                Console.Clear();

                int cCardCtr = 0;
                int cSum = 0;
                int uCardCtr = 0;
                int uSum = 0;
                int drawCard = 0;
                string userInput = "y";

                List<string> suit = new List<string>() { "Spades ♠", "Hearts ♥", "Diamonds ♦", "Clubs ♣" };         //creates a list of suits:
                List<string> rank = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };        //creates a list of card ranks:
                List<int> compCardStore = new List<int>() { };                  //creates a new list "cardStore" to store the number:
                List<int> userCardStore = new List<int>() { };

                Console.Write("Welcome to BlackJack!!\n\nGAME RULES:\n****************************************" +
                    "\nDraw as many cards as you want.\nIf your total score is 21, you win!\n" +
                    "If you go over 21, you lose.\nStopping at a score before 21 gives the computer a turn.\n" +
                    "The computer must draw until it beats your score or goes over 21.\nIf the computer beats your score without" +
                    " going over 21, you lose.\n\n1  Point  = Ace\n10 Points = Jack, Queen, King\n****************************************\n\nPress any key to continue.");

                Console.ReadKey();

                Random rn = new Random();

                //Loop to draw 2 cards each:
                while (true)
                {
                    //Draws random card:
                    int aRandom = rn.Next(0, 52);
                    drawCard = aRandom;

                    //Starting cards, 2 for the computer & 2 for the user:
                    if (cCardCtr < 2)
                    {
                        compCardStore.Add(aRandom);
                        cCardCtr = cCardCtr + 1;
                        continue;
                    }
                    else if (uCardCtr < 2)
                    {
                        userCardStore.Add(aRandom);
                        uCardCtr = uCardCtr + 1;
                        continue;
                    }
                    else
                    {
                        foreach (int n in compCardStore)                                //Loop to interpret each card in the list "compCardStore"
                        {
                            int suitIndex = n / 13;                                     //Interpret
                            int rankIndex = n % 13;

                            string cardSuit = suit[suitIndex];                          //Stores the card in a temporary variable
                            string cardRank = rank[rankIndex];

                            if (rankIndex == 10 || rankIndex == 11 || rankIndex == 12)  //Summation
                            {
                                cSum = cSum + 10;                                       //Adds Jack, Queen, or King value (10 points) to the total
                            }
                            else
                            {
                                cSum = cSum + rankIndex + 1;                            //Adds the value of the numerical card to the total
                            }
                        }

                        foreach (int n in userCardStore)                                //Loop to interpret each card in the list "userCardStore"
                        {
                            int suitIndex = n / 13;                                     //Interpret
                            int rankIndex = n % 13;

                            string cardSuit = suit[suitIndex];                          //Stores the card in a temporary variable
                            string cardRank = rank[rankIndex];

                            if (rankIndex == 10 || rankIndex == 11 || rankIndex == 12)  //Summation
                            {
                                uSum = uSum + 10;                                       //Adds Jack, Queen, or King value (10 points) to the total
                            }
                            else
                            {
                                uSum = uSum + rankIndex + 1;                            //Adds the value of the numerical card to the total
                            }
                        }
                        break;
                    }
                }

                while (true)
                {
                    //Draws random card:
                    int aRandom = rn.Next(0, 52);
                    drawCard = aRandom;

                    //Score Board
                    Console.Clear();
                    Console.Write("********** Score Board **********\n\nComputer's Cards:\n");

                    foreach (int n in compCardStore)                                    //Loop to interpret each card in the list "compCardStore"
                    {
                        int suitIndex = n / 13;                                         //Interpret
                        int rankIndex = n % 13;

                        string cardSuit = suit[suitIndex];                              //Stores the card in a temporary variable
                        string cardRank = rank[rankIndex];

                        Console.WriteLine("  " + cardRank + " of " + cardSuit);
                    }

                    Console.WriteLine("\nYour Cards:");

                    foreach (int n in userCardStore)                                    //Loop to interpret each card in the list "userCardStore"
                    {
                        int suitIndex = n / 13;                                         //Interpret
                        int rankIndex = n % 13;

                        string cardSuit = suit[suitIndex];                              //Stores the card in a temporary variable
                        string cardRank = rank[rankIndex];

                        Console.WriteLine("  " + cardRank + " of " + cardSuit);
                    }

                    Console.WriteLine("\n*********************************");
                    Console.WriteLine("\nCOMPUTER'S TOTAL " + cSum);
                    Console.WriteLine("\nYOUR TOTAL: " + uSum);

                    if (uSum == 21 || cSum > 21)                                        
                    {
                        Console.WriteLine("\n\nYou WIN!!");
                        break;
                    }
                    else if (uSum > 21)
                    {
                        Console.WriteLine("\n\nSorry, you LOSE!");
                        break;
                    }
                    else if (uSum < 21 && (userInput == "y" || userInput == "Y"))
                    {
                        Console.Write("\n\nEnter Y to draw another card or enter any other key to Hold: ");
                        userInput = Console.ReadLine();

                        if (userInput == "y" || userInput == "Y")
                        {
                            userCardStore.Add(aRandom);
                            uCardCtr = uCardCtr + 1;

                            int suitIndex = aRandom / 13;                               //Interpret
                            int rankIndex = aRandom % 13;

                            string cardSuit = suit[suitIndex];                          //Stores the card in a temporary variable
                            string cardRank = rank[rankIndex];

                            if (rankIndex == 10 || rankIndex == 11 || rankIndex == 12)  //Summation
                            {
                                uSum = uSum + 10;                                       //Adds Jack, Queen, or King value (10 points) to the total
                            }
                            else
                            {
                                uSum = uSum + rankIndex + 1;                            //Adds the value of the numerical card to the total
                            }
                        }
                        else
                        {
                            Console.Write("\n\nIt is now Computer's turn to draw a card.\nPress any key to continue.");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    else if (uSum >= cSum)
                    {
                        compCardStore.Add(aRandom);
                        cCardCtr = cCardCtr + 1;

                        int suitIndex = aRandom / 13;                                   //Interpret
                        int rankIndex = aRandom % 13;

                        string cardSuit = suit[suitIndex];                              //Stores the card in a temporary variable
                        string cardRank = rank[rankIndex];

                        if (rankIndex == 10 || rankIndex == 11 || rankIndex == 12)      //Summation
                        {
                            cSum = cSum + 10;                                           //Adds Jack, Queen, or King value (10 points) to the total
                        }
                        else
                        {
                            cSum = cSum + rankIndex + 1;                                //Adds the value of the numerical card to the total
                        }

                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\n\nSorry, you LOSE!");
                        break;
                    }
                }

                Console.WriteLine("\nWould you like to play again? Enter any key to continue or Q to quit.");
                string uInput = Console.ReadLine();

                if (uInput == "q" || uInput == "Q")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.Clear();
            Console.WriteLine("Good bye!");
            Console.ReadKey();
        }
    }
}
