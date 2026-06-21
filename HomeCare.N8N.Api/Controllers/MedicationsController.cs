using HomeCare.N8N.Application.Medications.Interfaces;
using HomeCare.N8N.Application.Medications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.N8N.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        /// <summary>
        /// Create a new medication
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] MedicationInsertViewModel medicationInsertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _medicationService.Add(medicationInsertViewModel);

                if (result)
                {
                    return Ok(result);
                }

                return StatusCode(500, "Failed to create medication");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all medications for a specific user
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<MedicationViewModel>>> GetForUser(long userId)
        {
            try
            {
                var medications = await _medicationService.GetForUser(userId);
                return Ok(medications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
