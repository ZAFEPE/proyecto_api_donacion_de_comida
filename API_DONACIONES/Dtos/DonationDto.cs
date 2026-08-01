using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DONACIONES.Dtos
{
    public class DonationDto
    {
         public string? Id {get; set;}
        public string?  DonorId { get; set; }
        public DateTime DonationDate { get; set; }// fecha cuando se hizo la donacion
        public string? NameFood { get; set; }//Clasificación: Perecedero, No perecedero, Enlatados, Frescos, Bebidas.
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool NeedsRefrigeration { get; set; } 
    }
}