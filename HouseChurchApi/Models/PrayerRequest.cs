namespace HouseChurchApi.Models
{
    public class PrayerRequest
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string RequestText { get; set; }
        public DateTime DateSubmitted { get; set; }
    } 
}
