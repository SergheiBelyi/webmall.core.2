using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;
using Webmall.UI.ViewModel.Filter;

namespace Webmall.UI.ViewModel.Catalog
{
    public class CatalogFilterViewModel
    {
        public bool AutoSubmit { get; set; } = false;

        #region Поиск по результату

        /// <summary>
        /// Признак показа блока поиск в найденном
        /// </summary>
        public bool ShowSearchFilter { get; set; } = false;

        /// <summary>
        /// Признак показа фильтра цен
        /// </summary>
        public bool ShowPriceFilter { get; set; }

        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string Search { get; set; }

        #endregion

        //#region Стартовый набор

        ///// <summary>
        ///// Признак показа акционного товара
        ///// </summary>
        //public bool? OnlyActions { get; set; }

        ///// <summary>
        ///// Признак показа распродажи
        ///// </summary>
        //public bool? OnlySales { get; set; }

        ///// <summary>
        ///// Признак показа новинок
        ///// </summary>
        //public bool? OnlyNew { get; set; }

        //#endregion Стартовый набор

        //#region Цена и наличие

        ///// <summary>
        ///// Признак показа блока Цена
        ///// </summary>
        //public bool ShowPriceFilter { get; set; } = false;
        //public int? PriceMin { get; set; }
        //public int? PriceMax { get; set; }
        ///// <summary>
        ///// Только то, что в наличии
        ///// </summary>
        //public bool OnlyInPresence { get; set; }

        //#endregion

        /// <summary>
        /// Поисковая строка "поиск в найденном"
        /// </summary>
        public string AddQuery { get; set; }

        // form the group data list
        public SelectViewModel GroupSection { get; set; } = new SelectViewModel();

        // form the brands data list
        public SelectViewModel BrandSection { get; set; } = new SelectViewModel();

        // form the Properties data list
        public List<SelectViewModel> PropertySections { get; set; } = new List<SelectViewModel>();


        public static T Create<T>(FilterOptions options, List<Group> groups, List<Producer> brands, List<GroupProperty> props) where T : CatalogFilterViewModel
        {
            var vm = (T) Activator.CreateInstance(typeof(T));
            vm.Fill(options, groups, brands, props);
            return vm;
        }

        public void Fill(FilterOptions options, List<Group> groups, List<Producer> brands, List<GroupProperty> props)
        {
            //AutoSubmit = m.AutoSubmit;
            //PriceMin = m.PriceMin;
            //PriceMax = m.PriceMax;
            //ShowPriceFilter = m.ShowPriceFilter;
            //ShowSearchFilter = m.ShowSearchFilter;
            //Search = m.Search;
            //AddQuery = m.AddQuery;
            //OnlyActions = m.OnlyActions;
            //OnlySales = m.OnlySales;

            if (groups != null && groups.Any())
            {
                GroupSection = new SelectViewModel
                {
                    Caption = SharedResources.ProductCategory,
                    Name = "groups",
                    SectionIsOpened = true,
                    ShowSelectMoreLink = false,
                    SectionIsHidden = false,
                    //AutoSubmit = m.AutoSubmit,
                };

                foreach (var item in groups)
                {
                    var selected = options.WareGroupId != null && item.Id == options.WareGroupId;
                    GroupSection.Options.Add(new SelectListItem { Value = item.Id, Text = item.Name, Selected = selected });
                }
            }

            if (brands != null && brands.Any())
            {
                BrandSection = new SelectViewModel
                {
                    Caption = SharedResources.Brand,
                    Name = "producers",
                    SectionIsOpened = true,
                    ShowSelectMoreLink = true,
                    SectionIsHidden = false,
                    //AutoSubmit = m.AutoSubmit,
                    IsFilterable = true,
                    FilterTitle = SharedResources.BrandFilterPlaceholder
                };

                foreach (var group in brands.GroupBy(i => i.IsOEM).OrderByDescending(i => i.Key))
                {
                    foreach (var item in group.OrderBy(i => i.Name))
                    {
                        var selected = options.Producers?.Contains(item.Id) ?? false;
                        BrandSection.Options.Add(new SelectListItem { Value = item.Id, Text = item.Name, Selected = selected });
                    }
                }
            }

            var propertySections = new List<SelectViewModel>();
            if (props != null)
            {
                foreach (var group in props.OrderByDescending(i => i.Importance).ThenBy(i => i.Name))
                {
                    var section = new SelectViewModel
                    {
                        Caption = group.Name,
                        Name = "properties",
                        SectionIsOpened = false,
                        //SectionIsHidden = !m.ShowAllSections,
                        //AutoSubmit = m.AutoSubmit,
                        IsFilterable = group.AvailableValues.Count > 30,
                        ShowSelectMoreLink = true
                    };
                    foreach (var item in group.AvailableValues)
                    {
                        //var id = item.Id.Trim().ToHex() + CommonHelpers.PropertyDivider + group.Name.Trim().ToHex();
                        var id = item.Id;
                        var selected = (options.Properties != null && options.Properties.Contains(id));
                        section.Options.Add(new SelectListItem { Text = item.Value, Value = id, Selected = selected });
                    }

                    if (section.Options.Any(i => i.Selected))
                    {
                        section.SectionIsOpened = true;
                    }

                    propertySections.Add(section);
                }
            }

            if (propertySections.Any(i => i.SectionIsHidden))
            {
                var last = propertySections.LastOrDefault(i => !i.SectionIsHidden);
                if (last != null)
                {
                    last.ShowSelectMoreLink = true;
                }
            }

            PropertySections = propertySections;
        }
    }
}