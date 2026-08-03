using Microsoft.AspNetCore.Mvc;
using API_DONACIONES.Services;
using API_DONACIONES.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http.HttpResults;
namespace API_DONACIONES.Controllers
{   
    [ApiController]
    [Route("api/donors")]
    public class Controllers : ControllerBase
    {
        private readonly IDonorService _Donorservice;
        private readonly IDonationService _Donationservice;

        public Controllers(IDonorService donorService, IDonationService donationService)
        {
            _Donorservice = donorService;
            _Donationservice = donationService;
        }

        [HttpGet("{id}/Get Id")]
        public async Task<ActionResult<ResponseDto<DonorWithDonationDto>>> GetOne(string id)
        {
            var donorResponse = await _Donorservice.GetOneByIdDonorAsync(id);
            var donationResponse = await _Donationservice.GetByDonorIdAsync(id);

            var combinedData = new DonorWithDonationDto
            {
                Donor = donorResponse.Data,
                Donation = donationResponse.Data
            };
            return Ok(new ResponseDto<DonorWithDonationDto>
            {
                Status = true,
                Message = "Información obtenida correctamente",
                Data = combinedData
            });
        }

        [HttpPost("Post Donor")]
        public async Task<ActionResult<ResponseDto<DonorDto>>> CreateDonor([FromBody] DonorDto dto)
        {
            var response = await _Donorservice.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{donorId}/ Post Donation")]
        public async Task<ActionResult<ResponseDto<DonationDto>>> CreateDonationForDonor(
            string donorId, 
            [FromBody] CreateDonationDto dto)
        {

            var response = await _Donationservice.CreateDonationAsync(dto, donorId);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("{id}/Delete Donation")] 
        public async Task<IActionResult> DeleteDonation( string id )
        {
            var isDeleted = await _Donationservice.DeleteDonationAsync(id);
            if (!isDeleted)
            {
             return NotFound(new { message = $"No se encontró la donación con el ID {id}" });
            }
            return Ok();
        }
        [HttpDelete("{id}/Delete Donor")] 
        public async Task<IActionResult> DeleteDonor( string id )
        {
            var isDeleted = await _Donorservice.DeleteDonorAsync(id);// nomas llamo al status pa que si pueda evaluar si fue eliminada o no
            if (!isDeleted.Status)
            {
             return NotFound(new { message = $"No se encontró el donador con el ID {id}" });
            }
            return Ok();
        }

        [HttpGet("All Donors")]
        public async Task<IActionResult> GetAllDonors()
        {
         var allDonors = await _Donorservice.GetAllDonorAsync();
         return StatusCode(allDonors.StatusCode, allDonors);
        }

        [HttpGet("All donations")]
        public async Task<IActionResult> GetAllDonations()
        {
          var allDonations= await _Donationservice.GetAllDonationAsync();
          return StatusCode(allDonations.StatusCode, allDonations);
        } 
    }
}