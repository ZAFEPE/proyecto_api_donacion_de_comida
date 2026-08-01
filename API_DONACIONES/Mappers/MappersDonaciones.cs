using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DONACIONES.Entities;
using API_DONACIONES.Dtos;
namespace API_DONACIONES.Mappers
{
    public class MappersDonaciones
    {
        public static DonorEntity  CreateMapperDonor(CreateDonorDto dto)
        {
            return new DonorEntity
            {
                Id = Guid.NewGuid().ToString(), 
                Name = dto.Name,
                Email = dto.Email,
                ContactNumber = dto.ContactNumber
            };
     
        }
        public static DonorDto EntitytoDtoDonor(DonorEntity convertir)
        {
            return new DonorDto
          {
                Id = convertir.Id,
                DonorType = convertir.DonorType,
                Name = convertir.Name,
                DNI = convertir.DNI,
                Email = convertir.Email,
                ContactNumber = convertir.ContactNumber
          };
        }


        public static DonationEntity  CreateMapperDonation(CreateDonationDto dto)
        {
            return new DonationEntity
            {
                Id = Guid.NewGuid().ToString(), 
                DonorId = Guid.NewGuid().ToString(),
                DonationDate = DateTime.Now,
                TypeFood = dto.TypeFood,
                Description = dto.Description,
                Quantity = dto.Quantity,
                NeedsRefrigeration = dto.NeedsRefrigeration,
                ExpirationDate = dto.ExpirationDate
            };
        }
    }
}