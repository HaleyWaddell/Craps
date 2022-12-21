//Haley Waddell
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            int chips = 100;
            int wager;
            int die1;
            int die2;
            int total;

            while (chips != 0)
            {
                while (true)
                {
                    Console.WriteLine("The Game Craps");

                    Console.WriteLine("How to play Craps:");

                    Console.WriteLine("In each game, you will roll two dice. You have 100 chips!");
                    Console.WriteLine("If the numbers on the dice add up to 2, 3 or 12 on your Come Out Roll, you lose.");
                    Console.WriteLine("If the numbers on the dice add up to 7 or 11 on your Come out Roll, you win.");
                    Console.WriteLine("If the numbers on the dice add up to 4, 5, 6, 8, 9 or 10, that will be come your point.");
                    Console.WriteLine("You will continue to roll until the dices total matches the point, then win.");
                    Console.WriteLine("Or, if a 7 is rolled, you will loose.\n");



                    Console.Write(" \nLets play Craps, begin by making a wager: \n");
                    wager = Convert.ToInt16(Console.ReadLine());
                    if (wager <= chips)
                        break;
                    else
                        Console.Write(" You do not have enough chips to make that wager.");
                }
                //Get dice roll score for dice1 and dice2 (total)
                die1 = GetDieRoll();
                die2 = GetDieRoll();
                // Adding of dice1 + dice2 rolled stored in variable total
                total = die1 + die2;
                // Diplays point from Come out Roll
                Console.WriteLine(" You need to roll a " + total + " to win!" );

                //First winning case (Come out Roll)
                if (total == 7 || total == 11)
                {
                    Console.WriteLine(" You won the game.");
                    chips += 2 * wager;
                }
                //First losing case (Come out Roll) 
                else if (total == 2 || total == 3 || total == 12)
                {
                    Console.WriteLine(" You lost the game.");
                    chips -= wager;
                }
                else
                {   // Point from the come out roll is stored in total
                    int point = total;
                    while (true)
                    {
                        Console.Write(" Do you want to roll dice again(y/n)?");
                        var choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            die1 = GetDieRoll();
                            die2 = GetDieRoll();
                            total = die1 + die2;
                            Console.WriteLine(" You need to roll a : " + total + " to win the game!");
                            //Losing else if loop for default case
                            if (total == 7)
                            {
                                Console.WriteLine(" You lost the game.");
                                chips -= wager;
                                break;
                            }//Winning if loop for default case
                            if (total == point)
                            {
                                Console.WriteLine(" You won the game.");
                                chips += 2 * wager;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
                Console.WriteLine(" Do you want to play another game(y/n)? ");
                var response = Console.ReadLine();
                if (response == "y" && wager > 0)
                    continue;
                else
                    break;
            }//Displays remaining chips for player
            Console.WriteLine(" You have " + chips + " remaining. Thanks for playing Craps!");

        }
        //getDiceRoll method for each roll
        public static int GetDieRoll()
        {
            //creates random dice value
            Random random = new Random();
            return random.Next(1, 6);
        }
    }
}