using FluentValidation;
using ShoeService.Models.Requests;

namespace ShoeService.Host.Validators
{
    public class BuyShoesRequestValidator : AbstractValidator<BuyShoesRequest>
    {
        public BuyShoesRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required");

            RuleFor(x => x.ShoeId)
                .NotEmpty().WithMessage("ShoeId is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
