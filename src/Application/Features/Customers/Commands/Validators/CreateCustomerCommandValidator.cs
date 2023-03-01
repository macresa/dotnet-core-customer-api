using Application.DTOS;
using FluentValidation;

namespace Application.Features.Customers.Commands.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().MinimumLength(1).WithMessage("Debes ingresar un nombre válido");
            RuleFor(c => c.Email).NotNull().EmailAddress();
            RuleFor(c => c.PhoneNumber).NotNull();
        }
    }
}
