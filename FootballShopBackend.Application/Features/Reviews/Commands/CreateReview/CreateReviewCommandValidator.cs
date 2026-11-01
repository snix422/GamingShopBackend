using FluentValidation;

namespace FootballShopBackend.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.");
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author ID is required.");
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

        }
    }
}
