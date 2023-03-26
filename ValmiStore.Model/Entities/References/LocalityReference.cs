namespace Webmall.Model.Entities.References
{
    public class LocalityReference : SimpleReferenceItem
    {
        ///// <summary>
        ///// Наличие адресной доставки перевозчиков
        ///// </summary>
        //public bool HasAD { get; set; }

        ///// <summary>
        ///// есть пункты выдачи перевозчиков
        ///// </summary>
        //public bool HasDP { get; set; }

        /// <summary>
        /// Является городом по-умолчанию
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
