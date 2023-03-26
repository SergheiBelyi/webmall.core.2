namespace Webmall.Model.Entities.Order
{
    public class PositionStatus
    {
        /// <summary>
        /// Код статуса позиции
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// Наименование статуса позиции
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Количество позиций в статусе
        /// </summary>
        public int Qnt { get; set; }
    }
}
