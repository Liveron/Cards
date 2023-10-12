namespace MAUI.CardsClient.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
