using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DONACIONES.Dtos;
namespace API_DONACIONES.Services
{
    public interface IDonationService
    {
     Task<ResponseDto<DonationDto>> GetOneByIdDonationAsync(string id);
     Task<ResponseDto<ResponseCategoryDto>> CreateDonationAsync(CreateDonationDto dto);
    }
}