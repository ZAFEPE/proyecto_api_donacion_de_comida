using Microsoft.AspNetCore.Mvc;
using API_DONACIONES.Services;
using API_DONACIONES.Dtos;
namespace API_DONACIONES.Controllers
{   
    [ApiController]
    [Route("api/Donaciones")]
    public class CategoryControllers : ControllerBase
    {
        //  private readonly IDonorService _Donorservice;
        //  private readonly IDonationService _Donationservice;
         [HttpGet("{id}")] 
          public async Task<ActionResult<ResponseDto<DonorDto>>> GetOne(string id)
          {
            var response = await _Donorservice.GetOneByIdDonorAsync(id);
            var response2 = await _Donorservice.GetOneByIdDonationAsync(id);

            return StatusCode (response. StatusCode, new ResponseDto<DonorDto> 
           {
            Status=response. Status, 
            Message= response. Message, 
            Data= response. Data
           });
          }          

    
    }
    
}