namespace HouseChurchApi.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string BroughtBy { get; set; }
        public int EventId { get; set; } // Links to a specific event
    }
}
