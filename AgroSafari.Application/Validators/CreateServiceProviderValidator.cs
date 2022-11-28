using AgroSafari.Application.Commands.CreateServiceProvider;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AgroSafari.Application.Validators
{
    public class CreateServiceProviderValidator : AbstractValidator<CreateServiceProviderCommand>
    {
        public CreateServiceProviderValidator()
        {
            RuleFor(c => c.FullName)
                .NotNull().WithMessage("O nome deve ser preenchido!")
                .NotEmpty().WithMessage("O nome deve ser preenchido!")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres!");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O E-mail deve ser informado!")
                .EmailAddress().WithMessage("E-mail inválido!");


            RuleFor(c => c.Age)
                .NotEmpty().WithMessage("A idade deve ser informada!")
                .Must(ValidAge).WithMessage("O prestador de serviço deve ter no mínimo 18 anos!");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("A senha deve ser informada!")
                .NotNull().WithMessage("A senha deve ser informada!")
                .Must(ValidPassword).WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial");

            RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage("O Cnpj deve ser informado!")
                .NotNull().WithMessage("O Cnpj deve ser informado!")
                .Must(ValidCnpj).WithMessage("Cnpj inválido!");
        }

        public bool ValidAge(int age)
        {
            return age >= 18;
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

        public bool ValidCnpj(string cnpj)
        {
                var regex = new Regex(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}");

            return regex.IsMatch(cnpj);
        }
    }
}
