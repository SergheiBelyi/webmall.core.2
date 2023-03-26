using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{

    [Table("vsVinRequests")]
    public class DbVINRequest
    {
        public DbVINRequest()
        {
            VINDetails = new HashSet<DbVINRequestDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? AnswerDate { get; set; }
        public string VINCode { get; set; }
        public int? MarkaId { get; set; }
        public string MarkaName { get; set; }
        public int? ModelId { get; set; }
        public string ModelName { get; set; }
        public int? ModifId { get; set; }
        public string ModifName { get; set; }
        public string Year { get; set; }
        public string Comment { get; set; }
        public bool IsRepsonded { get; set; }
        public int? ManagerId { get; set; }
        public string EngineNumber { get; set; }
        public string TransmissionType { get; set; }
    
        [ForeignKey("UserId")]
        public virtual DbUser User { get; set; }
        public virtual ICollection<DbVINRequestDetail> VINDetails { get; set; }
    }
}
