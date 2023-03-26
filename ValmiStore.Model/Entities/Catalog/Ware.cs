using System.Linq;

namespace Webmall.Model.Entities.Catalog
{
    public class Ware
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string ProducerId { get; set; }
        public string WareNumber { get; set; }
        public string ProducerName { get; set; }
        public string Name { get; set; }
        public bool HasImage => Images?.Any() == true;
        public string Description { get; set; }
        public bool InComplect { get; set; } // нет в модели что приходит с прайсов
        public string MeasureUnit { get; set; }
        public bool InAction { get; set; } // нет в модели что приходит с прайсов
        public bool IsSale { get; set; } // нет в модели что приходит с прайсов
        public bool IsNew { get; set; } // нет в модели что приходит с прайсов
        public bool IsOriginal { get; set; } // нет в модели что приходит с прайсов

        public ImageInfo[] Images { get; set; } // нет в модели что приходит с прайсов
        public Producer Producer { get; set; }
    }
}
