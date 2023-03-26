namespace ValmiStore.Model.Entities.User
{
    public class LoyaltyListItem
    {
        /// <summary>
        /// Год
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// Квартал
        /// </summary>
        public string Quater { get; set; }

        /// <summary>
        /// План оборота "Loyalty Program" за квартал, euro
        /// </summary>
        public string Column1 { get; set; }

        /// <summary>
        /// Факт оборота "Loyalty Program" за квартал, euro
        /// </summary>
        public string Column2 { get; set; }

        /// <summary>
        /// % выполнения, квартал
        /// </summary>
        public string Column3 { get; set; }

        /// <summary>
        /// % выполнения в динамике
        /// </summary>
        public string Column4 { get; set; }

        /// <summary>
        /// Сумма Бонуса "Loyalty Program" за квартал, lei
        /// </summary>
        public string Column5 { get; set; }

        /// <summary>
        /// Сумма использованного Бонуса "Loyalty Program", lei
        /// </summary>
        public string Column6 { get; set; }

        /// <summary>
        /// Сумма накопленного Бонуса "Loyalty Program", lei
        /// </summary>
        public string Column7 { get; set; }
    }
}