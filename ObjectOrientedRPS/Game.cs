using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedRPS
{
    class Game
    {
        string[] playerChoices = { "Rock", "Paper", "Scissors" };
        string userChoice = null;

        public Game()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            this.Introduction();
            this.BestOf();
        }

        private void Introduction()
        {
            var validator = new YesNoValidation();
            while (!validator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("\nDo you need to read the instructions?");
                string instructions = Console.ReadLine();
                userChoice = instructions.ToUpper();
                if (!validator.Validate(new UserChoice(userChoice)).IsValid)
                {
                    Console.WriteLine("\nPlease choose either \"Yes\" or \"No\".");
                }

                var yesValidator = new YesValidation();
                if (yesValidator.Validate(new UserChoice(userChoice)).IsValid)
                {
                    this.Instructions();
                    break;
                }
            }
            this.ClearUserChoice();
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
                this.ClearUserChoice();
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void BestOf()
        {
            uint bestOfCounter = 1;

            var validator = new YesNoValidation();
            while (!validator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("\nWould you like to play a \"best-of\" match?");
                string yesNo = Console.ReadLine();
                userChoice = yesNo.ToUpper();
                if (!validator.Validate(new UserChoice(userChoice)).IsValid)
                {
                    Console.WriteLine("\nNot a valid input, try again.");
                    Console.WriteLine("******************************");
                }
            }
            var yesValidator = new YesValidation();
            if (yesValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("How many rounds do you want to play?");
                while (!uint.TryParse(Console.ReadLine(), out bestOfCounter))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine("The number must be positive.\n");
                }
            }
            this.ClearUserChoice();
        }

        private void ClearUserChoice()
        {
            userChoice = null;
        }
    }
}
