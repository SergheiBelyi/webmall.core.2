namespace Webmall.Model.Entities.User
{
    public class UserFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public bool IsManager { get; set; }
        public bool IsRepresentativeManager { get; set; }
        public bool IsVINRequestManager { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsKeyRepresentative { get; set; }
        public string ClientCode { get; set; }
        public string ClientId { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsNotAccepted { get; set; }
    }
}
