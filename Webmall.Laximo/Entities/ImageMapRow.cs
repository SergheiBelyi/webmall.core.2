namespace Webmall.Laximo.Entities
{
    public class ImageMapRow
    {
        /*
x1	+	Координаты области на картинке
y1	+
x2	+
y2	+
type	+	Тип ссылки
code	+	Код детали на картинке, соответствует коду детали в списке деталей узла
        */

        /// <summary>
        /// Координата области на картинке
        /// </summary>
        public int X1 { get; set; }
        /// <summary>
        /// Координата области на картинке
        /// </summary>
        public int X2 { get; set; }
        /// <summary>
        /// Координата области на картинке
        /// </summary>
        public int Y1 { get; set; }
        /// <summary>
        /// Координата области на картинке
        /// </summary>
        public int Y2 { get; set; }
        /// <summary>
        /// Тип ссылки
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Код детали на картинке, соответствует коду детали в списке деталей узла
        /// </summary>
        public string Code { get; set; }

        public ImageMapRow() { }

        public ImageMapRow(global::Laximo.Guayaquil.Data.Entities.ListImageMapByUnitRow info)
        {
            X1 = info.x1;
            X2 = info.x2;
            Y1 = info.y1;
            Y2 = info.y2;
            Type = info.type;
            Code = info.code;
        }
    }
}
