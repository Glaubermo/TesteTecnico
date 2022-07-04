using FluentValidation;
using TesteTecnico.NetCore.API.ServiceApp.DTO;

namespace TesteTecnico.NetCore.API.ServiceApp.Validation
{
    public class EscolaridadeValidation : AbstractValidator<EscolaridadeDTO>
    {
        public EscolaridadeValidation()
        {
            RuleFor(x => x.Descricao).IsInEnum()
                .WithMessage("O {PropertyName} esta Inválido.");
        }
    }
}
