using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommand : IRequest<Guid>
{
    public string Content { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
    public Guid ProductId { get; set; }

    public override string ToString()
    {
        return $"Content: {Content}, AuthorId: {AuthorId}, ProductId: {ProductId}";
    }

}
