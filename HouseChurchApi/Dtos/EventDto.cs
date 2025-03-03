namespace HouseChurchApi.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<FoodItemDto> FoodItems { get; set; }
    }
}
