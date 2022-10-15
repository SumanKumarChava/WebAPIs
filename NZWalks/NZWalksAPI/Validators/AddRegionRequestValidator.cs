using FluentValidation;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Validators
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x => x.RegionName).NotEmpty();
            RuleFor(x => x.RegionCode).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.TotalPopulation).GreaterThanOrEqualTo(0);
        }
    }
}
