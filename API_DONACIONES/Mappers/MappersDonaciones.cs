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
                DonorType = dto.DonorType,
                Name = dto.Name,
                DNI = dto.DNI,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email
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
                ContactNumber = convertir.ContactNumber,
                Email = convertir.Email
          };
        }


        public static DonationEntity  CreateMapperDonation(CreateDonationDto dto,string donorId)
        {
            return new DonationEntity
            {
                Id = Guid.NewGuid().ToString(), 
                DonorId = donorId,
                DonationDate = DateTime.Now,
                NameFood = dto.NameFood,
                Description = dto.Description,
                Quantity = dto.Quantity,
                NeedsRefrigeration = dto.NeedsRefrigeration,
                ExpirationDate = dto.ExpirationDate
            };
        }

        public static DonationDto EntitytoDtoDonation(DonationEntity convertir)
        {
            return new DonationDto
          {
                Id = convertir.Id,
                DonorId = convertir.DonorId,
                DonationDate = convertir.DonationDate,
                NameFood = convertir.NameFood,
                Description = convertir.Description,
                Quantity = convertir.Quantity,
                NeedsRefrigeration = convertir.NeedsRefrigeration
          };
        }
    }
}