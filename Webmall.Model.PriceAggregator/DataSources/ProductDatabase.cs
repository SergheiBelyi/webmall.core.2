using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Webmall.Model.PriceAggregator.DataModels.Brand;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace Webmall.Model.PriceAggregator.DataSources
{
    public class ProductDatabase : DbContext
    {
        public ProductDatabase()
            : base("name=ProductDatabase")
        {
        }

        public IEnumerable<ProductModel> GetGroupWareList (int groupId, int kagId, int stockId, int langId)
        {
            var result = Database.SqlQuery<ProductModel>("GetGroupWareList",
                new SqlParameter("@groupId", groupId),
                new SqlParameter("@kagId", kagId),
                new SqlParameter("@stockId", stockId),
                new SqlParameter("@langId", langId));
            return result;
        }

        public IEnumerable<BrandModel> GetProducersForGroup (int groupId, string language)
        {
            var result = Database.SqlQuery<BrandModel>("GetProducersForGroup",
                new SqlParameter("@GroupId", groupId),
                new SqlParameter("@LanguageId", language));
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
