using FluentValidation;
using System;

namespace eIMIC223925.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required!")
                .MaximumLength(200).WithMessage("First name cannot over 200 character!");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required!")
                .MaximumLength(200).WithMessage("Last name cannot over 200 character!");

            // những người đăng kí k được vượt quá 100 tuổi, ví dụ hiện tại 2022-100 = 1922, nếu dưới 1922 là k dc
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match!");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required!");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!")
                .MinimumLength(6).WithMessage("Password is at least 6 characters!");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match!");
                }
            });
        }
    }
}
