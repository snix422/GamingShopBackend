namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail
{
    public class ReviewDetailVm 
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }

    }
}
