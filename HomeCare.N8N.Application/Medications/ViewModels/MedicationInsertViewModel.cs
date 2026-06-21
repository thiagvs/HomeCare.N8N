namespace HomeCare.N8N.Application.Medications.ViewModels
{
    public class MedicationInsertViewModel
    {
        public long UserId { get; set; }
        public required string Name { get; set; }
        public required string ReceivedAt { get; set; }
        public string? NextReceivedAt { get; set; }
        public bool IsPublic { get; set; }
        public int Amount { get; set; }
        public required string PatientName { get; set; }
    }
}
