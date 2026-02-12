using FluentValidation;
using ShoeService.Models.Entities;

namespace ShoeService.Host.Validators
{
    public class ShoeValidator : AbstractValidator<Shoe>
    {
        public ShoeValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required")
                .MinimumLength(2);

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required");

            RuleFor(x => x.Size)
                .GreaterThan(0).WithMessage("Size must be positive");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be positive");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative");
        }
    }
}
