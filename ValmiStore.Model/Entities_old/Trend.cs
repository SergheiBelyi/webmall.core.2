using System.Collections.Generic;
using System.Linq;

namespace ValmiStore.Model.Entities
{
    public class Trend
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool UseApplicability { get; set; }

        public bool SelectionByAutoOff { get; set; }
        public bool OriginalCatalogOff { get; set; }

        public int ContentId { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        //public List<WareProperty> Properties { get; set; }

        public bool UseAutoCard { get; set; }
        public bool UseWareNum { get; set; }
        public bool OnlyOnStockOff { get; set; }
        public string WareCardTitleTemplate { get; set; }
        public string WareCardKeywordsTemplate { get; set; }
        public string WareCardDescriptionTemplate { get; set; }
        public string BrandCardTitleTemplate { get; set; }
        public string BrandCardKeywordsTemplate { get; set; }
        public string BrandCardDescriptionTemplate { get; set; }
        public bool AllowGenerateBrandGroups { get; set; }
        public bool AllowPromotionsMenu { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Запрет показа новостей для клиентов (список)
        /// </summary>
        public string NewsRestrictedClients { get; set; }

        private List<string> _newsRestrictedClientsList;
        public List<string> NewsRestrictedClientsList
        {
            get
            {
                if (_newsRestrictedClientsList == null)
                    return _newsRestrictedClientsList = (NewsRestrictedClients ?? "")
                        .Split(',', ';', '|').Select(i => i.Trim()).Where(i => !string.IsNullOrWhiteSpace(i)).Distinct().ToList();
                return _newsRestrictedClientsList;
            }
        }
    }
}