using API_DONACIONES.DataBase;
using API_DONACIONES.Dtos;
using Microsoft.EntityFrameworkCore;
using API_DONACIONES.Entities;
using API_DONACIONES.Codes;
using API_DONACIONES.Mappers;

namespace API_DONACIONES.Services
{
    public class DonorService : IDonorService
    {
        private readonly DonacionesDbContext _context;

        public DonorService(DonacionesDbContext context)
        {
            _context = context;
        }

        // 1. Crear un Donante
        public async Task<ResponseDto<DonorDto>> CreateAsync(DonorDto dto)
        {

            // Mapear a entidad
            var donorEntity = new DonorEntity
            {
  
                Id = Guid.NewGuid().ToString(), 
                DonorType = dto.DonorType,
                Name = dto.Name,
                DNI = dto.DNI,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email,

            };

            await _context.Donors.AddAsync(donorEntity);
            await _context.SaveChangesAsync();

            dto.Id = donorEntity.Id;

            return new ResponseDto<DonorDto>
            {
                Status = true,
                StatusCode = HttpStatusCodess.CREATED,
                Message = "Donante creado exitosamente",
                Data = dto
            };
        }

        // Obtener Donante por ID
        public async Task<ResponseDto<DonorDto>> GetOneByIdDonorAsync(string id)
        {
            var donorEntity = await _context.Donors.FirstOrDefaultAsync(d => d.Id == id);
            
            if (donorEntity is null)
            {
                return new ResponseDto<DonorDto>
                {
                    Status = false,
                    Message = "El donante no fue encontrado",
                    StatusCode = HttpStatusCodess.NOT_FOUND
                };
            }

            return new ResponseDto<DonorDto>
            {
                StatusCode = HttpStatusCodess.OK,
                Status = true,
                Message = "Donante encontrado",
                Data = MappersDonaciones.EntitytoDtoDonor(donorEntity)
            };
        }
    }
}