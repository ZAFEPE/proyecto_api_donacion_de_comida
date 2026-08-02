using API_DONACIONES.Dtos;
using API_DONACIONES.Codes;
using API_DONACIONES.DataBase;
using API_DONACIONES.Mappers;
using Microsoft.EntityFrameworkCore;
using API_DONACIONES.Entities;

namespace API_DONACIONES.Services
{
    public class DonationService : IDonationService
    {
        private readonly DonacionesDbContext _contextD;

        public DonationService(DonacionesDbContext context)
        {
            _contextD = context;
        }

        // 1. Obtener donación por su ID
        public async Task<ResponseDto<DonationDto>> GetOneByIdDonationAsync(string id)
        {
            var donationEntity = await _contextD.Donations.FirstOrDefaultAsync(d => d.Id == id);
            
            if (donationEntity is null)
            {
                return new ResponseDto<DonationDto>
                {
                    Status = false,
                    Message = "La donación no fue encontrada",
                    StatusCode = HttpStatusCodess.NOT_FOUND
                };
            }

            return new ResponseDto<DonationDto>
            {
                StatusCode = HttpStatusCodess.OK,
                Status = true,
                Message = "Donación encontrada",
                Data = MappersDonaciones.EntitytoDtoDonation(donationEntity)
            };
        }

        // 2. Crear una donación asociada a un DonorId
        public async Task<ResponseDto<DonationDto>> CreateDonationAsync(CreateDonationDto dto, string donorId)
        {
            // Opcional: Verificar que el donante al que se le va a asignar la donación realmente exista
            var donorExists = await _contextD.Donors.AnyAsync(d => d.Id == donorId);
            if (!donorExists)
            {
                return new ResponseDto<DonationDto>
                {
                    StatusCode = HttpStatusCodess.NOT_FOUND,
                    Status = false,
                    Message = $"El donante con ID {donorId} no existe."
                };
            }

            // Convertir DTO a Entidad
            DonationEntity entity = MappersDonaciones.CreateMapperDonation(dto, donorId);

            // Guardar en Base de Datos
            _contextD.Donations.Add(entity);
            await _contextD.SaveChangesAsync();

            // Mapear la entidad guardada a DonationDto para devolver la respuesta
            var resultDto = MappersDonaciones.EntitytoDtoDonation(entity);

            return new ResponseDto<DonationDto>
            {
                StatusCode = HttpStatusCodess.CREATED,
                Status = true,
                Message = "Donación registrada correctamente",
                Data = resultDto
            };
        } 
        public async Task<ResponseDto<DonationDto>> GetByDonorIdAsync(string donorId)
        {
            var donationEntity = await _contextD.Donations
                .FirstOrDefaultAsync(d => d.DonorId == donorId);

            if (donationEntity is null)
            {
                return new ResponseDto<DonationDto>
                {
                    Status = false,
                    Message = "No se encontró donación para este donante",
                    StatusCode = HttpStatusCodess.NOT_FOUND
                };
            }

            return new ResponseDto<DonationDto>
            {
                StatusCode = HttpStatusCodess.OK,
                Status = true,
                Message = "Donación encontrada",
                Data = MappersDonaciones.EntitytoDtoDonation(donationEntity)
            };
        }

        
    }
}