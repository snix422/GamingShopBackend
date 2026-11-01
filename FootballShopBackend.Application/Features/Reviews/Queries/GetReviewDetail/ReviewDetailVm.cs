namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail
{
    public class ReviewDetailVm 
    {
        public Guid ReviewId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }

    }
}
