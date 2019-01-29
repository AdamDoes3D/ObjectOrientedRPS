using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedRPS
{
    class Game
    {
        string[] playerChoices = { "Rock", "Paper", "Scissors" }; 

        public Game()
        {
            this.Introduction();
            this.BestOf();
        }

        private void Introduction()
        {
            string instructionsNeeded = null;

            while (instructionsNeeded != "Y" && instructionsNeeded != "N" && instructionsNeeded != "YES" && instructionsNeeded != "NO")
            {
                Console.WriteLine("Welcome to Rock, Paper, Scissors!");
                Console.WriteLine("\nDo you need to read the instructions?");
                string instructions = Console.ReadLine();
                instructionsNeeded = instructions.ToUpper();
                if (instructionsNeeded != "Y" && instructionsNeeded != "N" && instructionsNeeded != "YES" && instructionsNeeded != "NO")
                {
                    Console.WriteLine("\nPlease choose either \"Yes\" or \"No\".");
                    Console.WriteLine("\n******************************");
                }

                if (instructionsNeeded == "Y" || instructionsNeeded == "YES")
                {
                    this.Instructions();
                }
            }
        }

        private void Instructions()
        {
            string line;

            try
            {
                StreamReader instructions = new StreamReader("C://Users/Adam/source/repos/ObjectOrientedRPS/ObjectOrientedRPS/obj/Instructions.txt");

                line = instructions.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = instructions.ReadLine();
                }

                instructions.Close();
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void BestOf()
        {
            string bestOf = null;
            uint bestOfCounter = 1;

            while (bestOf != "Y" || bestOf != "YES" || bestOf != "N" || bestOf != "NO")
            {
                Console.WriteLine("\nWould you like to play a \"best-of\" match?");
                string yesNo = Console.ReadLine();
                bestOf = yesNo.ToUpper();
                if (bestOf != "Y" && bestOf != "N" && bestOf != "YES" && bestOf != "NO")
                {
                    Console.WriteLine("\nNot a valid input, try again.");
                    Console.WriteLine("******************************");
                }
            }
            if (bestOf == "Y" || bestOf == "YES")
            {
                Console.WriteLine("How many rounds do you want to play?");
                while (!uint.TryParse(Console.ReadLine(), out bestOfCounter))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine("The number must be positive.\n");
                }
            }
        }
    }
}
