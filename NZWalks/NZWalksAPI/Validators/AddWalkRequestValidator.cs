using FluentValidation;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Validators
{
    public class AddWalkRequestValidator : AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Length).GreaterThan(0);
        }
    }
}
