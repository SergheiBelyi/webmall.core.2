using System.Collections.Generic;
using System.Linq;
using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Entities
{
    public class UnitInfo
    {
        /*
unitid	+	Внутренний номер категории
name	+	Наименование узла, по возможности, на запрашиваемом языке
note	-	Примечание к узлу, по возможности, на запрашиваемом языке
imageurl	+	URL изображения в котором присутствует переменная size
code	+	Код узла
ssd	+	Данные сервера
filter	-	Код условия. Показывает, что узел может быть не применим к данному автомобилю и требуется уточнение параметров автомобиля.
flag	-	Флаги
         */

        /// <summary>
        /// Внутренний номер категории
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Наименование узла, по возможности, на запрашиваемом языке
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Примечание к узлу, по возможности, на запрашиваемом языке
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// URL изображения в котором присутствует переменная size
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// URL изображения в котором присутствует переменная size
        /// </summary>
        public string SmallImageUrl { get; set; }
        /// <summary>
        /// URL изображения в котором присутствует переменная size
        /// </summary>
        public string LargeImageUrl { get; set; }
        /// <summary>
        /// Код узла
        /// </summary>s
        public string Code { get; set; }
        /// <summary>
        /// Код условия. Показывает, что узел может быть не применим к данному автомобилю и требуется уточнение параметров автомобиля.
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Флаги
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// Детали при поиске по группам
        /// </summary>
        public List<DetailInfo> Details { get; set; }

        public string GetImageUrl(string size)
        {
            return ImageUrl.Replace("%size%", size);
        }

        private Dictionary<string, string> _extAttrTitles;
        public Dictionary<string, string> ExtAttrTitles
        {
            get
            {
                return _extAttrTitles ?? (_extAttrTitles = Details.Aggregate(new Dictionary<string, string>(), (s, info) =>
                {
                    foreach (var item in info.ExtAttributes)
                    {
                        if (!s.ContainsKey(item.Key))
                            s.Add(item.Key, item.Name);
                    }

                    return s;
                }));
            }
        }

        /// <summary>
        /// Данные сервера
        /// </summary>
        public string Ssd { get; set; }

        public UnitInfo() { }

        public UnitInfo(ListUnitsRow u)
        {
            Id = u.unitid;
            ImageUrl = u.imageurl;
            Name = u.name;
            Code = u.code;
            Filter = u.filter;
            Flag = u.flag;
            Ssd = u.ssd;
        }
        public UnitInfo(GetUnitInfoRow u)
        {
            Id = u.unitid.ToString();
            ImageUrl = u.largeimageurl.Replace("%size%", "source");
            Name = u.name;
            Code = u.code;
            Filter = u.filter;
            Flag = u.flag;
            Ssd = u.ssd;
            Note = u.note;
            SmallImageUrl = u.smallimageurl;
            LargeImageUrl = u.largeimageurl;

        }

        public UnitInfo(ListQuickDetailCategoryUnit u)
        {
            Id = u.unitid.ToString();
            ImageUrl = u.imageurl;
            Name = u.name;
            Code = u.code;
            Filter = u.filter;
            Flag = u.flag;
            Ssd = u.ssd;
            Note = u.note;

            Details = u.Detail.Select(i => new DetailInfo(i)).ToList();
        }
    }
}