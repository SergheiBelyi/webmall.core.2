using System.ComponentModel.DataAnnotations;
using ViewRes;
using Webmall.UI.Core.Attributes;

namespace Webmall.UI.Models.Payments
{
    public class PaymentModel
    {
        public decimal CurrentBalance
        {
            get;
            set;
        }

        [Required]
        public string ProductName { get; set; }
        public ValmiStore.Model.Entities.Order.Order Order { get; set; }

        public string OrderId { get; set; }

        public string TransactionId { get; set; }

        public bool ShowBillingInfo { get; set; }

        #region --- Billing Info ---
        [DisplayNameEx("FirstName", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "FirstNameWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string FName
        {
            get;
            set;
        }

        [DisplayNameEx("LastName", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "LastNameWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string LName
        {
            get;
            set;
        }

        [DisplayNameEx("Address", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(100, ErrorMessageResourceName = "AddressWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string Address
        {
            get;
            set;
        }

        [DisplayNameEx("City", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "CityRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "CityWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string City
        {
            get;
            set;
        }

        public string State
        {
            get { return string.Empty; }
        }

        //[Required(ErrorMessage = REQUIRED)]
        //[StringLength(50, ErrorMessage = STRINGLENGTH)]
        //[Display(Name = "Район")]
        public string Province { get; set; }

        [DisplayNameEx("Zip", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "ZipRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(10, ErrorMessageResourceName = "ZipWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string Zip
        {
            get;
            set;
        }

        [DisplayNameEx("Country", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "CountryRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(3, ErrorMessageResourceName = "CountryWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string Country
        {
            get;
            set;
        }

        [DisplayNameEx("Phone", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(20, ErrorMessageResourceName = "PhoneWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string PhoneNumber
        {
            get;
            set;
        }

        [DisplayNameEx("Email", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "EmailWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "WrongEmailAddress")]
        public string Email
        {
            get;
            set;
        }
        #endregion

        public bool ShowShippingInfo { get; set; }

        #region --- Shipping Info ---

        [DisplayNameEx("FirstName", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "FirstNameWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipFName { get; set; }

        [DisplayNameEx("LastName", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "LastNameWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipLName { get; set; }

        [DisplayNameEx("Phone", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(20, ErrorMessageResourceName = "PhoneWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipPhoneNumber { get; set; }

        [DisplayNameEx("Zip", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "ZipRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(10, ErrorMessageResourceName = "ZipWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipZip { get; set; }

        public string ShipState
        {
            get { return string.Empty; }
        }

        //[Required(ErrorMessage = REQUIRED)]
        //[StringLength(50, ErrorMessage = STRINGLENGTH)]
        //[Display(Name = "Район")]
        public string ShipProvince { get; set; }

        [DisplayNameEx("Country", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "CountryRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(3, ErrorMessageResourceName = "CountryWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipCountry
        {
            get { return "MDA"; }
        }

        [DisplayNameEx("City", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "CityRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(50, ErrorMessageResourceName = "CityWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipCity { get; set; }

        [DisplayNameEx("Address", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(SharedResources))]
        [StringLength(100, ErrorMessageResourceName = "AddressWrongLength", ErrorMessageResourceType = typeof(SharedResources))]
        public string ShipAddress { get; set; }

        #endregion

        [Required]
        [StringLength(3)]
        public string Currency
        {
            get { return "MDL"; }
        }

        private string _amount;

        [DisplayNameEx("SumLei", NameResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value.Replace(',', '.');
            }
        }

        public string CardNumber { get; set; }
    }
}