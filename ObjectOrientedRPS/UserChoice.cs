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
            var yesOrNo = new List<string> { "Yes", "No", "Y", "N" };
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
            var yes = new List<string> { "Yes", "Y" };
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
            var no = new List<string> { "No", "N" };
            return no.Contains(choice);
        }
    }
}
