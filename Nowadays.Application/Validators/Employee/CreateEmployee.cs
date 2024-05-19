using FluentValidation;
using Nowadays.Application.Features.Commands.Employee.CreateEmployee;

namespace Nowadays.Application.Validators.Employee
{
  public class CreateEmployee : AbstractValidator<CreateEmployeeCommandRequest>
  {
    public CreateEmployee()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
      RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
      RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("Email is not valid.");
      RuleFor(x => x.TCKN).MinimumLength(11).NotEmpty().WithMessage("TCKN is required.");
      RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate is required.");
    }
  }
}
