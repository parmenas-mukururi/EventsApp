namespace api.Database.Entities
{
    public class EventEntity: BaseEntity
    {
        public Guid EventId { get; set; }
        public string? Image { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly Date { get; set; }
        public required TimeOnly Time { get; set; }
        public string Venue { get; set; }
        public decimal Price { get; set; }
    }
}
