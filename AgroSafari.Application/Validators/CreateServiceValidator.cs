using AgroSafari.Application.Commands.CreateService;
using FluentValidation;

namespace AgroSafari.Application.Validators
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty().WithMessage("O título do serviço deve ser informado!")
                .NotNull().WithMessage("O título do serviço deve ser informado!")
                .MaximumLength(50).WithMessage("O título deve conter no máximo 50 caracteres!");

            RuleFor(s => s.Description)
                .NotEmpty().WithMessage("A descrição do serviço deve ser informado!")
                .NotNull().WithMessage("A descrição do serviço deve ser informado!")
                .Length(20, 300).WithMessage("A descrição do serviço deve conter entre 20 e 300 caracteres!");

            RuleFor(s => s.TotalCost)
                .NotNull().WithMessage("O valor deve ser informado!")
                .NotEmpty().WithMessage("O valor deve ser informado!");

            RuleFor(s => s.IdClient)
                .NotNull().WithMessage("O Id do cliente deve ser informado!")
                .NotEmpty().WithMessage("O Id do cliente deve ser informado!");

            RuleFor(s => s.IdServiceProvider)
                .NotNull().WithMessage("O Id do prestador de serviço deve ser informado!")
                .NotEmpty().WithMessage("O Id do prestador de serviço deve ser informado!");
        }
    }
}
