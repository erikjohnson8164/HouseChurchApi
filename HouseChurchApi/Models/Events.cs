namespace HouseChurchApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }
}
