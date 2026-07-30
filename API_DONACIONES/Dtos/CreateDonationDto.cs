using System.ComponentModel.DataAnnotations;

namespace API_DONACIONES.Dtos
{
   public class CreateDonationDto
    {
        [Required(ErrorMessage = "El ID del donante es obligatorio")]
        public string? DonorId { get;set;} 

        [Required(ErrorMessage = "tipo de comida requerida")]
        [StringLength(100, ErrorMessage = "No puede superar los 100 caracteres")]
        public string? TypeFood { get; set; }

        [Required(ErrorMessage = "La descripción del alimento es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede superar los 100 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}