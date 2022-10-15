using FluentValidation;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Validators
{
    public class AddWalkDifficultyRequestValidator : AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            RuleFor(t => t.Code).NotEmpty();
        }
    }
}
