using HomeCare.N8N.Application.Medications.Interfaces;
using HomeCare.N8N.Application.Medications.ViewModels;
using HomeCare.N8N.Data.Medications.Interfaces;
using HomeCare.N8N.Domain.Medications;

namespace HomeCare.N8N.Application.Medications.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public async Task<bool> Add(MedicationInsertViewModel medication)
        {
            var entity = new Medication
            {
                UserId = medication.UserId,
                Name = medication.Name,
                ReceivedAt = Convert.ToDateTime(medication.ReceivedAt),
                NextReceivedAt = medication.NextReceivedAt != null ? Convert.ToDateTime(medication.NextReceivedAt) : new DateTime(),
                IsPublic = medication.IsPublic,
                Amount = medication.Amount,
                PatientName = medication.PatientName,
                CreatedAt = DateTime.UtcNow
            };

            return await _medicationRepository.Add(entity);
        }

        public async Task<List<MedicationViewModel>> GetForUser(long userId)
        {
            var medications = await _medicationRepository.GetForUser(userId);

            return medications.Select(m => new MedicationViewModel
            {
                Name = m.Name,
                ReceivedAt = m.ReceivedAt,
                NextReceivedAt = m.NextReceivedAt,
                IsPublic = m.IsPublic,
                Amount = m.Amount,
                PatientName = m.PatientName
            }).ToList();
        }
    }
}
