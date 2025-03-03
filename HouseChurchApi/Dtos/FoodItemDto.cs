namespace HouseChurchApi.Dtos
{
    public class FoodItemDto
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string BroughtBy { get; set; }
        public int EventId { get; set; }
    }
}
