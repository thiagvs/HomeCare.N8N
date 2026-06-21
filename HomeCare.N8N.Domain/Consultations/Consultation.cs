namespace HomeCare.N8N.Domain.Consultations
{
    public class Consultation
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Speciality { get; set; }
        public required string Institution { get; set; }
        public required string Address { get; set; }
        public DateTime ConsultationDate { get; set; }
        public DateTime RememberAt { get; set; }
    }
}
