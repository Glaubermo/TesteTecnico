using FluentValidation;
using System;
using TesteTecnico.NetCore.API.ServiceApp.DTO;

namespace TesteTecnico.NetCore.API.ServiceApp.Validation
{
    public class UsuarioValidation : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidation()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O {PropertyName} e de preenchimento obrigatório.")
                .EmailAddress().WithMessage("O {PropertyName} esta em um formato inválido.")
                .MaximumLength(50).WithMessage("O {PropertyName} deve ter no maximo {MaxLength} .");

            RuleFor(x => x.DataNascimento.Date)
           .NotEmpty().WithMessage("O campo Data Nascimento deve ser informado")
           .LessThanOrEqualTo(DateTime.Now.Date).WithMessage("A Data Nascimento não deve ser superior a data de hoje.");


        }

         
    }
}
