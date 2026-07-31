using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_DONACIONES.Entities
{
    public class DonationEntity : BaseEntityProyect
    {
        [Column("donor_id")]
       public Guid DonorId { get; set; }//id_donante	Clave foránea (FK)	Enlace con el id_donante de la tabla anterior. No me acorde como se hacia esto, Herencia de alguna forma supongo pero no se \(#o#)/
        [Column("DonationDate")]
        public DonorEntity? Donor { get; set; }
        public DateTime DonationDate { get; set; }// fecha cuando se hizo la donacion
        [Column("type_food")]
        public string? TypeFood { get; set; }//Clasificación: Perecedero, No perecedero, Enlatados, Frescos, Bebidas.
        [Column("description")]
        public string? Description { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("needs_refrigeration")]
        public bool NeedsRefrigeration { get; set; } // pos eso si necesita refrigeracion.
        [Column("expiration_date")]
        public DateTime? ExpirationDate { get; set; }
    }
}