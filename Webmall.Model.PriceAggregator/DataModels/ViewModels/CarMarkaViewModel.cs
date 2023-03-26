using System;
using System.Collections.Generic;
using System.Text;

namespace SERP.Product.Api.Domain.Models.ViewModels
{
    public class CarMarkaViewModel
    {
        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; } // BrandId (Primary key)

        /// <summary>
        /// Название бренда
        /// </summary>
        public string BrandName { get; set; } // BrandName (length: 100)

        public string MarkaShortName { get; set; }
        public string MarkaRemark { get; set; }

    }
}
