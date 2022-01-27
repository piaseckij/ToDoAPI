using System.Linq;
using FluentValidation;
using ToDoAPI.Entities;

namespace ToDoAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ToDoDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var EmailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (EmailInUse) context.AddFailure("Email", "That email is taken");
                });

            RuleFor(x => x.Username)
                .Custom((value, context) =>
                {
                    var UsernameInUse = dbContext.Users.Any(u => u.Username == value);
                    if (UsernameInUse) context.AddFailure("Username", "That username is taken");
                });
        }
    }
}