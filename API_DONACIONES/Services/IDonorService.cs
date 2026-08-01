using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DONACIONES.Dtos;
namespace API_DONACIONES.Services
{
    public interface IDonorService
    {
    Task<ResponseDto<DonorDto>> GetOneByIdDonorAsync(string id);
    Task<ResponseDto<ResponseDonorDto>> CreateDonorAsync(CreateDonorDto dto);
    }
}