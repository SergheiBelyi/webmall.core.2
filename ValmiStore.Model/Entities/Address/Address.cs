namespace Webmall.Model.Entities.Address
{
    public class Address
    {
        public string AddressId { get; set; }

        /// <summary>
        /// Код региона
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Код нас. пункта
        /// </summary>
        public string LocalityId { get; set; }

        /// <summary>
        /// Наименование нас. пункта
        /// </summary>
        public string LocalityName { get; set; }

        /// <summary>
        /// Код улицы
        /// </summary>
        public string StreetId { get; set; }

        /// <summary>
        /// Наименование улицы
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        private string _house;
        public string House { 
            get => (string.IsNullOrEmpty(_house)) ? "" : _house;
            set => _house = string.IsNullOrEmpty(value) ? null : value.Trim();
        }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        /// Подробности проезда
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string Zip { get; set; }

        public string AddressLine { get; set; }

        public string FullAddress => !string.IsNullOrEmpty(AddressLine) ? AddressLine
                : (string.IsNullOrEmpty(RegionName) ? "" : RegionName + ", ")
                + LocalityName + ", " + StreetName + ", " + House
                + (string.IsNullOrEmpty(Flat) ? "" : ", " + Flat)
                + (string.IsNullOrEmpty(Comment) ? "" : " (" + Comment+")");

    }
}
