using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsVinSearchHistory")]
    public class DbVinSearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string IP { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public string Vin { get; set; }
        public string AutoName { get; set; }
        public bool? IsSuccessful { get; set; }
    
        [ForeignKey("UserId")]
        public virtual DbUser User { get; set; }
    }
}
