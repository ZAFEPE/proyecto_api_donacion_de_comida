
using System.ComponentModel.DataAnnotations;

namespace API_DONACIONES.Dtos
{
    public class UpdateDonorDto
    {
        [Required(ErrorMessage = "El Nombre es nesesario")]
        public string? Id {get; set;}
        [StringLength(50, ErrorMessage = "El tipo de donador no pueede ser de mas de 50 cacteres")]
        public string? DonorType { get; set; } 
        [StringLength(50, ErrorMessage = "El nombre no pueede ser de mas de 50 cacteres")]
        public string? Name { get; set; } 
        [StringLength(50, ErrorMessage = "El DNI no pueede ser de mas de 50 cacteres")]
        public string? DNI { get; set; }
        [StringLength(50, ErrorMessage = "El numero de contacto no puede ser de mas de 50 cacteres")]
        public string? ContactNumber { get; set; } 
        [StringLength(50, ErrorMessage = "El email no pueede ser de mas de 50 cacteres")]
        [EmailAddress(ErrorMessage = "El Nombre es nesesario")]
        public string? Email { get; set; }
        public bool IsActive {get; set;} = true;
    }
}