using Bamboo.Core.Models.Auth;
using FluentValidation;

namespace Bamboo.Core.Validators
{
    public class AuthModelValidator
    {
        public class CreateAuthModelValidator : AbstractValidator<CreateAuthModel>
        {
            public CreateAuthModelValidator()
            {
                RuleFor(x => x.ConfirmPassword).Equal(y => y.Password);
            }
        }
    }
}
