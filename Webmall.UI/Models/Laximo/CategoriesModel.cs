using System;
using System.Collections.Generic;
using Webmall.Laximo.Entities;
using Webmall.Model.Abstract;

namespace Webmall.UI.Models.Laximo
{
    [Serializable]
    public class CategoriesModel : BaseModel
    {
        public VehicleInfo VehicleInfo { get; set; }
        public CatalogInfo CatalogInfo { get; set; }

        public List<ICommonTreeComposite<Category>> Categories { get; set; }
        public List<UnitInfo> Units { get; set; }
        public ICommonTreeComposite<Category> SelectedCategory { get; set; }

    }
}