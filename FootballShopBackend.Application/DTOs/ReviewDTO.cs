namespace FootballShopBackend.Application.DTOs
{
    public class ReviewDTO
    {
        public string Content { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public DateTime DatePublication { get; set; } 

    }
}
