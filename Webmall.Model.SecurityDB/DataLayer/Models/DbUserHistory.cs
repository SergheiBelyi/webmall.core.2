using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsUsersHistory")] 
    public class DbUserHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public int? CurrentPresentationId { get; set; }
        public long Roles { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsBlocked { get; set; }
        public long Status { get; set; }
        public string Comment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLogOnDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
