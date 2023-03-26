using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ValmiStore.Model.Entities.Configuration.Features;
using Webmall.Model.Entities.Order;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Attributes;
using Webmall.UI.Models.TV;

namespace Webmall.UI.Controllers
{
    // ReSharper disable once InconsistentNaming
    [FeatureFilter(typeof(MiscFeatures), nameof(MiscFeatures.OrderTerminal))]
    public class TVController : Controller
    {
        readonly IOrderRepository _orderRepository;

        public TVController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //
        // GET: /TV/

        public ActionResult Index(int? whId)
        {
            var playList = new List<VideoInfo>();

            foreach (var file in Directory.GetFiles(ControllerContext.HttpContext.Server.MapPath("~/video")).OrderBy(Path.GetFileName))
            {
                playList.Add(new VideoInfo { URL = "~/Video/" + Path.GetFileName(file), Title = Path.GetFileNameWithoutExtension(file) });
            }

            var model = new TVModel { PlayList = playList, WarehouseId = whId ?? 1 };

            var runningStringFilePath = Path.Combine(ControllerContext.HttpContext.Server.MapPath("~/ExtContent"),
                "RunningLine.txt");
            if (System.IO.File.Exists(runningStringFilePath))
            {
                using (var reader = System.IO.File.OpenText(runningStringFilePath))
                {
                    model.RunningLineText = reader.ReadToEnd();
                }
            }

            //var warehouse = ReferenceRepository.GetWarehousesStatic(UserPreferences.CurrentCulture).FirstOrDefault(i => i.Id == whId);

            return View(model);
        }

        public JsonResult GetOrdersInfo(int whId)
        {
            List<OrderListItem> data = null;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    data = _orderRepository.GetPublicOrderList(UserPreferences.CurrentCulture, whId.ToString());
                    break;
                }
                catch (Exception)
                {
                    if (i == 2)
                        throw;
                }
                i++;
            }
            //for (int i = 0; i < 20; i++)
            //    data.Add(new OrderListItem
            //    {
            //        Id = i,
            //        OrderDate = DateTime.Now,
            //        Status = i == 0 || i % 3 != 0 ? "Finalizat" : "Se proceseaza",
            //        StatusId = i == 0 || i % 3 != 0 ? 2 : 1,
            //        IsNew = (i == 2 || i == 7)
            //    });

            data = data?.OrderBy(i => i.StatusId).ThenByDescending(i => i.Id).ToList();

            var result = new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            return result;
        }

        //public JsonResult GetValuteInfo()
        //{
        //    double euro = 0;
        //    double usd = 0;
        //    var stream =
        //        PostHelper.GetPostStream(string.Format("http://www.bnm.md/ru/official_exchange_rates?get_xml=1&date={0}",DateTime.Now.Date.ToString("dd.MM.yyyy")));
        //    var doc = new XmlDocument();
        //    doc.Load(stream);

        //    var nav = doc.CreateNavigator();
        //    //var it = (XPathNodeIterator)nav.Evaluate("ValCurs/Valute[@ID=47]/Товар[@Цена > 300]");
        //    var selectSingleNode = nav.SelectSingleNode("ValCurs/Valute[@ID=47]/Value");
        //    if (selectSingleNode != null)
        //    {
        //        euro = selectSingleNode.ValueAsDouble;
        //    }
        //    selectSingleNode = nav.SelectSingleNode("ValCurs/Valute[@ID=44]/Value");
        //    if (selectSingleNode != null)
        //    {
        //        usd = selectSingleNode.ValueAsDouble;
        //    }
        //    var result = new JsonResult
        //                     {
        //                         Data = new {euro, usd}, //orderRepository.GetPublicOrderList(UserPreferences.CurrentCulture, whId),
        //                         JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //                     };
        //    return result;
        //}

        //public ActionResult Test()
        //{
        //    var playList = new List<VideoInfo>();

        //    foreach (var file in Directory.GetFiles(ControllerContext.HttpContext.Server.MapPath("~/video")))
        //    {
        //        playList.Add(new VideoInfo { URL = "~/Video/" + Path.GetFileName(file), Title = Path.GetFileNameWithoutExtension(file) });
        //    }

        //    var model = new TVModel { PlayList = playList, WarehouseId = 1 };

        //    var warehouse = ReferenceRepository.GetWarehousesStatic(UserPreferences.CurrentCulture).FirstOrDefault(i => i.Id == 1);

        //    if (warehouse != null)
        //    {
        //        // TODO Добавить логику выбора нас. пункта по складу.
        //    }

        //    return View(model);
        //}

    }
}
