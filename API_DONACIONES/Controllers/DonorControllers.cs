using Microsoft.AspNetCore.Mvc;
using API_DONACIONES.Services;
using API_DONACIONES.Dtos;

namespace API_DONACIONES.Controllers
{   
    [ApiController]
    [Route("api/donors")]
    public class DonorControllers : ControllerBase
    {
        private readonly IDonorService _Donorservice;
        private readonly IDonationService _Donationservice;

        public DonorControllers(IDonorService donorService, IDonationService donationService)
        {
            _Donorservice = donorService;
            _Donationservice = donationService;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<DonorWithDonationDto>>> GetOne(string id)
        {
            var donorResponse = await _Donorservice.GetOneByIdDonorAsync(id);
            var donationResponse = await _Donationservice.GetOneByIdDonationAsync(id);

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

        // POST: api/donors
        [HttpPost]
        public async Task<ActionResult<ResponseDto<DonorDto>>> CreateDonor([FromBody] DonorDto dto)
        {
            var response = await _Donorservice.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{donorId}/donations")]
        public async Task<ActionResult<ResponseDto<DonationDto>>> CreateDonationForDonor(
            string donorId, 
            [FromBody] CreateDonationDto dto)
        {

            var response = await _Donationservice.CreateDonationAsync(dto, donorId);
            return StatusCode(response.StatusCode, response);
        }



    }
}