using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.ViewModel;
using Webmall.UI.ViewModel.Brands;
using Webmall.UI.ViewModel.Common;
using Webmall.UI.ViewModel.Filter;

namespace Webmall.UI.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ICmsRepository _cmsRepository;
        private readonly ICatalogRepository _catalogRepository;

        //private readonly ILaximoRepository _laximoRepository;

        public BrandsController(ICmsRepository cmsRepository, ICatalogRepository catalogRepository)
        {
            _cmsRepository = cmsRepository;
            _catalogRepository = catalogRepository;
        }

        public ActionResult Info(string id)
        {
            //var tmp = _cmsRepository.GetBrands();
            var model = _catalogRepository.GetProducers().FirstOrDefault(i=>i.Name == id); // _cmsRepository.GetBrandArticle(id) ?? _cmsRepository.GetBrandArticle("default");
            if (model == null)
                return new HttpNotFoundResult();

            ViewBag.Title = model.Title;
            ViewBag.Keywords = model.Keywords;
            ViewBag.Description = model.Description;
            return View(model);
        }

        public ActionResult Index(BrandFilterOptions filterOptions, GridViewOptions pageOptions)
        {
            //var model = _cmsRepository.GetBrands();
            var allProducers = _catalogRepository.GetProducers();
            var producers = ApplyFilters(filterOptions, allProducers);


            //producers = producers.Where(i => i.Name.StartsWith("febi ", true, CultureInfo.InvariantCulture));

            /*ViewBag.Title = model.Title;
            ViewBag.Keywords = model.Keywords;
            ViewBag.Description = model.Description;*/
            pageOptions.PageSize = 50;
            var model = new BrandListViewModel
            {
                Data = producers.OrderBy(i=>i.Name).ToList().AsGridView(ControllerContext, pageOptions, null),
                BreadCrumbs = new List<BreadCrumbsModel>(),
                FilterModel = CreateFilterModel (filterOptions, allProducers),
                FilterOptions = filterOptions
            };

            return View(model);
        }

        private static IQueryable<Producer> ApplyFilters(BrandFilterOptions filterOptions, List<Producer> allProducers)
        {
            var producers = allProducers.AsQueryable();

            if (!string.IsNullOrEmpty(filterOptions.Letter))
            {
                switch (filterOptions.Letter)
                {
                    case "0":
                        producers = producers.Where(i => char.IsDigit(i.Name[0]));
                        break;
                    case "other":
                        producers = producers.Where(i =>
                            !(char.IsDigit(i.Name[0]) || (i.Name.ToUpper()[0] >= 'A' && i.Name.ToUpper()[0] <= 'Z')));
                        break;
                    default:
                        producers = producers.Where(i =>
                            i.Name.StartsWith(filterOptions.Letter, true, CultureInfo.InvariantCulture));
                        break;
                }
            }

            if (filterOptions.Assemblies.Any())
            {
                producers = producers.Where(i => i.Brand != null && i.Brand.Assemblies.ToTags().Any(t=>filterOptions.Assemblies.Contains(t)));
            }

            if (filterOptions.Marks.Any())
            {
                producers = producers.Where(i => i.Brand != null && i.Brand.Marks.ToTags().Any(t => filterOptions.Marks.Contains(t)));
            }

            if (filterOptions.VehicleTypes.Any())
            {
                producers = producers.Where(i => i.Brand != null && i.Brand.VehicleTypes.ToTags().Any(t => filterOptions.VehicleTypes.Contains(t)));
            }

            return producers;
        }

        private BaseFilterViewModel CreateFilterModel(BrandFilterOptions options, List<Producer> producers)
        {
            var result = new BaseFilterViewModel();
            result.Sections.Add(
                new SelectViewModel
                {
                    Caption = SharedResources.VehicleTypes,
                    Options = producers.Where(i => i.Brand?.VehicleTypes.Any() == true)
                        .Aggregate(new List<string>(), (s, i) =>
                        {
                            s.AddRange(i.Brand.VehicleTypes.ToTags());
                            return s;
                        })
                        .Select(i => new SelectListItem { Value = i, Text = i, Selected = options.VehicleTypes.Contains(i) }).ToList(),
                    AutoSubmit = false,
                    Name = nameof(options.VehicleTypes),
                    SectionIsOpened = true,
                    ShowLimit = 10,
                    ShowSelectMoreLink = true
                });

            result.Sections.Add(
                new SelectViewModel
                {
                    Caption = SharedResources.AutoMarka,
                    //Options = _autoDataRepository.GetMarksList(locale)
                    //    .Select(i => new SelectListItem {Value = i.Id, Text = i.Name, Selected = options.Marks.Contains(i.Id)}).ToList(),
                    Options = producers.Where(i => i.Brand?.Marks.Any() == true)
                        .Aggregate(new List<string>(), (s, i) =>
                        {
                            s.AddRange(i.Brand.Marks.ToTags());
                            return s;
                        })
                        .Select(i => new SelectListItem { Value = i, Text = i, Selected = options.Marks.Contains(i) }).ToList(),
                    AutoSubmit = false,
                    Name = nameof(options.Marks),
                    SectionIsOpened = true,
                    ShowLimit = 10,
                    ShowSelectMoreLink = true,
                });
            result.Sections.Add(
                new SelectViewModel
                {
                    Caption = SharedResources.Assemblies,
                    Options = producers.Where(i => i.Brand?.Assemblies.Any() == true)
                        .Aggregate(new List<string>(), (s, i) =>
                        {
                            s.AddRange(i.Brand.Assemblies.ToTags());
                            return s;
                        })
                        .Select(i => new SelectListItem {Value = i, Text = i, Selected = options.Assemblies.Contains(i)}).ToList(),
                    AutoSubmit = false,
                    Name = nameof(options.Assemblies),
                    SectionIsOpened = true,
                    ShowLimit = 10,
                    ShowSelectMoreLink = true
                });
            foreach (var section in result.Sections.Where(i=>i.GetType() == typeof(SelectViewModel)))
            {
                ((SelectViewModel)section).IsFilterable = ((SelectViewModel)section).Options.Count > 20;
            }

            return result;
        }
    }
}
