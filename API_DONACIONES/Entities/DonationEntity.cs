using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_DONACIONES.Entities
{
    public class DonationEntity : BaseEntityProyect
    {
        [Column("donor_id")]
        public string? DonorId {get;set;}
        [Column("DonationDate")]
        public DonorEntity? Donor {get;set;}// est0 representa todo donor Entity waos
        public DateTime DonationDate {get;set;}
        [Column("type_food")]
        public string? TypeFood {get;set;}
        [Column("description")]
        public string? Description {get;set;}
        [Column("quantity")]
        public int Quantity {get;set;}
        [Column("needs_refrigeration")]
        public bool NeedsRefrigeration {get;set;}
        [Column("expiration_date")]
        public DateTime? ExpirationDate {get;set;}
    }
}