namespace HomeCare.N8N.Application.Medications.ViewModels
{
    public class MedicationViewModel
    {
        public required string Name { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool IsPublic { get; set; }
        public int Amount { get; set; }
        public required string PatientName { get; set; }
        public DateTime NextReceivedAt { get; set; }
    }
}
