using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsGarages")]
    public class DbCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string ClientId { get; set; }

        [Column("VINCode")]
        public string Vin { get; set; }
        public int? Year { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public int? ModificationId { get; set; }
        public string Comment { get; set; }
        public string Contacts { get; set; }
        public bool? IsSelected { get; set; }
    }
}
