namespace Webmall.Model.Entities.Client
{
    /// <summary>
    /// Информация о валюте
    /// </summary>
    public class Valute
    {
        public string Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Num { get; set; }
        public bool IsDefault { get; set; }
    }
}
