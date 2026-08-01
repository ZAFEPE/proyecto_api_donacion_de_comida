using System.ComponentModel.DataAnnotations;

namespace API_DONACIONES.Dtos
{
   public class CreateDonationDto
    {
        [Required(ErrorMessage = "es nesesario que introduzca el nombre de la comida")]
        [StringLength(100, ErrorMessage = "No puede superar los 100 caracteres")]
        public string? NameFood { get; set; }
        public DateTime DonationDate{get; set;}

        [Required(ErrorMessage = "La descripción del alimento es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede superar los 100 caracteres")]
        public string? Description { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Debe introducir si nesesita o no refrigeracion" )]
        public bool NeedsRefrigeration {get;set;}
        public DateTime? ExpirationDate { get; set; }
    }
}