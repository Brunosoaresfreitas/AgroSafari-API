using AgroSafari.Application.Commands.CreateClient;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AgroSafari.Application.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(c => c.FullName)
                .NotNull().WithMessage("O nome deve ser preenchido!")
                .NotEmpty().WithMessage("O nome deve ser preenchido!")
                .Length(3, 50).WithMessage("O nome deve ter entre 3 e 50 caracteres!");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O E-mail deve ser informado!")
                .EmailAddress().WithMessage("E-mail inválido!");


            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento deve ser informada!")
                .Must(ValidBirthDate).WithMessage("O cliente deve ter no mínimo 18 anos!");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("A senha deve ser informada!")
                .NotNull().WithMessage("A senha deve ser informada!")
                .Must(ValidPassword).WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O cpf deve ser informado!")
                .NotNull().WithMessage("O cpf deve ser informado!")
                .Must(ValidCpf).WithMessage("Cpf inválido!");
        }

        public bool ValidBirthDate(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

        public bool ValidCpf(string cpf)
        {
            var regex = new Regex(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}");

            return regex.IsMatch(cpf);
        }
    }
}
