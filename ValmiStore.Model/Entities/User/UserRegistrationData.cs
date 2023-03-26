using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmall.Model.Entities.References;

namespace Webmall.Model.Entities.User
{
    public class UserRegistrationData : User
    {
        /// <summary>
        /// Признак юридического лица
        /// </summary>
        public bool IsJuridical { get; set; }

        /// <summary>
        /// Коды клиентов (только для автоматической привязки при регистрации)
        /// </summary>
        public string ClientCodes { get; set; }

        public List<SimpleReferenceItem> Custom { get; set; }

        #region JuridicalPersonData

        /// <summary>
        /// Юр. название
        /// </summary>
        public string JuridicalName { get; set; }

        /// <summary>
        /// Юр. адрес
        /// </summary>
        public string JuridicalAddress { get; set; }

        /// <summary>
        /// Фискальный код
        /// </summary>
        public string FiscalCode { get; set; }

        /// <summary>
        /// Расчетный счет
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// Код банка
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// Признак плательщика НДС
        /// </summary>
        public bool ImTVAPayer { get; set; }

        /// <summary>
        /// Код плательщика НДС
        /// </summary>
        public string TVAPayerCode { get; set; }

        /// <summary>
        /// Контактное лицо
        /// </summary>
        public string ContactPerson { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        #endregion
        public string this[string key] => Custom.FirstOrDefault(i => i.Id == key)?.Value;

        public int? GetCustomInt(string key)
        {
            var value = this[key];
            if (string.IsNullOrEmpty(value))
                return null;
            return int.TryParse(value, out var cat) ? cat : (int?) null;
        }
    }
}
