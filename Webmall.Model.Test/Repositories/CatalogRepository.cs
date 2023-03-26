using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Webmall.Model.Entities;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Entities.Auto;
using System.Linq;
using System.Web;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Entities.Cms;
using StackExchange.Profiling;
using System;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogTestData _testData;
        private readonly ICmsRepository _cmsRepository;
        private Random Rnd => CatalogTestData.Rnd;

        public CatalogRepository(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
            _testData = new CatalogTestData(this);
        }

        public virtual List<WareListItem> GetComplectWares(string localeId, string wareId, string article, string producer)
        {
            throw new NotImplementedException();
        }

        public virtual List<string> GetGroupProducers(string groupId)
        {
            return _testData.Producers.Select(i => i.Id).ToList();
        }

        public virtual List<GroupProperty> GetGroupProperties(string localeId, string groupId)
        {
            return _testData.GroupProperties;
        }

        public virtual List<Producer> GetProducers()
        {
            return _testData.Producers;
        }

        public virtual List<WareListItem> GetRelatedWares(string localeId, string wareId, string article, string producer)
        {
            var list = new List<WareListItem>();
            var count = 0;
            while (count < 10)
            {
                count++;
                list.Add(new WareListItem
                {
                    Url = "#" + count,
                    Id = "0" + count,
                    GroupId = "0",
                    ProducerId = "0",
                    WareNumber = "warenumber",
                    ProducerName = "TRW",
                    Name = "test_" + count,
                    HasImage = false,
                    Description = "desc test " + count,
                    InComplect = false,
                    MinimalPrice = 10,
                    RetailPrice = 9,
                    Qnt = 10,
                    Availability = "availbility",
                    IsAction = true,
                    IsSale = true,
                    IsNew = true,
                    IsOriginal = true
                });
            }
            return list;
        }

        public virtual List<Ware> GetTDWareList(string culture, string groupId, string clientId, string warehouseId, FilterOptions filterOptions, IEnumerable<WareProperty> properties, int? modifId, int? trendId, string sortColumn, SortDirection sortDirection, int skip, int take, out int all, List<SelectListItem> brandList, bool searchBotMode)
        {
            throw new NotImplementedException();
        }

        public virtual Ware GetWare(string localeId, string wareId, string article, string producer)
        {
            return 
                _testData.Wares.FirstOrDefault(i => wareId != null ? i.Id == wareId : i.WareNumber == article && i.ProducerName == producer) 
                ?? _testData.Wares.FirstOrDefault();
        }

        public virtual List<Applicability> GetWareApplicability(string localeId, string wareId, string article, string producer)
        {
            var result = new AutoTestData().Applicability;
            return result;
        }

        public virtual byte[] GetWareFile(string fileId)
        {
            throw new NotImplementedException();
        }

        public virtual FileInfo[] GetWareFiles(string localeId, string wareId, string article, string producer)
        {
            throw new NotImplementedException();
        }

        private void GroupChanges(WareGroups squidex, List<Group> editGroup)
        {
            if (editGroup == null || editGroup.Count == 0) return;

            foreach (var child in editGroup)
            {
                var group = editGroup.FirstOrDefault(i => i.Id == squidex.IdGroup);
                if (group != null)
                {
                    group.Name = squidex.Name;
                    group.Order = squidex.Order;
                    group.Url = squidex.Slug;
                    group.ImageUrl = squidex.ImageUrl;
                    group.IsNew = squidex.IsNew;
                    group.Title = squidex.Title;
                    group.Description = squidex.Description;
                    group.Keywords = squidex.Keywords;
                    group.IconUrl = squidex.IconUrl;
                }

                if (child.SubGroups.Count > 0)
                {
                    GroupChanges(squidex, child.SubGroups);
                }
            }
        }

        private readonly object _getWaregroupsList = new object();
        public virtual List<Group> GetWaregroupsList(string localeId)
        {
            return HttpRuntime.Cache.Get("GetWaregroupsList" + localeId, _getWaregroupsList, () =>
              {
                  using (MiniProfiler.Current.Step("GetWaregroupsList"))
                  {
                      List<Group> GroupsToList(IEnumerable<Group> groups, List<Group> result)
                      {
                          result.AddRange(groups);
                          var groups1 = groups.Aggregate(result, (list, group) =>
                          {
                              if (group.Children?.Any() == true)
                                  GroupsToList(group.Children, list);
                              return list;
                          });
                          return groups1;
                      }

                      var resultList = GroupsToList(GetWaregroups(localeId), new List<Group>());

                      return resultList;
                  }
              });
        }

        public virtual List<Group> GetWaregroups(string localeId)
        {
            var result = _testData.WareGroups;

            if (result.Count > 0)
            {
                var wareGroupsSquidex = _cmsRepository.GetWaregroups();
                if (wareGroupsSquidex.Count > 0)
                {
                    foreach (var item in wareGroupsSquidex)
                    {
                        GroupChanges(item, result);
                    }
                }
            }
            return result;
        }

        public virtual byte[] GetWareImage(string imageId)
        {
            return null;
        }

        public virtual List<string> GetWareImageIds(string localeId, string wareId, string article, string producer)
        {
            return new List<string>();
        }

        public virtual WareList GetWareList(string localeId, FilterOptions filterOptions, PageOptions pageOptions, bool forBot)
        {
            var result = new WareList
            {
                CountAllProduct = _testData.WareList.Count,
                ManufacturerIdentifiers = new List<string> { "1" },
                Wares = new List<WareListItem>()
            };

            var list = _testData.WareList.AsQueryable();

            var producers = filterOptions.Producers?.Where(i=>!string.IsNullOrEmpty(i)).ToArray();
            if (producers?.Length > 0)
                list = list.Where(i => producers.Contains(i.ProducerId));
            if (!string.IsNullOrEmpty(filterOptions.Search))
                list = list.Where(i => i.WareNumber.Contains(filterOptions.Search) || i.Name.Contains(filterOptions.Search));
            if (!string.IsNullOrEmpty(filterOptions.AddQuery))
                list = list.Where(i => i.WareNumber.Contains(filterOptions.AddQuery) || i.Name.Contains(filterOptions.AddQuery));

            var selection = list.ToArray();
            result.CountAllProduct = selection.Length;
            if (!string.IsNullOrEmpty(filterOptions.Search))
                result.ManufacturerIdentifiers = selection.Select(i => i.ProducerId).Distinct().ToList();

            var ordered = selection.OrderBy(i=>i.Id);
            switch (pageOptions.OrderColumn)
            {
                case "WareNumber":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? selection.OrderBy(i => i.WareNumber)
                        : selection.OrderByDescending(i => i.WareNumber);
                    break;
                case "ProducerName":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? selection.OrderBy(i => i.ProducerName)
                        : selection.OrderByDescending(i => i.ProducerName);
                    break;
                case "Name":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? selection.OrderBy(i => i.Name)
                        : selection.OrderByDescending(i => i.Name);
                    break;
            }

            if (pageOptions.OrderColumn != "WareNumber")
            {
                ordered = ordered.ThenBy(i => i.WareNumber);
            }
            result.Wares = ordered.Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize).Take(pageOptions.PageSize).ToList();

            return result;
        }

        private static List<Offer> _offers;
        public virtual List<Offer> GetWareOffers(string localeId, string wareId, string article, string producer, string clientId, string shipmentAddressId, string deliveryAddressId, PageOptions pageOptions)
        {
            if (_offers == null)
            {
                var result = new List<Offer>();
                var cnt = Rnd.Next(1, 30);
                for (int i = 0; i < cnt; i++)
                {
                    var days = Rnd.Next(20);
                    result.Add(new Offer {
                        AvailableQnt = Rnd.Next(100),
                        AvailableQntStr = i % 15 == 0 ? ">5" : null,
                        ClientPrice = Rnd.Next(100),
                        ClientSalePrice = Rnd.Next(100),
                        DeliveryDays = days,
                        DeliveryRating = Rnd.Next(50, 100),
                        DeliveryTerm = DateTime.Now.AddDays(days),
                        SaleQnt = i % 5 == 0 ? Rnd.Next(2, 4) : 1,
                        ReturnDays = i % 5 == 0 ? 0 : 14,
                        SupplierWarehouseName = $"Test{i}"
                    });
                }
                result.OrderBy(i => i.ClientPrice).First().BestPrice = true;
                result.OrderByDescending(i => i.AvailableQnt).First().BestQnt = true;
                result.OrderByDescending(i => i.ReturnDays).First().BestReturn = true;
                result.OrderBy(i => i.DeliveryTerm).First().BestDelivery = true;
                
                _offers = result;
            }

            var ordered = _offers.OrderBy(i => i.ClientPrice);
            switch (pageOptions.OrderColumn)
            {
                case "ClientPrice":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _offers.OrderBy(i => i.ClientPrice)
                        : _offers.OrderByDescending(i => i.ClientPrice);
                    break;
                case "ClientSalePrice":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _offers.OrderBy(i => i.ClientSalePrice)
                        : _offers.OrderByDescending(i => i.ClientSalePrice);
                    break;
                case "AvailableQnt":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _offers.OrderBy(i => i.AvailableQnt)
                        : _offers.OrderByDescending(i => i.AvailableQnt);
                    break;
                case "SupplierWarehouseName":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _offers.OrderBy(i => i.SupplierWarehouseName)
                        : _offers.OrderByDescending(i => i.SupplierWarehouseName);
                    break;
                case "DeliveryTerm":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _offers.OrderBy(i => i.DeliveryTerm)
                        : _offers.OrderByDescending(i => i.DeliveryTerm);
                    break;
            }

            return ordered.ToList();
        }

        public virtual List<WareProperty> GetWareProperties(string localeId, string wareId, string article, string producer)
        {
            return _testData.WareProperties;
        }

        private static List<WareReplacement> _replacements;

        public virtual List<WareReplacement> GetWareReplacements(string localeId, string wareId, string article,
            string producer, string clientId, string shipmentAddressId, string deliveryAddressId,
            FilterOptions filterOptions, PageOptions pageOptions)
        {
            if (_replacements == null)
            {
                var result = new List<WareReplacement>();
                var cnt = Rnd.Next(1, 30);
                for (int i = 0; i < cnt; i++)
                {
                    var days = Rnd.Next(20);
                    result.Add(new WareReplacement
                    {
                        Ware = _testData.WareList[Rnd.Next(_testData.WareList.Count)],
                        AvailableQnt = Rnd.Next(100),
                        AvailableQntStr = i % 15 == 0 ? ">5" : null,
                        ClientPrice = Rnd.Next(100),
                        ClientSalePrice = Rnd.Next(100),
                        DeliveryDays = days,
                        DeliveryRating = Rnd.Next(50, 100),
                        DeliveryTerm = DateTime.Now.AddDays(days),
                        SaleQnt = i % 5 == 0 ? Rnd.Next(2, 4) : 1,
                        ReturnDays = i % 5 == 0 ? 0 : 14,
                        SupplierWarehouseName = $"TestRepl{i}"
                    });
                }
                _replacements = result;
            }

            var ordered = _replacements.OrderBy(i => i.ClientPrice);
            switch (pageOptions.OrderColumn)
            {
                case "ClientPrice":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.ClientPrice)
                        : _replacements.OrderByDescending(i => i.ClientPrice);
                    break;
                case "ClientSalePrice":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.ClientSalePrice)
                        : _replacements.OrderByDescending(i => i.ClientSalePrice);
                    break;
                case "AvailableQnt":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.AvailableQnt)
                        : _replacements.OrderByDescending(i => i.AvailableQnt);
                    break;
                case "SupplierWarehouseName":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.SupplierWarehouseName)
                        : _replacements.OrderByDescending(i => i.SupplierWarehouseName);
                    break;
                case "DeliveryTerm":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.DeliveryTerm)
                        : _replacements.OrderByDescending(i => i.DeliveryTerm);
                    break;
                case "Name":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.Ware.Name)
                        : _replacements.OrderByDescending(i => i.Ware.Name);
                    break;
                case "ProducerName":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.Ware.ProducerName)
                        : _replacements.OrderByDescending(i => i.Ware.ProducerName);
                    break;
                case "WareNumber":
                    ordered = pageOptions.Direction == SortDirection.Ascending
                        ? _replacements.OrderBy(i => i.Ware.WareNumber)
                        : _replacements.OrderByDescending(i => i.Ware.WareNumber);
                    break;
            }

            return ordered.ToList();
            
        }

        List<AvailableNumber> ICatalogRepository.GetAvailableNumbersForSearch(string clientId, string search, int searchType)
        {
            search = search.ToLower().Trim();
            var result = _testData.Wares.Where(i => i.WareNumber.ToLower().Contains(search)).Take(20).Select(i => new AvailableNumber
            {
                Value = i.Id,
                Number = i.WareNumber,
                WareName = i.Name,
                ProducerId = i.ProducerId,
                ProducerName = i.ProducerName
            }).ToList();
            return result;
        }

    }
}
