using System.Net;

namespace FootballShopBackend.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }

    public DateTime PublicationDate { get; set; }
  
}
