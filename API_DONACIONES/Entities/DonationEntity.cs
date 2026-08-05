using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_DONACIONES.Entities
{
    public class DonationEntity : BaseEntityProyect
    {
        [Column("donor_id")]
        public string? DonorId {get;set;}
        [Column("donation_date")]
        public DateTime DonationDate {get;set;}
        [Column("type_food")]
        public string? NameFood {get;set;}
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