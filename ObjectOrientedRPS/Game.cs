using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedRPS
{
    class Game
    {
        private string userChoice = null;
        public uint bestOfCounter = 1;
        public int roundTicker = 0;
        private int playerWins = 0;
        private int computerWins = 0;

        public Game()
        {
            this.Introduction();
            this.BestOfRequired();
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
                StreamReader instructions = new StreamReader("../../../Instructions.txt");
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

        private uint BestOfRequired()
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
                    Console.WriteLine("Please enter a positive number.");
                }
            }
            this.ClearUserChoice();
            return bestOfCounter;

        }

        public void PlayGame()
        {
            string playerChoice = null;
            string[] weapons = { "Rock", "Paper", "Scissors" };
            int playerWeapon = -1;

            var rockPaperScissorsValidator = new RPSValidator();
            Console.WriteLine("\n**********************************");
            while (!rockPaperScissorsValidator.Validate(new UserChoice(playerChoice)).IsValid)
            {
                Console.Write("Choose your weapon!  ");
                playerChoice = Console.ReadLine().ToUpper();
                if (!rockPaperScissorsValidator.Validate(new UserChoice(playerChoice)).IsValid)
                {
                    Console.Write($"\n{playerChoice} is not a valid input.");
                }
            }

            var rockValidator = new RockValidator();
            var paperValidator = new PaperValidator();
            var scissorsValidator = new ScissorsValidator();
            if (rockValidator.Validate(new UserChoice(playerChoice)).IsValid)
            {
                playerWeapon = 0;
            }
                        
            else if (paperValidator.Validate(new UserChoice(playerChoice)).IsValid)
            {
                playerWeapon = 1;
            }
                        
            else if (scissorsValidator.Validate(new UserChoice(playerChoice)).IsValid)
            {
                playerWeapon = 2;
            }

            Console.WriteLine($"You chose: {weapons[playerWeapon]}!");
            Random choice = new Random();
            int computerWeapon = choice.Next(3);
            Console.WriteLine($"I choose: {weapons[computerWeapon]}!");
            if ((playerWeapon == 0 && computerWeapon == 2) || (playerWeapon == 1 && computerWeapon == 0) || (playerWeapon == 2 && computerWeapon == 1))
            {
                Console.WriteLine("\nNice one! That point is yours.");
                playerWins++;
                Console.WriteLine($"\nYour score is:" + playerWins);
                Console.WriteLine($"My score is:" + computerWins);
                roundTicker++;
            }
            else if ((playerWeapon == 0 && computerWeapon == 1) || (playerWeapon == 1 && computerWeapon == 2) || (playerWeapon == 2 && computerWeapon == 0))
            {
                Console.WriteLine("\nI'll take that point!");
                computerWins++;
                Console.WriteLine($"\nYour score is:" + playerWins);
                Console.WriteLine($"My score is:" + computerWins + "\n");
                roundTicker++;
            }
            else
            {
                Console.WriteLine("\nDarn. It's a tie. \n");
            }
        }

        public bool HasWinner()
        {
            if (computerWins > bestOfCounter / 2 || playerWins > bestOfCounter / 2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool PlayAgain(string yesNo)
        {
            var yesNoValidator = new YesNoValidator();
            Console.WriteLine("Would you like to play again?  ");
            while (!yesNoValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                var message = yesNoValidator.Validate(new UserChoice(userChoice));
                Console.WriteLine(message);
            }

            if (yesNoValidator.Validate(new UserChoice(userChoice)).IsValid)
            {
                return true;
            }

            else
            {
                Console.WriteLine("Thanks for playing!");
                return false;
            }
        }

        private void ClearUserChoice()
        {
            userChoice = null;
        }
    }
}
