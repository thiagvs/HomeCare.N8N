using HomeCare.N8N.Data.Context;
using HomeCare.N8N.Data.Medications.Interfaces;
using HomeCare.N8N.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.N8N.Data.Medications.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Medication medication)
        {
            try
            {
                _context.Medication.Add(medication);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Delete(Medication medication)
        {
            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();
        }

        public async Task<Medication> GetById(long id)
        {
            return await _context.Medication.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Medication>> GetForUser(long userId)
        {
            return await _context.Medication
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }
    }
}
