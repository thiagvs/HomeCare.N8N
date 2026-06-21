using HomeCare.N8N.Domain.Medications;

namespace HomeCare.N8N.Data.Medications.Interfaces
{
    public interface IMedicationRepository
    {
        Task<bool> Add(Medication medication);
        Task Delete(Medication medication);
        Task<Medication> GetById(long id);
        Task<List<Medication>> GetForUser(long userId);
    }
}
