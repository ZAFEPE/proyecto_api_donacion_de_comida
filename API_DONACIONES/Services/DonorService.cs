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
        private readonly DonacionesDbContext _contextD;

        public DonorService(DonacionesDbContext context)
        {
            _contextD = context;
        }

        public async Task<ResponseDto<DonorDto>> CreateAsync(DonorDto dto)
        {
            var donorEntity = new DonorEntity
            {
  
                Id = Guid.NewGuid().ToString(), 
                DonorType = dto.DonorType,
                Name = dto.Name,
                DNI = dto.DNI,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email,

            };

            await _contextD.Donors.AddAsync(donorEntity);
            await _contextD.SaveChangesAsync();

            dto.Id = donorEntity.Id;

            return new ResponseDto<DonorDto>
            {
                Status = true,
                StatusCode = HttpStatusCodess.CREATED,
                Message = "Donante creado exitosamente",
                Data = dto
            };
        }

        public async Task<ResponseDto<DonorDto>> GetOneByIdDonorAsync(string id)
        {
            var donorEntity = await _contextD.Donors.FirstOrDefaultAsync(d => d.Id == id);
            
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

          public async Task<bool> DeleteDonorAsync(string id)
        {
          var donor = await _contextD.Donors.FirstOrDefaultAsync(c => c.Id == id);

          if (donor is null)
          {
            return false;
          }
          _contextD.Donors.Remove(donor);
          await _contextD.SaveChangesAsync();
          return true;
        } 
        

        public async Task<ResponseDto<List<DonorDto>>> GetAllDonorAsync()
        {
          var donorEntities = await _contextD.Donors.ToListAsync();
          return new ResponseDto<List<DonorDto>>
          {
            Status = true,
            StatusCode = HttpStatusCodess.OK,
            Message = "Donantes encontrados",
            Data = donorEntities.Select(MappersDonaciones.EntitytoDtoDonor).ToList()
          };
        }
        public async Task<ResponseDto<DonorDto>> UpdateDonorAsync(string id, UpdateDonorDto dto)
        {
            var donor = await _contextD.Donors.FindAsync(id);
            if (donor is null)
            {
                return new ResponseDto<DonorDto>
                {
                    Status = false,
                    StatusCode = HttpStatusCodess.NOT_FOUND,
                    Message = $"No se encontró el donante con ID {id}"
                };
            }

            donor.DonorType = dto.DonorType;
            donor.Name = dto.Name;
            donor.DNI = dto.DNI;
            donor.ContactNumber = dto.ContactNumber;
            donor.Email = dto.Email;

            _contextD.Donors.Update(donor);
            await _contextD.SaveChangesAsync();

            return new ResponseDto<DonorDto>
            {
                Status = true,
                StatusCode = HttpStatusCodess.OK,
                Message = "Donante actualizado correctamente",
                Data = MappersDonaciones.EntitytoDtoDonor(donor)
            };
        }
        
    }
}