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

    class YesNoValidation : AbstractValidator<UserChoice>
    {
        public YesNoValidation()
        {
            RuleFor(x => x.choice).Must(BeAValidYesOrNo);
        }

        private bool BeAValidYesOrNo(string choice)
        {
            var yesOrNo = new List<string> { "Yes", "No", "Y", "N" };
            return yesOrNo.Contains(choice);
        }
    }

    class YesValidation : AbstractValidator<UserChoice>
    {
        public YesValidation()
        {
            RuleFor(x => x.choice).Must(BeAValidYes);
        }

        private bool BeAValidYes(string choice)
        {
            var yes = new List<string> { "Yes", "Y" };
            return yes.Contains(choice);
        }
    }

    class NoValidation : AbstractValidator<UserChoice>
    {
        public NoValidation()
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
