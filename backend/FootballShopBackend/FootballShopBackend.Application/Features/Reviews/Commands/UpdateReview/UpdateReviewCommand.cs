using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommand : IRequest
{
    public Guid ReviewId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public override string ToString()
    {
        return $"Content: {Content}, AuthorName: {AuthorName}, ProductId: {ProductId}";
    }
}
