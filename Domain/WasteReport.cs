namespace Domain
{
    public class WasteReport
    {
        public Guid Id { get; set; }
        public AppUser Reporter { get; set; }
        public DateTime Date { get; set; }
        public float Plastic { get; set; }
        public float Paper { get; set; }
        public float Water { get; set; }
        public float Fuel { get; set; }
        public float Food { get; set; }
    }
}