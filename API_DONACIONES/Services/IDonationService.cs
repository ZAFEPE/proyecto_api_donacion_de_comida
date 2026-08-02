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
     Task<ResponseDto<DonationDto>> CreateDonationAsync(CreateDonationDto dto, string donorId);
     Task<ResponseDto<DonationDto>> GetByDonorIdAsync(string donorId);
    }
}