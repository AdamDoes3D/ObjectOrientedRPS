using FluentValidation;
using System.Collections.Generic;

namespace ObjectOrientedRPS
{
    class UserChoice
    {
        public string choice;

        public UserChoice(string choice)
        {
            this.choice = choice;
        }
    }

    class YesNoValidator : AbstractValidator<UserChoice>
    {
        public YesNoValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidYesOrNo).WithMessage("Please choose either \"Yes\" or \"No\".");
        } 

        private bool BeAValidYesOrNo(string choice)
        {
            var yesOrNo = new List<string> { "YES", "NO", "Y", "N" };
            return yesOrNo.Contains(choice);
        }
    }

    class YesValidator : AbstractValidator<UserChoice>
    {
        public YesValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidYes);
        }

        private bool BeAValidYes(string choice)
        {
            var yes = new List<string> { "YES", "Y" };
            return yes.Contains(choice);
        }
    }

    class NoValidator : AbstractValidator<UserChoice>
    {
        public NoValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidNo);
        }

        private bool BeAValidNo(string choice)
        {
            var no = new List<string> { "NO", "N" };
            return no.Contains(choice);
        }
    }
    class RPSValidator : AbstractValidator<UserChoice>
    {
        public RPSValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidRPS).WithMessage("Please try again with Rock (R), Paper (P), or Scissors (S).");
        }

        private bool BeAValidRPS(string choice)
        {
            var rockPaperScissors = new List<string> { "ROCK", "R", "PAPER", "P", "SCISSORS", "S"};
            return rockPaperScissors.Contains(choice);
        }
    }

    class RockValidator : AbstractValidator<UserChoice>
    {
        public RockValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidRock);
        }

        private bool BeAValidRock(string choice)
        {
            var rock = new List<string> { "ROCK", "R" };
            return rock.Contains(choice);
        }
    }

    class PaperValidator : AbstractValidator<UserChoice>
    {
        public PaperValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidPaper);
        }

        private bool BeAValidPaper(string choice)
        {
            var paper = new List<string> { "PAPER", "P" };
            return paper.Contains(choice);
        }
    }

    class ScissorsValidator : AbstractValidator<UserChoice>
    {
        public ScissorsValidator()
        {
            RuleFor(x => x.choice).Must(BeAValidScissors);
        }

        private bool BeAValidScissors(string choice)
        {
            var scissors = new List<string> { "SCISSORS", "S" };
            return scissors.Contains(choice);
        }
    }

}
