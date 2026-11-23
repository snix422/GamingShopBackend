namespace FootballShopBackend.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
