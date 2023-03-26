using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsUserConfiguration")]
    public class DbUserConfiguration
    {
        [Key]
        [ForeignKey("User")] 
        public int UserId { get; set; }

        public virtual DbUser User { get; set; }
        public bool SendOrderResume { get; set; }
        public string DefaultValuteId { get; set; }
        public bool SubscribeForPromotions { get; set; }
        public bool ShowRetailPrice { get; set; }
        public int? VinSearchLimit { get; set; }
        public DateTime? VinSearchLimitDate { get; set; }
    }
}
