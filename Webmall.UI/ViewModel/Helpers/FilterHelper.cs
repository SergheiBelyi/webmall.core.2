using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.UI.Models.Catalog;
using Webmall.UI.ViewModel.Catalog;
using Webmall.UI.ViewModel.Filter;

namespace Webmall.UI.ViewModel.Helpers
{
    public static class FilterHelper
    {
        //public static CatalogFilterViewModel CreateFilterViewModel(this FilterModel m)
        //{
        //    var vm = new CatalogFilterViewModel();
        //    if (m != null)
        //        vm.Fill(m);
        //    return vm;
        //}

        //public static void Fill(this CatalogFilterViewModel vm, FilterModel m)
        //{
        //    vm.AutoSubmit = m.AutoSubmit;
        //    vm.PriceMin = m.PriceMin;
        //    vm.PriceMax = m.PriceMax;
        //    vm.ShowPriceFilter = m.ShowPriceFilter;
        //    vm.ShowSearchFilter = m.ShowSearchFilter;
        //    vm.Search = m.Search;
        //    vm.AddQuery = m.AddQuery;
        //    vm.OnlyActions = m.OnlyActions;
        //    vm.OnlySales = m.OnlySales;

        //    if (m.Categories != null && m.Categories.Any())
        //    {
        //        vm.GroupSection = new SelectViewModel
        //        {
        //            Caption = SharedResources.ProductCategory,
        //            Name = "groups",
        //            SectionIsOpened = true,
        //            ShowSelectMoreLink = false,
        //            SectionIsHidden = false,
        //            AutoSubmit = m.AutoSubmit,
        //        };

        //        foreach (var item in m.Categories)
        //        {
        //            var selected = m.SelectedGroups != null && m.SelectedGroups.Contains(item.Id);
        //            vm.GroupSection.Options.Add(new SelectListItem { Value = item.Id, Text = item.Name, Selected = selected });
        //        }

        //    }

        //    if (m.Brands != null && m.Brands.Any())
        //    {
        //        vm.BrandSection = new SelectViewModel
        //        {
        //            Caption = SharedResources.Brand,
        //            Name = "producers",
        //            SectionIsOpened = true,
        //            ShowSelectMoreLink = true,
        //            SectionIsHidden = false,
        //            AutoSubmit = m.AutoSubmit,
        //            IsFilterable = true,
        //            FilterTitle = SharedResources.BrandFilterPlaceholder
        //        };

        //        foreach (var group in m.Brands.GroupBy(i => i.IsOEM).OrderByDescending(i => i.Key))
        //        {
        //            foreach (var item in group.OrderBy(i => i.Name))
        //            {
        //                var selected = m.SelectedProducers?.Contains(item.Id) ?? false;
        //                vm.BrandSection.Options.Add(new SelectListItem { Value = item.Id, Text = item.Name, Selected = selected });
        //            }
        //            //showMoreOption = false;
        //        }

        //    }

        //    var propertySections = new List<SelectViewModel>();
        //    if (m.WareProperties != null)
        //    {
        //        foreach (var group in m.WareProperties.OrderByDescending(i => i.Importance).ThenBy(i => i.Name))
        //        {
        //            var section = new SelectViewModel
        //            {
        //                Caption = group.Name,
        //                Name = "properties",
        //                SectionIsOpened = false,
        //                SectionIsHidden = !m.ShowAllSections,
        //                AutoSubmit = m.AutoSubmit,
        //                IsFilterable = group.AvailableValues.Count > 30,
        //                ShowSelectMoreLink = true
        //            };
        //            foreach (var item in group.AvailableValues)
        //            {
        //                //var id = item.Id.Trim().ToHex() + CommonHelpers.PropertyDivider + group.Name.Trim().ToHex();
        //                var id = item.Id;
        //                var selected = (m.SelectedProperties != null && m.SelectedProperties.Contains(id));
        //                section.Options.Add(new SelectListItem { Text = item.Value, Value = id, Selected = selected });
        //            }

        //            if (section.Options.Any(i => i.Selected))
        //            {
        //                section.SectionIsOpened = true;
        //            }

        //            propertySections.Add(section);
        //        }
        //    }

        //    // Показ брэндов в развернутом виде если кроме них ничего нет
        //    //if (!propertySections.Any())
        //    //{
        //    //    vm.BrandSection.ShowSelectMoreLink = false;
        //    //}

        //    if (propertySections.Any(i => i.SectionIsHidden))
        //    {
        //        var last = propertySections.LastOrDefault(i => !i.SectionIsHidden);
        //        if (last != null)
        //        {
        //            last.ShowSelectMoreLink = true;
        //        }
        //    }

        //    vm.PropertySections = propertySections;
        //}
    }
}