using API_DONACIONES.DataBase;
using API_DONACIONES.Dtos;
using Microsoft.EntityFrameworkCore;
using API_DONACIONES.Entities;
using System.Net;
using API_DONACIONES.Codes;
using API_DONACIONES.Mappers;
namespace API_DONACIONES.Services
{
    public class DonorService : IDonorService
    {
        private readonly DonacionesDbContext _context;//esta variable es un puente con la base de datos
        public DonorService(DonacionesDbContext context)
        {
            _context = context;//context se crea en Dbcontext 
        }
        public async Task<ResponseDto<DonorDto>> GetOneByIdDonorAsync(string id)
        {
            var donorEntity = await _context.Donors.FirstOrDefaultAsync(d => d.Id == id);//el donors es el que declaramos en dbcontext
            if (donorEntity is null)
            {
                return new ResponseDto<DonorDto>
                {
                    Status = false,
                    Message = "el donante no se ncontrado",
                    StatusCode = HttpStatusCodess.NOT_FOUND
                };
            }
            return new ResponseDto<DonorDto>
            {
                StatusCode = HttpStatusCodess.OK,
                Status = true,
                Message = "Donante encontraddo",
                Data = MappersDonaciones.EntitytoDtoDonor(donorEntity)
            };
        }
        public async Task<ResponseDto<ResponseDonorDto>> CreateDonorAsync(CreateDonorDto dto)
        {
            var DonorRegistrado = await _context.Donors
            .FirstOrDefaultAsync(c => c.Name == dto.Name);
            if (DonorRegistrado is not null)
            {
                return new ResponseDto<ResponseDonorDto>
                {
                    StatusCode = HttpStatusCodess.BAD_REQUEST,
                    Status = false,
                    Message = $"La categorìa {dto.Name} ya se encuentra registrada."
                };
            }
            DonorEntity entity = MappersDonaciones.CreateMapperDonor(dto);
            _context.Donors.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseDto<ResponseDonorDto>
            {
                StatusCode = HttpStatusCodess.CREATED,
                Status = true,
                Message = "Se registro el donante",
                Data  = new ResponseDonorDto
              {
                  Id = entity.Id
              }
            };
        }
    }
}