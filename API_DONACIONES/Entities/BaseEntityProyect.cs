using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_DONACIONES.Entities
{
    public class BaseEntityProyect
    {
        [Key]
        [Column("id")]
        public string? Id { get; set; }

        [Column("created_by_id")]
        public string? CreatedById {get; set;}

        [Column("created_date")]
        public DateTime CreateDate {get; set;}

        [Column("modified_by_id")]
        public string? ModifiedById {get; set;}

        [Column("modified_date")]
        public DateTime ModifiedDate {get; set;}
    }
}