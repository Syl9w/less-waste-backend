namespace Domain
{
    public class WasteGoal
    {
        public Guid Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public float TargetPlastic { get; set; }
        public float TargetPaper { get; set; }
        public float TargetWater { get; set; }
        public float TargetFood { get; set; }
        public float TargetFuel { get; set; }

        public float ProgressPlastic { get; set; }
        public float ProgressPaper { get; set; }
        public float ProgressWater { get; set; }
        public float ProgressFood { get; set; }
        public float ProgressFuel { get; set; }
    }
}