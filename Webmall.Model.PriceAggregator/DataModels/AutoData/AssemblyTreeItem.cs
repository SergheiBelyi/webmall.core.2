using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AssemblyTreeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int? ParentId { get; set; }

        public string WaregroupUid { get; set; }

        public AssemblyTree Children { get; set; } = new AssemblyTree();
    }
}