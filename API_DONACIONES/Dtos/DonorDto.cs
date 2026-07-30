using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API_DONACIONES.Dtos
{
    public class DonorDto//es lo que se mostrara al cliente
    {
        public string? Id {get; set;}
        public string? DonorType { get; set; } 
        public string? Name { get; set; } 
        public string? DNI { get; set; }
        public string? ContactNumber { get; set; } 
        public string? Email { get; set; }
        public bool IsActive {get; set;} = true;
    }
}