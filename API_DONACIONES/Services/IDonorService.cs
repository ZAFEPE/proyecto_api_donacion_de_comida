using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DONACIONES.Dtos;
namespace API_DONACIONES.Services
{
    public interface IDonorService
    {
    Task<ResponseDto<DonorDto>> GetOneByIdAsync(string id);
    Task<ResponseDto<ResponseCategoryDto>> CreateAsync(CreateDonorDto dto);
    }
}