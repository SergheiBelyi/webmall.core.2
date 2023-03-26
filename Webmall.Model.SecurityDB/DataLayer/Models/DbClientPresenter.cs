using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsClientPresenter")]

    public class DbClientPresenter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        public string ClientId { get; set; }
        public bool IsAccepted { get; set; }
        public long Roles { get; set; }
        public string CurrentWarehouseId { get; set; }

        [ForeignKey("UserId")]
        public virtual DbUser User { get; set; }
    }
}
