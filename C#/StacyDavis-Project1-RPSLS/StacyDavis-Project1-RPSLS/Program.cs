using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project1_RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program: Rock, Paper, Scissors, Lizard, Spock

            while (true)                                                //1st Loop- Begining loop; Resets tournament; DO NOT EDIT!!!
            {
                Console.Clear();


                //Game Instruction
                Console.WriteLine("Welcome to Rock-Paper-Sissors-Lizard-Spock!\n\n");
                Console.WriteLine("**********************************************************************************");
                Console.Write("Game Rules:\n-Rock crushes Scissors or crushes Lizard\n-Scissors cuts Paper or decapitates Lizard\n");
                Console.Write("-Paper covers Rock or disproves Spock\n-Lizard eats Paper or poisons Spock\n-Spock vaporizes Rock or smashes Scissors\n");
                Console.WriteLine("\n**********************************************************************************");
                Console.Write("\nYou can choose to play a single game, 3 game, or 5 game tournament.\n\n");

                Console.WriteLine("\nHit any key to continue.");
                Console.ReadKey();

                Console.Clear();                                    //Clear Screen for new game

                int playWin = 0;                                    //Variables to keep score
                int compWin = 0;
                int matchCtr = 0;
                string Match = "0";


                //Match selection
                if (Match != "1" && Match != "3" && Match != "5")
                {
                    while (true)
                    {
                        Console.Write("\nChoose a tournament:\n(1) Match\n(3) Matches\n(5) Matches\n\nPlease enter 1, 3, or 5: ");
                        Match = Console.ReadLine();                 //User selects Match #

                        if (Match == "1" || Match == "3" || Match == "5")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("\n\nInvalid Input. Please select either 1, 3, or 5");
                            continue;
                        }
                    }
                }
                else                                                //Game has been chosen
                {
                    Console.WriteLine("\nYou have chosen " + Match + " matches!\n");
                    continue;
                }

                int matchNum = Convert.ToInt32(Match);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("CURRENT SCORE\nYou: " + playWin + "           Computer: " + compWin);
                    Console.WriteLine("***************************************************");


                    //Player chooses weapon
                    string uChoice = "";                            //Varible to store User's choice

                    if ((uChoice != "r" || uChoice != "R") || (uChoice != "p" || uChoice != "P") ||     //Determines if the user's input is valid
                        (uChoice != "s" || uChoice != "S") || (uChoice != "l" || uChoice != "L") || (uChoice != "k" || uChoice != "K"))     
                    {
                        while (true)
                        {
                            Console.Write("\nPlease enter (r)ock, (p)aper, (s)cissors, (l)izard, Spoc(k): ");       //User input
                            uChoice = Console.ReadLine();

                            if ((uChoice == "r" || uChoice == "R") || (uChoice == "p" || uChoice == "P") ||
                                (uChoice == "s" || uChoice == "S") || (uChoice == "l" || uChoice == "L") || (uChoice == "k" || uChoice == "K"))
                            {
                                break;
                            }
                            else
                            {
                                Console.Write("\n\nInvalid option\n");
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }


                    //Computer chooses weapon
                    Random aRandom = new Random();                  //Creates a random number
                    int bRandom = aRandom.Next(1, 6);               //Creates variable and sets range
                    string cChoice = Convert.ToString(bRandom);     //Converts integer to string to compare to User's choice

                    if (cChoice == "1")
                    {
                        cChoice = "r";                              //Converts 1 to rock
                        Console.WriteLine("Computer chose ROCK.");
                    }
                    else if (cChoice == "2")
                    {
                        cChoice = "p";                              //Converts 2 to paper
                        Console.WriteLine("Computer chose PAPER.");
                    }
                    else if (cChoice == "3")
                    {
                        cChoice = "s";                              //Converts 3 to scissors
                        Console.WriteLine("Computer chose SCISSORS.");
                    }
                    else if (cChoice == "4")
                    {
                        cChoice = "l";                              //Converts 4 to lizard
                        Console.WriteLine("Computer chose LIZARD.");
                    }
                    else if (cChoice == "5")
                    {
                        cChoice = "k";                              //Converts 5 to Spock
                        Console.WriteLine("Computer chose SPOCK.");
                    }
                    else
                    {
                        Console.WriteLine("INVALID");               //Just in case the computer goes crazy
                    }

                    Console.WriteLine();
                    Console.WriteLine("***************************************************");       //Stars to add interest and organization


                    //Fight
                    if ((uChoice == "r" && cChoice == "p") || (uChoice == "r" && cChoice == "k") || (uChoice == "p" && cChoice == "s") || (uChoice == "p" && cChoice == "l") || 
                        (uChoice == "s" && cChoice == "r") || (uChoice == "s" && cChoice == "k") || (uChoice == "l" && cChoice == "r") || (uChoice == "l" && cChoice == "s") ||
                        (uChoice == "k" && cChoice == "p") || (uChoice == "k" && cChoice == "l") ||
                        (uChoice == "R" && cChoice == "p") || (uChoice == "R" && cChoice == "k") || (uChoice == "P" && cChoice == "s") || (uChoice == "P" && cChoice == "l") ||
                        (uChoice == "S" && cChoice == "r") || (uChoice == "S" && cChoice == "k") || (uChoice == "L" && cChoice == "r") || (uChoice == "L" && cChoice == "s") ||
                        (uChoice == "K" && cChoice == "p") || (uChoice == "K" && cChoice == "l"))
                    {
                        Console.WriteLine("                You lost the match.");
                        compWin = compWin + 1;                      //Adds computer's win to the scoreboard
                    }
                    else if ((uChoice == "r" && cChoice == "s") || (uChoice == "r" && cChoice == "l") || (uChoice == "p" && cChoice == "r") || (uChoice == "p" && cChoice == "k") ||
                        (uChoice == "s" && cChoice == "p") || (uChoice == "s" && cChoice == "l") || (uChoice == "l" && cChoice == "p") || (uChoice == "l" && cChoice == "k") ||
                        (uChoice == "k" && cChoice == "r") || (uChoice == "k" && cChoice == "s") ||
                        (uChoice == "R" && cChoice == "s") || (uChoice == "R" && cChoice == "l") || (uChoice == "P" && cChoice == "r") || (uChoice == "P" && cChoice == "k") ||
                        (uChoice == "S" && cChoice == "p") || (uChoice == "S" && cChoice == "l") || (uChoice == "L" && cChoice == "p") || (uChoice == "L" && cChoice == "k") ||
                        (uChoice == "K" && cChoice == "r") || (uChoice == "K" && cChoice == "s"))
                    {
                        Console.WriteLine("                You won the match.");
                        playWin = playWin + 1;                      //Adds user's win to the scoreboard
                    }
                    else                                            //Determines winner and loser
                    {
                        Console.WriteLine("                The match is a tie.");
                    }

                    Console.WriteLine("***************************************************\n");     //Another pretty line


                    //Match Counter
                    matchCtr = matchCtr + 1;
                    if (matchCtr == matchNum)                        //Ends tournament
                    {
                        break;
                    }
                    else if (playWin > (matchNum * 0.5))            //If the user wins by over half
                    {
                        Console.WriteLine("You have won over 50% of the tournament and are automatically the WINNER!\n\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    }
                    else if (compWin > (matchNum * 0.5))            //If the computer wins by over half
                    {
                        Console.WriteLine("Sorry, the computer has won over 50% of the tournament and is automatically the winner.\n\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hit any key to continue");
                        Console.ReadKey();
                        continue;
                    }                   
                }

               
                //Final Score
                if (playWin > compWin)                             
                {
                    Console.WriteLine("\n\nCONGRATULATIONS, YOU WON THE TOURNAMENT!!");
                }
                else if (playWin < compWin)
                {
                    Console.WriteLine("\n\nSorry, you lost the tournament.");
                }
                else
                {
                    Console.WriteLine("\n\nSorry, the tournament was a tie.");
                }
                Console.WriteLine("\nHit any key to continue.");
                Console.ReadKey();
                Console.Clear();


                //Play again
                Console.Write("Play another game? Enter any key to try again or to (x) exit: ");
                string nextRound = Console.ReadLine();          //The player chooses to play another round

                Console.WriteLine("\n");
               
                if ((nextRound == "x" || nextRound == "X"))
                {
                    Console.WriteLine("\nYou chose to EXIT, are you sure?\n\nEnter any key to try again or (x) to EXIT");     //Questions the user's ability to make a decision
                    nextRound = Console.ReadLine();

                    if (nextRound == "x" || nextRound == "X")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("\nGood Game! Bye");              //An attempt at being a good sport
            Console.ReadKey();
        }
    }
}
//      ****Extra Notes****
//  
//  
//  
//  
//  
//  
//  
