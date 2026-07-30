using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace API_DONACIONES.Dtos
{
    public class CreateDonorDto
    {
       [StringLength(50, ErrorMessage = "El nombre no pueede ser de mas de 50 cacteres")]
       [Required(ErrorMessage = "El Nombre es nesesario")]
       public string? Name {get;set;} 
       [StringLength(30, ErrorMessage ="El tipo de donador es demasiado largo")]
       public string? DonorType {get;set;}
       [StringLength(30,ErrorMessage = "El DNI es demasiado largo" )]
        public string? DNI { get;set;}
       [StringLength(30,ErrorMessage = "El numero de telefono es demasiado largo" )]
       public string? ContactNumber { get;set;}
       [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
       [StringLength(150,ErrorMessage = "El correo electronico es demasiado largo" )]
       public string? Email { get; set; } 
    }
}