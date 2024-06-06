using FluentValidation;

namespace Application.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Firstname).NotEmpty().MaximumLength(20);
            RuleFor(p => p.Middlename).MaximumLength(40);
            RuleFor(p => p.Lastname).NotEmpty().MaximumLength(20);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.MobileNumber).NotEmpty().Length(13).WithMessage("Number must be 13 digit").Must(e => e.StartsWith("+20")).WithMessage("Must start with Egypt Code +20");
            RuleFor(p => p.BirthDate).NotEmpty().LessThan(DateTime.Now.AddYears(-20)).WithMessage("You must be at least 20 years old");

            When(e => e.HasAddress, () =>
            {
                RuleFor(p => p.CityId).NotEmpty();
                RuleFor(p => p.GovernorateId).NotEmpty();
                RuleFor(p => p.BuildingNumber).NotEmpty();
                RuleFor(p => p.FlatNumber).NotEmpty();
                RuleFor(p => p.Street).NotEmpty();
            });
        }
    }
}
