using HomeCare.N8N.Application.Medications.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.N8N.Application.Medications.Interfaces
{
    public interface IMedicationService
    {
        Task<bool> Add(MedicationInsertViewModel medication);
        Task<List<MedicationViewModel>> GetForUser(long userId);
    }
}
