﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedRPS
{
    class Game
    {
        string[] playerChoices = { "Rock", "Paper", "Scissors" };
        private string userChoice = null;
        uint bestOfCounter = 1;

        public Game()
        {
            this.Introduction();
            this.BestOf();

        }

        private void Introduction()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            var yesNoValidator = new YesNoValidator();
            while (!yesNoValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("\nDo you need to read the instructions?");
                string instructions = Console.ReadLine();
                userChoice = instructions.ToUpper();

                var message = yesNoValidator.Validate(new UserChoice(userChoice));
                Console.WriteLine(message);

                var yesValidator = new YesValidator();
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
            var yesNoValidator = new YesNoValidator();
            while (!yesNoValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("\nWould you like to play a \"best-of\" match?");
                string yesNo = Console.ReadLine();
                userChoice = yesNo.ToUpper();

                var message = yesNoValidator.Validate(new UserChoice(userChoice));
                Console.WriteLine(message);
            }

            var yesValidator = new YesValidator();
            if (yesValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                Console.WriteLine("How many rounds do you want to play?");
                while (!uint.TryParse(Console.ReadLine(), out this.bestOfCounter))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine("The number must be positive.\n");
                }
            }
            this.ClearUserChoice();
        }

        private void RoundCounter()
        {

        }

        public void PlayGame()
        {

        }

        private void ClearUserChoice()
        {
            userChoice = null;
        }
    }
}
