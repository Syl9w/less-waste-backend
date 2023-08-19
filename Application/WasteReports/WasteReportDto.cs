namespace Application.WasteReports
{
    public class WasteReportDto
    {
         public Guid Id { get; set; }
        public ReporterDto ReporterDto { get; set; }
        public DateTime Date { get; set; }
        public float Plastic { get; set; }
        public float Paper { get; set; }
        public float Water { get; set; }
        public float Fuel { get; set; }
        public float Food { get; set; }
    }
}