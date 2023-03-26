using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml;

namespace Webmall.UI.Models.Payments
{
    public class ProcessingResponseModel
    {
        public ProcessingResponseModel(XmlDocument doc)
        {
            try
            {
                var transactionId = doc.GetElementsByTagName("TransactionId")[0].InnerText;
                TransactionId = long.Parse(transactionId);
            }
            catch (Exception)
            {
            }

            try
            {
                var externalTransactionId = doc.GetElementsByTagName("ExternalTransactionId")[0].InnerText;
                ExternalTransactionId = externalTransactionId;
            }
            catch (Exception)
            {
            }

            try
            {
                var referenceNumber = doc.GetElementsByTagName("ReferenceNumber")[0].InnerText;
                ReferenceNumber = referenceNumber;
            }
            catch (Exception)
            {
            }

            try
            {
                var transactionParentId = doc.GetElementsByTagName("TransactionParentId")[0].InnerText;
                this.TransactionParentId = long.Parse(transactionParentId);
            }
            catch (Exception)
            {
            }

            try
            {
                var action = doc.GetElementsByTagName("Action")[0].InnerText;
                Action = action;
            }
            catch (Exception)
            {
            }

            try
            {
                var merchantNumber = doc.GetElementsByTagName("MerchantNumber")[0].InnerText;
                MerchantNumber = merchantNumber;
            }
            catch (Exception)
            {
            }

            try
            {
                var merchantTerminal = doc.GetElementsByTagName("MerchantTerminal")[0].InnerText;
                MerchantTerminal = merchantTerminal;
            }
            catch (Exception)
            {
            }

            try
            {
                var currency = doc.GetElementsByTagName("Currency")[0].InnerText;
                Currency = currency;
            }
            catch (Exception)
            {
            }

            try
            {
                var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

                var amount = doc.GetElementsByTagName("Amount")[0].InnerText.Replace(".", decimalSeparator);
                Amount = decimal.Parse(amount);
            }
            catch (Exception)
            {
            }

            try
            {
                var cCType = doc.GetElementsByTagName("CCType")[0].InnerText;
                this.CCType = cCType;
            }
            catch (Exception)
            {
            }

            try
            {
                var creditCardNumber = doc.GetElementsByTagName("CreditCardNumber")[0].InnerText;
                CreditCardNumber = creditCardNumber;
            }
            catch (Exception)
            {
            }

            try
            {
                var descriptor = doc.GetElementsByTagName("Descriptor")[0].InnerText;
                Descriptor = descriptor;
            }
            catch (Exception)
            {
            }

            try
            {
                var date = doc.GetElementsByTagName("Date")[0].InnerText;
                Date = DateTime.Parse(date);
            }
            catch (Exception)
            {
            }

            try
            {
                var dateChangeStatus = doc.GetElementsByTagName("DateChangeStatus")[0].InnerText;
                DateChangeStatus = DateTime.Parse(dateChangeStatus);
            }
            catch (Exception)
            {
            }

            try
            {
                var fName = doc.GetElementsByTagName("FName")[0].InnerText;
                FName = fName;
            }
            catch (Exception)
            {
            }

            try
            {
                var lName = doc.GetElementsByTagName("LName")[0].InnerText;
                LName = lName;
            }
            catch (Exception)
            {
            }

            try
            {
                var address = doc.GetElementsByTagName("Address")[0].InnerText;
                Address = address;
            }
            catch (Exception)
            {
            }

            try
            {
                var city = doc.GetElementsByTagName("City")[0].InnerText;
                City = city;
            }
            catch (Exception)
            {
            }

            try
            {
                var state = doc.GetElementsByTagName("State")[0].InnerText;
                State = state;
            }
            catch (Exception)
            {
            }

            try
            {
                var province = doc.GetElementsByTagName("Province")[0].InnerText;
                Province = province;
            }
            catch (Exception)
            {
            }

            try
            {
                var zip = doc.GetElementsByTagName("Zip")[0].InnerText;
                Zip = zip;
            }
            catch (Exception)
            {
            }

            try
            {
                var country = doc.GetElementsByTagName("Country")[0].InnerText;
                Country = country;
            }
            catch (Exception)
            {
            }

            try
            {
                var phoneNumber = doc.GetElementsByTagName("PhoneNumber")[0].InnerText;
                PhoneNumber = phoneNumber;
            }
            catch (Exception)
            {
            }

            try
            {

            }
            catch (Exception)
            {
            }

            try
            {
                var email = doc.GetElementsByTagName("Email")[0].InnerText;
                Email = email;
            }
            catch (Exception)
            {
            }

            try
            {
                var cS1 = doc.GetElementsByTagName("CS1")[0].InnerText;
                CS1 = cS1;
            }
            catch (Exception)
            {
            }

            try
            {
                var cS2 = doc.GetElementsByTagName("CS2")[0].InnerText;
                CS2 = cS2;
            }
            catch (Exception)
            {
            }

            try
            {
                var cS3 = doc.GetElementsByTagName("CS3")[0].InnerText;
                CS3 = cS3;
            }
            catch (Exception)
            {
            }

            try
            {

                var cS5 = doc.GetElementsByTagName("CS5")[0].InnerText;
                CS5 = cS5;
            }
            catch (Exception)
            {
            }
        }

        public long TransactionId
        {
            get;
            set;
        }

        public string ExternalTransactionId
        {
            get;
            set;
        }

        public string ReferenceNumber
        {
            get;
            set;
        }

        public long TransactionParentId
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        public string MerchantNumber
        {
            get;
            set;
        }

        public string MerchantTerminal
        {
            get;
            set;
        }

        public string Currency
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string CCType
        {
            get;
            set;
        }

        public string CreditCardNumber
        {
            get;
            set;
        }

        public string Descriptor
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public DateTime DateChangeStatus
        {
            get;
            set;
        }

        [StringLength(50)]
        public string FName
        {
            get;
            set;
        }

        [StringLength(50)]
        public string LName
        {
            get;
            set;
        }

        [StringLength(100)]
        public string Address
        {
            get;
            set;
        }

        [StringLength(50)]
        public string City
        {
            get;
            set;
        }

        [StringLength(3)]
        public string State
        {
            get;
            set;
        }

        [StringLength(50)]
        public string Province
        {
            get;
            set;
        }

        [StringLength(10)]
        public string Zip
        {
            get;
            set;
        }

        [StringLength(3)]
        public string Country
        {
            get;
            set;
        }

        [StringLength(20)]
        public string PhoneNumber
        {
            get;
            set;
        }

        [StringLength(50)]
        public string Email
        {
            get;
            set;
        }

        public string CS1
        {
            get;
            set;
        }

        public string CS2
        {
            get;
            set;
        }

        public string CS3
        {
            get;
            set;
        }

        public string CS5
        {
            get;
            set;
        }
    }
}