
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_DONACIONES.Entities
{
    public class DonorEntity : BaseEntityProyect
    {
        [Column("donor_type")]
        public string? DonorType {get;set;}//escribale ahi tipooo, persona, organizacion y asiS
        [Column("Name")]
        public string? Name {get;set;}
        [Column("dni")]
        public string? DNI {get;set;}
        [Column("contact_number")]
        public string? ContactNumber {get;set;}
        [Column("email")]
        public string? Email {get;set;} 
        public ICollection<DonationEntity> Donations {get;set;}
        = new List<DonationEntity>();
    }
}