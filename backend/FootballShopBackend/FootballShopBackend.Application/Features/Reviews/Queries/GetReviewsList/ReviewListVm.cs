namespace FootballShopBackend.Application.Features.Review.Queries.GetReviewsList
{
    public class ReviewListVm
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;

        public DateTime PublicationDate { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

    }
}
