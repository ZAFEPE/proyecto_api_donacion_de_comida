using Microsoft.AspNetCore.Mvc;
using API_DONACIONES.Services;
using API_DONACIONES.Dtos;
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

        [HttpGet("{id}/GetId")]
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

        [HttpPost("PostDonor")]
        public async Task<ActionResult<ResponseDto<DonorDto>>> CreateDonor([FromBody] DonorDto dto)
        {
            var response = await _Donorservice.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{donorId}/PostDonation")]
        public async Task<ActionResult<ResponseDto<DonationDto>>> CreateDonationForDonor(
            string donorId, 
            [FromBody] CreateDonationDto dto)
        {

            var response = await _Donationservice.CreateDonationAsync(dto, donorId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}/UpdateDonor")]
        public async Task<ActionResult<ResponseDto<DonorDto>>> UpdateDonor(string id, [FromBody] UpdateDonorDto dto)
        {
            var response = await _Donorservice.UpdateDonorAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("{id}/UpdateDonation")]
        public async Task<ActionResult<ResponseDto<DonationDto>>> UpdateDonation(string id, [FromBody] UpdateDonationDto dto)
        {
            var response = await _Donationservice.UpdateDonationAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}/DeleteDonation")] 
        public async Task<IActionResult> DeleteDonation( string id )
        {
            var isDeleted = await _Donationservice.DeleteDonationAsync(id);
            if (!isDeleted)
            {
             return NotFound(new { message = $"No se encontró la donación con el ID {id}" });
            }
            return Ok();
        }
        [HttpDelete("{id}/DeleteDonor")] 
        public async Task<IActionResult> DeleteDonor( string id )
        {
            var isDeleted = await _Donorservice.DeleteDonorAsync(id);//nomas llamo al status pa que si pueda evaluar si fue eliminada o no
            if (!isDeleted)
            {
             return NotFound(new { message = $"No se encontró el donador con el ID {id}" });
            }
            return Ok();
        }

        [HttpGet("AllDonors")]
        public async Task<IActionResult> GetAllDonors()
        {
         var allDonors = await _Donorservice.GetAllDonorAsync();
         return StatusCode(allDonors.StatusCode, allDonors);
        }

        [HttpGet("AllDonations")]
        public async Task<IActionResult> GetAllDonations()
        {
          var allDonations= await _Donationservice.GetAllDonationAsync();
          return StatusCode(allDonations.StatusCode, allDonations);
        } 
    }
}