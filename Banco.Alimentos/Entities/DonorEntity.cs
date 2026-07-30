
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BancoAlimentos.Entities
{
    public class DonorEntity : BaseEntityProyect
    {
        [Column("donor_type")]
        public string? DonorType { get; set; } // Categoría: Particular, Supermercado, Restaurante, Empresa, ONG.
        [Column("Name")]
        public string? Name { get; set; } // nombre del donante
        [Column("dni")]
        public string? DNI { get; set; } // Numero de identidad asociado al donante
        [Column("contact_number")]
        public string? ContactNumber { get; set; } // numero de telefono para contactar al donante.
        [Column("email")]
        public string? Email { get; set; } // ps un correo obvio 
    }
}