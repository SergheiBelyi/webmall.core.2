using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsVINRequestDetails")]
    public class DbVINRequestDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public string Nums { get; set; }
        public string ResponseComment { get; set; }

        [ForeignKey("RequestId")]
        public virtual DbVINRequest VINRequest { get; set; }
    }
}
