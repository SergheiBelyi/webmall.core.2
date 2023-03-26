using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsAddresses")]
    public class DbAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StreetId { get; set; }
        public string StreetName { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("UserId")]
        public virtual DbUser User { get; set; }
    }
}
