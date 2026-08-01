using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DONACIONES.Dtos;
using API_DONACIONES.Codes;
using API_DONACIONES.DataBase;
using API_DONACIONES.Mappers;
using Microsoft.EntityFrameworkCore;
using API_DONACIONES.Entities;
namespace API_DONACIONES.Services
{
    public class DonationService
    {
       private readonly DonacionesDbContext _contextD;//esta variable es un puente con la base de datos
        public DonationService(DonacionesDbContext context)
        {
            _contextD = context;//context se crea en Dbcontext 
        }
        public async Task<ResponseDto<DonorDto>> GetOneByIdDonorAsync(string id)
        {
            var donationEntity = await _contextD.Donors.FirstOrDefaultAsync(d => d.Id == id);//el donors es el que declaramos en dbcontext
            if (donationEntity is null)
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
                Data = MappersDonaciones.EntitytoDtoDonation(donationEntity)//?tambien cambair esto
            };
        }
        public async Task<ResponseDto<ResponseDonorDto>> CreateDonorAsync(CreateDonationDto dto)
        {
            var DonorRegistrado = await _contextD.Donors
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
            DonationEntity entity = MappersDonaciones.CreateMapperDonation(dto);//? error raro
            _contextD.Donations.Add(entity);
            await _contextD.SaveChangesAsync();
            return new ResponseDto<ResponseDonorDto>//esto tambien hay que verlo+
            {
                StatusCode = HttpStatusCodess.CREATED,
                Status = true,
                Message = "Se registro el donante",
                Data  = new ResponseDonorDto//?REVISAr ESTO
              {
                  Id = entity.Id
              }
            };
        } 
    }
}