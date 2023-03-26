using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using log4net;
using log4net.Config;
using ViewRes;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Models.Cart;
using Webmall.UI.Models.Order;
using Webmall.UI.ViewModel.Common;
using Webmall.UI.ViewModel.Order;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderController));

        static OrderController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly IOrderRepository _orderRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly ICmsRepository _cmsRepository;
        // ReSharper disable once InconsistentNaming
        private readonly ICartRepository _cartRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        // ReSharper disable once InconsistentNaming
        public OrderController(IOrderRepository orderRepository, IReferenceRepository referenceRepository,
            ICartRepository cartRepository, IClientRepository clientRepository, ICmsRepository cmsRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _referenceRepository = referenceRepository;
            _cmsRepository = cmsRepository;
        }

        public ActionResult Index()
        {
            return RedirectToActionPermanent("List");
        }

        /// <summary>
        /// Формирует список заказов
        /// </summary>
        /// <param name="lineMode">true - построчное представление заказа</param>
        /// <param name="filterOptions">Фильтры</param>
        /// <param name="options">Параметры постраничного отображения</param>
        /// <returns></returns>
        public ActionResult List(bool? lineMode, OrderFilterOptions filterOptions, GridViewOptions options)
        {
            if (string.IsNullOrEmpty(options.SortColumn))
            {
                options.SortColumn = "Number";
                options.SortDirection = SortDirection.Descending;
            }

            if (lineMode == true)
            {
                var orderPositionsList = _orderRepository.GetOrderPositionsList(SessionHelper.CurrentClientId, filterOptions,
                    _mapper.Map<PageOptions>(options));
                var orderPositionsModel = new OrderLinesListViewModel
                {
                    Orders = orderPositionsList.List.AsGridView(ControllerContext, options, orderPositionsList.Total, "Number", true),
                    Statuses = _orderRepository.GetOrderStatuses(UserPreferences.CurrentCulture),
                    PosStatuses = _orderRepository.GetOrderPositionStatuses(UserPreferences.CurrentCulture)
                };

                orderPositionsModel.Filters.Statuses = orderPositionsModel.Statuses;
                orderPositionsModel.Filters.FilterOptions = filterOptions;
                return View("PositionsList", orderPositionsModel);

            }

            var orderList = _orderRepository.GetOrderList(SessionHelper.CurrentClientId, filterOptions,
                _mapper.Map<PageOptions>(options));
            var ordersModel = new OrdersListViewModel
            {
                Orders = orderList.List.AsGridView(ControllerContext, options, orderList.Total, "Number", true),
                Statuses = _orderRepository.GetOrderStatuses(UserPreferences.CurrentCulture),
                PosStatuses = _orderRepository.GetOrderPositionStatuses(UserPreferences.CurrentCulture)
            };

            ordersModel.Filters.Statuses = ordersModel.Statuses;
            ordersModel.Filters.FilterOptions = filterOptions;
            return View(ordersModel);
        }

        /// <summary>
        /// Формирует карточку или список заказов
        /// </summary>
        /// <param name="id">Код заказа для формирования карточки</param>
        /// <param name="showPaymentFirst">Для карточки заказа - отображать сразу второй шаг (выбор оплаты)</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Order(string id, bool? showPaymentFirst)
        {
            var showPaymentFirstArg = showPaymentFirst == true ? "?showPaymentFirst=true" : "";
            var url = Url.Content($"~/Order/List#{id}{showPaymentFirstArg}");
            return Redirect(url);
        }

        [HttpPost]
        public ActionResult Create(string inOrderId, int[] selected, GridViewOptions options)
        {
            if (selected.Length == 0)
            {
                return View("Error");
            }

            var selectedPosition = _cartRepository.GetCartPositionsByIdList(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, selected);
            var pickupPoints = _orderRepository.GetPickupPoints("", SessionHelper.CurrentClientId);

            var model = new CreateOrderModelView
            {
                ClientId = SessionHelper.CurrentClientId,
                AuthorId = SessionHelper.CurrentClient.Id,
                Positions = selectedPosition,
                ValuteName = SessionHelper.CurrentValute.Code,
                OrderPayment = _cmsRepository.GetOrderPayment(),//
                InfoAdditional = _cmsRepository.GetEmbeddedText(1),
                InfoDelivery = _cmsRepository.GetEmbeddedText(2),
                InfoPayment = _cmsRepository.GetEmbeddedText(3),
                InfoAttention = _cmsRepository.GetEmbeddedText(4),
                TotalQnt = selectedPosition.Sum(i => i.WareQnt).ToString(),
                TotalPrice = Math.Ceiling((decimal)selectedPosition.Sum(i => i.Sum)),
                Contacts = new List<SelectListItem> {
                    new SelectListItem { Value = "1", Text = "Иванов1 Иван Иванович  +375 23-654-65-65"},
                    new SelectListItem { Value = "2", Text = "Иванов2 Иван Иванович  +375 23-654-65-65"},
                    new SelectListItem { Value = "3", Text = "Иванов3 Иван Иванович  +375 23-654-65-65"},
                    new SelectListItem { Value = "4", Text = "Иванов4 Иван Иванович  +375 23-654-65-65"},
                },
                PickupPoints = pickupPoints.ConvertAll(a => { return new SelectListItem() { Text = a.Name, Value = a.Id }; }),
                WarehouseId = SessionHelper.CurrentClient.CurrentWarehouseId,
                AuthorName = SessionHelper.CurrentUser.FullName
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutOrderData data)
        {
            var user = SessionHelper.CurrentUser;
            var client = SessionHelper.CurrentClient;
            data.ClientId = client.Id;
            data.AuthorId = user.Id.ToString();
            data.AuthorName = user.FullName;
            data.WarehouseId = client.CurrentWarehouseId;

            data.Positions = _cartRepository.GetCartPositionsByIdList(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, data.Positions.Select(i => i.Id).ToArray()).ToArray();
            var orderid = _orderRepository.CreateOrder(data);

            if (!string.IsNullOrEmpty(orderid))
            {
                _cartRepository.RemoveCartPosition(SessionHelper.CurrentUser, data.Positions.Select(i => i.Id).ToList());
                return RedirectToAction("Successful", "Order", new { orderid = orderid });
            }

            var messageModel = new MessageViewModel { Message = SharedResources.OrderCreateErrorMessage, Title = SharedResources.ErrorsFound };
            return View("MessagePage", messageModel);
        }

        public ActionResult Successful(string orderId)
        {

            var orderInfo = _orderRepository.GetOrder(UserPreferences.CurrentCulture, SessionHelper.CurrentClientId, orderId);

            var deliveryName = orderInfo.DeliveryInfo.DeliveryTypeId == 1 ? "Самовывоз" : "Доставка";
            var pickupPointId = orderInfo.DeliveryInfo.PickUpPayload.PickupPointId;
            var pickupPoint = "";

            if (!string.IsNullOrEmpty(pickupPointId))
            {
                var warehouses = _referenceRepository.GetWarehouses(SessionHelper.CurrentClientId, UserPreferences.CurrentCulture)
                    .Where(i => i.Id == pickupPointId).FirstOrDefault();
                pickupPoint = $"{warehouses.Value} {warehouses.Address}";
            }

            var model = new SuccessfulOrderModelView
            {
                OrderId = orderInfo.Number,
                DataCreateOrder = orderInfo.OrderDate,
                StatusOrder = orderInfo.DeliveryInfo.StatusName,
                AuthorOrder = orderInfo.UserName,
                Positions = orderInfo.Positions,
                TotalPrice = orderInfo.Sum,
                Name = orderInfo.UserName,
                Phone = orderInfo.Options.ContactPhone,
                Comment = orderInfo.Options.Comment,
                DeliveryType = deliveryName,
                DeliveryAddress = pickupPoint,
                TotalQnt = orderInfo.Positions.Sum(i => i.WareQnt).ToString(),
                ValuteName = orderInfo.PaymentInfo.CurrencyCode,
                SuccessPageText = _cmsRepository.GetSuccessPageText()
            };

            ViewBag.OrderId = orderId;
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(string orderId)
        {
            //var model = _orderRepository.GetOrder(UserPreferences.CurrentCulture, SessionHelper.CurrentUser.CurrentClientId, orderId);

            var model = new OrdersDetailModel
            {
                Order = _orderRepository.GetOrder(UserPreferences.CurrentCulture, SessionHelper.CurrentUser.CurrentClientId, orderId),
                //Statuses = _orderRepository.GetOrderStatuses(UserPreferences.CurrentCulture),
                PositionStatuses = _orderRepository.GetOrderPositionStatuses(UserPreferences.CurrentCulture),
                ValuteName = SessionHelper.CurrentValute.Code
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult ListItemProperties(string orderId, bool? mob)
        {
            var model = _orderRepository.GetOrderPositions(UserPreferences.CurrentCulture, SessionHelper.CurrentClientId, orderId);

            if (mob == true) return View("ListItemPropertiesMob", model);

            return View(model);
        }

        //public ActionResult DeleteOrder(string id)
        //{
        //    try
        //    {
        //        TempData.Clear();
        //        _orderRepository.DeleteOrder(SessionHelper.CurrentUser, id);
        //    }
        //    catch (Exception e)
        //    {
        //        var message = e.InnerException != null ? e.InnerException.Message : e.Message;
        //        TempData.Add("Message", string.Format(SharedResources.OrderDeleteError + " {0}", message));
        //        return RedirectToAction("Show", "Message");
        //    }
        //    return RedirectToAction("List");
        //}


        //[HttpGet]
        //public ActionResult ExportOrder(string orderId)
        //{
        //    var reportFormat = "excel";
        //    var reportFormatExt = reportFormat.ToLower().Replace("excel", "xlsx");

        //    var buffer = _orderRepository.DownloadOrderCard(SessionHelper.CurrentClientId, orderId, reportFormatExt);
        //    if (buffer == null)
        //    {
        //        TempData["Message"] = SharedResources.ErrorMessage;
        //        return RedirectToAction("Show", "Message");
        //    }
        //    var result = new FileStreamResult(new MemoryStream(buffer), "application/" + reportFormat) { FileDownloadName = $"Order_{orderId}.{reportFormatExt}" };
        //    return result;
        //}

        //public ActionResult GetDeliverySchedule(string warehouseId, DateTime filterDate, string addressId, DateTime deliveryDate, int hour, int minute, string orderId, int? paymentType)
        //{
        //    deliveryDate = deliveryDate.AddHours(hour);
        //    deliveryDate = deliveryDate.AddMinutes(minute);

        //    var model = new DeliveryScheduleModel
        //    {
        //        routes = _orderRepository
        //            .GetDeliverySchedule(SessionHelper.CurrentUser, orderId, addressId ?? "", warehouseId, deliveryDate,
        //                paymentType, UserPreferences.CurrentCulture, out var reason)
        //            //.Where(i => i.ReceiveTime > filterDate)
        //            .ToList(),
        //        reason = reason
        //    };

        //    Log.DebugFormat("Для заказа {0} в модели осталось {1} записей в расписании", orderId, model.routes.Count);
        //    return View("Schedules", model);
        //}

        //[HttpPost]
        //public JsonResult CreateDelivery(string orderId, DateTime filterDate, AvailableDelivery delivery, int? scheduleId, int? hour, int? minute, int? editDeliveryId, int? createPaymentType)
        //{
        //    if (!scheduleId.HasValue) return null;
        //    if (SessionHelper.CurrentClient.DefaultTaxInvoiceDelivery)
        //        delivery.NeedTaxBill = true;
        //    if (delivery?.DeliveryDate != null && hour.HasValue && minute.HasValue)
        //    {
        //        delivery.DeliveryDate = delivery.DeliveryDate.Value.AddHours(hour.Value);
        //        delivery.DeliveryDate = delivery.DeliveryDate.Value.AddMinutes(minute.Value);
        //    }
        //    int? deliveryId = null;
        //    string errorMessage = null;
        //    try
        //    {
        //        if (editDeliveryId == null)
        //            deliveryId = _orderRepository.CreateNewDelivery(SessionHelper.CurrentUser, orderId, delivery, scheduleId.Value);
        //        else
        //        {
        //            _orderRepository.UpdateDelivery(SessionHelper.CurrentUser, editDeliveryId, delivery, scheduleId.Value);
        //            deliveryId = editDeliveryId;
        //        }
        //        //var availableDelivery = orderRepository.GetAvailableDeliveries(orderId, SessionHelper.CurrentUser, filterDate, createPaymentType);

        //        #region Delivery log

        //        //log.DebugFormat("(Create) Получено из репозитория: {0}, дата {1}", availableDelivery.Count(), filterDate);
        //        //string log_data = "";
        //        //foreach (var item in availableDelivery)
        //        //{
        //        //    log_data += string.Format("Id: {0}, {1}, {2}\r\n", item.Id, item.Presentation, item.TimePresentation);
        //        //}
        //        //log.Debug(log_data); 
        //        //if (editDeliveryId == null)
        //        //{
        //        //    var addedDelivery = availableDelivery.FirstOrDefault(i => i.Id == deliveryId);
        //        //    if (addedDelivery != null)
        //        //        addedDelivery.Added = true;
        //        //}
        //        ////availableDelivery.Insert(0, new AvailableDelivery() { Address = ViewRes.SharedResources.SelfDelivery, AddressId = -1, Id = -1 });
        //        ////
        //        //log.DebugFormat("После обработки: {0}", availableDelivery.Count());
        //        //log_data = "";
        //        //foreach (var item in availableDelivery)
        //        //{
        //        //    log_data += string.Format("Id: {0}, {1}, {2}\r\n", item.Id, item.Presentation, item.TimePresentation);
        //        //}
        //        //log.Debug(log_data);

        //        #endregion

        //    }
        //    catch (Exception e)
        //    {
        //        errorMessage = (e.InnerException != null) ? e.InnerException.Message : string.Format(SharedResources.JsonUnknownError, ConfigHelper.ContactRetailPhone);
        //        errorMessage = errorMessage.Split('\r')[0].Trim();
        //        errorMessage = SharedResources.DeliveryCreationError + "\n" + errorMessage;
        //    }
        //    var jResult = new JsonResult { Data = new { deliveryId, errorMessage }, JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        //    return jResult;
        //}

        //public JsonResult AddAddress(DeliveryAddress address, string clientId)
        //{
        //    _clientRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, clientId, address);
        //    var result = _clientRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, clientId, UserPreferences.CurrentCulture);
        //    var rs = result.Select(k => new DeliveryAddressListItem { Value = k.AddressId.ToString(CultureInfo.InvariantCulture), Text = k.AddressPresentator, Comment = k.Comment, Selected = false }).ToList();
        //    var last = rs.LastOrDefault();
        //    if (last != null)
        //        last.Selected = true;
        //    var jResult = new JsonResult { Data = rs.ToArray(), JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        //    return jResult;
        //}

        //public JsonResult GetOrderPositions(string orderId)
        //{
        //    var positions = _orderRepository.GetOrderPositions(SessionHelper.CurrentUser, orderId, true, UserPreferences.CurrentCulture);
        //    var jResult = new JsonResult { Data = positions.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    return jResult;
        //}

        //public JsonResult GetDeliveries(string orderId, DateTime filterDate, int? paymentType, string addressId)
        //{
        //    var availableDelivery = _orderRepository.GetAvailableDeliveries(orderId, SessionHelper.CurrentUser, filterDate, paymentType, addressId);
        //    Log.DebugFormat("(Get) Получено доставок из репозитория: {0}, дата {1}, addressId {2}", availableDelivery.Count, filterDate, addressId);
        //    string logData = availableDelivery.Aggregate("", (current, item) => current +
        //                                                                        $"Id: {item.Id}, {item.Presentation}, {item.TimePresentation}\r\n");
        //    Log.Debug(logData);
        //    var jResult = new JsonResult { Data = availableDelivery.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    return jResult;
        //}

        //[HttpPost]
        //public ActionResult Payment(Order order, int? paymentId, bool? blockSendingMessage, bool? sendToStock)
        //{
        //    if (sendToStock == true)
        //        _orderRepository.SendToStock(SessionHelper.CurrentUser, order.Id);
        //    return ProcessPayment(order, paymentId, blockSendingMessage);
        //}

        //private ActionResult ProcessPayment(Order order, int? paymentId, bool? blockSendingMessage)
        //{
        //    if (string.IsNullOrEmpty(order?.Id)) return View("Error");

        //    var orderRestored = _orderRepository.GetOrder(SessionHelper.CurrentUser, order.Id, false, UserPreferences.CurrentCulture);

        //    if (orderRestored == null) return View("Error");

        //    if (order.Status == OrderStatuses.Draft.ToString() && orderRestored.Status != order.Status && blockSendingMessage != true)
        //    {
        //        SendCongratulationMessage(order);
        //    }

        //    if (paymentId.HasValue)
        //    {
        //        orderRestored.PaymentType = paymentId.Value;
        //    }

        //    if (!orderRestored.IsPayed)
        //    {
        //        if (orderRestored.PaymentType == (int)PaymentTypes.Invoice && ConfigHelper.FeaturesConfig.Order.PaymentTransfer)
        //        {
        //            return View("Payment", orderRestored);
        //        }

        //        if (orderRestored.PaymentType == (int)PaymentTypes.Visa || orderRestored.PaymentType == (int)PaymentTypes.LiqPay)
        //        {
        //            return RedirectToAction("Order", "Payment", new { orderId = order.Id, paymentType = orderRestored.PaymentType });
        //        }
        //    }

        //    return ProcessSummary(orderRestored, blockSendingMessage);
        //}

        //[Authorize]
        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        //public ActionResult Summary(string orderId, int? paymentId, bool? blockSendingMessage)
        //{
        //    Order orderRestored = null;
        //    if (!string.IsNullOrEmpty(orderId))
        //    {
        //        orderRestored = _orderRepository.GetOrder(SessionHelper.CurrentUser, orderId, false, UserPreferences.CurrentCulture);
        //        if (paymentId.HasValue)
        //            orderRestored.PaymentType = paymentId.Value;
        //    }
        //    if (orderRestored != null)
        //        return ProcessSummary(orderRestored, blockSendingMessage);

        //    TempData.Add("Message", string.Format(SharedResources.OrderNotExist + "№ {0}", orderId));
        //    return RedirectToAction("Show", "Message");
        //}

        //[Authorize]
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult PaymentConfirmation()
        //{
        //    //return View(Session["PaymentInfo"] as PaymentModel ?? new PaymentModel());
        //    var model = Session["PaymentInfo"] as PaymentModel ?? new PaymentModel();
        //    return RedirectToAction("Summary", "Order", new { orderId = model.OrderId, paymentId = (int)PaymentTypes.Visa });
        //}

        //[Authorize]
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult PaymentRejection()
        //{
        //    return View(Session["PaymentInfo"] as PaymentModel ?? new PaymentModel());
        //}

        //protected ActionResult ProcessSummary(Order order, bool? blockSendingMessage)
        //{
        //    if (order != null)
        //    {
        //        if (blockSendingMessage != true)
        //        {
        //            var u = new UrlHelper(ControllerContext.RequestContext);
        //            var url = u.Action("BlockSendingOrderResume", "Security");
        //            // ReSharper disable once PossibleNullReferenceException
        //            var uriBuilder = new UriBuilder(Request.Url.Scheme, Request.Url.Host, Request.Url.Port,
        //                url, "?id1=" + SessionHelper.CurrentUser.Guid + "&id2=" + SessionHelper.CurrentUser.PasswordHash);
        //            ViewBag.URL = uriBuilder.Uri.OriginalString;

        //        }
        //        if (order.Status == OrderStatuses.Draft.ToString())
        //        {
        //            try
        //            {
        //                var result = _orderRepository.SendToWork(SessionHelper.CurrentUser, order.Id);
        //                if (!string.IsNullOrEmpty(result))
        //                {
        //                    return PrepareErrorMessage(order.Id, result);

        //                }
        //                SendCongratulationMessage(order);
        //            }
        //            catch (Exception e)
        //            {
        //                return PrepareErrorMessage(order.Id, e.InnerException?.Message ?? e.Message);
        //            }
        //        }

        //        return View("Summary", order);
        //    }

        //    TempData.Add("Message", string.Format(SharedResources.OrderNotExist));
        //    return RedirectToAction("Show", "Message");
        //}

        //protected ActionResult PrepareErrorMessage(string orderId, string message)
        //{
        //    TempData["Message"] = string.Format("<p>" + SharedResources.OrderErrorText + "<p>", message.Replace("{", "[").Replace("}", "]"));
        //    string button = $"<a href=\"{Url.Action("Order", "Order", new { id = orderId })}\">{SharedResources.ReturnToOrder}</a>";
        //    TempData["Message"] += button;
        //    TempData["Title"] = SharedResources.OrderError;
        //    return RedirectToAction("Show", "Message");
        //}

        //protected void SendCongratulationMessage(Order order)
        //{
        //    var html = ConvertViewToHtmlString(ControllerContext, "SummaryMail", order);
        //    if (SessionHelper.CurrentUser.Configuration.SendOrderResume)
        //        MailHelper.SendCongratulationMessage(SessionHelper.CurrentUser, html, order.Id.ToString(CultureInfo.InvariantCulture));

        //    if (!SessionHelper.CurrentUser.CurrentPresenter.IsKeyRepresentative)
        //    {
        //        var company = _clientRepository.GetFullClientInfo(SessionHelper.CurrentClientId);
        //        var email = company.ManagerData.Email;
        //        if (!string.IsNullOrEmpty(email))
        //        {
        //            MailHelper.SendCongratulationMessage(email, html, order.Id.ToString(CultureInfo.InvariantCulture));
        //        }
        //    }

        //    MailHelper.SendCongratulationMessageCopy(ConfigHelper.SummaryCopy, html);
        //}

        //private string ConvertViewToHtmlString(ControllerContext c, string viewName, object data)
        //{
        //    //set view data notifications
        //    ViewData.Model = data;
        //    var output = new StringWriter();
        //    //find the view to general html string
        //    ViewEngineResult result = ViewEngines.Engines.FindView(c, viewName, "");
        //    var viewContext = new ViewContext(c, result.View, ViewData, TempData, output);
        //    try
        //    {
        //        //render the view to stringWriter, rather than on Response stream
        //        result.View.Render(viewContext, output);
        //    }
        //    finally
        //    {
        //        //release the view so that it can be used by other controllers
        //        result.ViewEngine.ReleaseView(c, result.View);
        //    }
        //    //html string for the view
        //    return output.ToString();
        //}

        //[HttpPost]
        //public ActionResult ExtractToOrder(string orderId, List<string> positions)
        //{
        //    try
        //    {
        //        var newOrderId = _orderRepository.ExtractToOrder(SessionHelper.CurrentUser, orderId, positions);
        //        return RedirectToAction("Order", new { Id = newOrderId });
        //    }
        //    catch (Exception e)
        //    {
        //        var message = e.InnerException != null ? e.InnerException.Message : e.Message;
        //        message += "<p/>" + SharedResources.ReturnToOrderMessage;

        //        TempData.Add("Title", SharedResources.OrderError);
        //        TempData.Add("Message", message);
        //        return RedirectToAction("Show", "Message");
        //    }
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public JsonResult Localities(string cityId)
        //{
        //    var result = _clientRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, UserPreferences.CurrentCulture);
        //    foreach (var deliveryAddress in result)
        //    {
        //        deliveryAddress.Comment = HttpUtility.HtmlEncode(deliveryAddress.Comment);
        //        deliveryAddress.Flat = HttpUtility.HtmlEncode(deliveryAddress.Flat);
        //    }
        //    //SimpleReference.Convert(ReferenceRepository.GetLocalities(null, UserPreferences.CurrentCulture, -1), false).Where(s => s.Text.ToLower().StartsWith(q.ToLower())).Take(limit).OrderBy(i => i.Text);
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[Authorize]
        //[HttpGet]
        //public JsonResult CheckClientDebt(string id)
        //{
        //    string debtMessage = _orderRepository.CheckClientDebtBlock(SessionHelper.CurrentUser, id, UserPreferences.CurrentCulture).Message;
        //    return Json(debtMessage, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult UpdateOrderTrustedPerson(string orderId, string trustedPersonId)
        //{
        //    try
        //    {
        //        _orderRepository.UpdateOrderTrustedPerson(SessionHelper.CurrentUser, orderId, trustedPersonId);
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        //throw;
        //    }
        //    return null;
        //}
    }
}
