using System;
using Webmall.Model.PriceAggregator.DataModels.Brand;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public class CarMarkaModel : IAuditable
    {
        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; }

        public int? MarkaId { get; set; }
        public string MarkaName { get; set; }
        public string MarkaShortName { get; set; }
        public string MarkaRemark { get; set; }

        /// <summary>
        /// Момент создания
        /// </summary>
        public DateTime? CreatedDateTime { get; set; } // CreatedDateTime

        /// <summary>
        /// Кто создал
        /// </summary>
        public string CreatedBy { get; set; } // CreatedBy (length: 150)

        /// <summary>
        /// Момент последнего изменения
        /// </summary>
        public DateTime? UpdatedDateTime { get; set; } // UpdatedDateTime

        /// <summary>
        /// Кто последним изменил
        /// </summary>
        public string UpdatedBy { get; set; } // UpdatedBy (length: 150)

        /// <summary>
        /// 
        /// </summary>
        public virtual BrandModel BrandModel { get; set; } // FK_CarMarka_Brand
    }
}