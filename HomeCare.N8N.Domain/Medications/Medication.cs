namespace HomeCare.N8N.Domain.Medications
{
    public class Medication
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime NextReceivedAt { get; set; }
        public bool IsPublic { get; set; }
        public int Amount { get; set; }
        public required string PatientName { get; set; }
    }
}
