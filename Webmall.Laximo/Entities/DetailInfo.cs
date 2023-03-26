using System.Collections.Generic;
using System.Linq;
using Laximo.Guayaquil.Data.Entities;
using Webmall.Laximo.Core;

namespace Webmall.Laximo.Entities
{
    public class DetailInfo
    {
        /*
codeonimage	+	Код детали на иллюстрации для ListDetailByUnit.
name	+/-	Наименование детали, по возможности, на запрошенном языке
note	+/-	Примечание к детали, по возможности, на запрашиваемом языке
price	-/+	Оригинальная цена детали в единицах региона
oem	+	OEM детали
filter	+/-	Код условия. Показывает что деталь может быть не применима к данному автомобилю и требуется уточнение параметров автомобиля.
flag	-	Флаги
match	-	Используется в функции ListQuickDetail с параметром All, показывает что данная деталь входит в искомую группу
designation	-	
applicablemodels	-	
partspec	-	
color	-	Код цвета
shape	-	
standard	-	
material	-	
size	-	
featuredescription	-	
prodstart	-	Дата выпуска - с
prodend	-	Дата выпуска - по
Флаги

№ бита	Маска	Описание
1	0x01	Нестандартная деталь
         */
        /// <summary>
        /// Код детали на иллюстрации для ListDetailByUnit.
        /// </summary>
        public string CodeOnImage { get; set; }

        /// <summary>
        /// Номер варианта
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Наименование детали, по возможности, на запрошенном языке
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Примечание к детали, по возможности, на запрашиваемом языке
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Оригинальная цена детали в единицах региона
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// OEM детали
        /// </summary>
        public string Oem { get; set; }
        /// <summary>
        /// Код условия. Показывает что деталь может быть не применима к данному автомобилю и требуется уточнение параметров автомобиля.
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Флаги
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// Используется в функции ListQuickDetail с параметром All, показывает что данная деталь входит в искомую группу
        /// </summary>
        public string Match { get; set; }
        public string Amount { get; set; }
        public string Designation { get; set; }
        public string Applicablemodels { get; set; }
        public string Partspec { get; set; }
        /// <summary>
        /// Код цвета
        /// </summary>
        public string Color { get; set; }
        public string Shape { get; set; }
        public string Standard { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string FeatureDescription { get; set; }
        /// <summary>
        /// Дата выпуска - с
        /// </summary>
        public string ProdStart { get; set; }
        /// <summary>
        /// Дата выпуска - по
        /// </summary>
        public string ProdEnd { get; set; }
        /// <summary>
        /// Данные сервера
        /// </summary>
        public string Ssd { get; set; }

        private readonly List<string> _fixedAttrs = new List<string>
        {
            "number", "name", "oem", "note"
        };
        public DataAttribute[] ExtAttributes { get; set; }

        public DetailInfo() { }

        public DetailInfo(global::Laximo.Guayaquil.Data.Entities.DetailInfo info)
        {
            CodeOnImage = info.codeonimage;
            Name = string.IsNullOrEmpty(info.name) ? string.IsNullOrEmpty(info.oem) ? "-" : info.oem : info.name;
            Oem = info.oem;
            Filter = info.filter;
            Flag = info.flag;
            Match = info.match;
            if (info.Attributes != null)
            {
                Note = info.Attributes.Where(i => i.Key.ToLower() == "note").Select(i => i.Value).FirstOrDefault();
                Amount = info.Attributes.Where(i => i.Key.ToLower() == "amount").Select(i => i.Value).FirstOrDefault();
            }
            Ssd = info.ssd;
            ExtAttributes = PropertyHelper.GetExtProperties(info.Attributes, _fixedAttrs);
        }
    }
}
