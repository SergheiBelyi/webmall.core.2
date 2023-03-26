using log4net;
using log4net.Config;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ExcelDataReader;
using ViewRes;
using Webmall.Model.Entities.Cart;
using Webmall.UI.Core;
using Webmall.UI.Models.Cart;
using Webmall.UI.ViewModel.Cart;
using Webmall.Model.Repositories.Abstract;
using Newtonsoft.Json;
using System;
using System.Web.Http;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Controllers
{
    public class CartController : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CartController));

        static CartController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly ICartRepository _cartRepository;
        private readonly ICatalogRepository _catalogRepository;


        public CartController(ICartRepository cartRepository, ICatalogRepository catalogRepository)
        {
            _cartRepository = cartRepository;
            _catalogRepository = catalogRepository;
        }
        [System.Web.Mvc.Authorize]
        public ActionResult Index(string inOrderId, GridViewOptions options, bool? group)
        {
            var model = PrepareCartModel(inOrderId, options);
            return View(model);
        }

        private CartModel PrepareCartModel(string inOrderId, GridViewOptions options)
        {
            var positions = _cartRepository
                .GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, true)
                .AsGridView(ControllerContext, options, null, "WareName", false);

            foreach (var item in positions.List)
            {
                item.Url = Url.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{item.ProducerName}/{item.WareNum}";
            }

            SessionHelper.Cart = positions.List;
            var model = new CartModel(inOrderId)
            {
                Positions = positions,
                ValuteName = SessionHelper.CurrentValute.Code
            };
            return model;
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult Preview(int[] selected, string inOrderId, string toAction, string toActionMobile)
        //{
        //    if (selected == null || selected.Length == 0) return RedirectToAction("Index");

        //    TempData["CartPositions"] = selected;

        //    if (string.IsNullOrEmpty(toAction))
        //        toAction = toActionMobile;

        //    if ("Delete".Equals(toAction)) return RedirectToAction(toAction);

        //    if (!string.IsNullOrEmpty(inOrderId)) return RedirectToAction("AddToOrder", "Order", new { orderId = inOrderId });

        //    var orderPreview = (from p in _cartRepository.GetCartPositionsByIdList(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, selected)
        //                        orderby p.DeliveryTerm
        //                        group p by p.ClientId //p.WarehouseName //p.DeliveryTermAsString
        //        into order
        //                        select new OrderPreviewModel { Term = order.Key, Positions = order.AsEnumerable() }).ToList();

        //    if (orderPreview.Count == 0)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    if (orderPreview.Count == 1)
        //    {
        //        TempData["positions"] = orderPreview[0].Positions.Select(k => k.Id).ToArray();
        //        return RedirectToAction("Create", "Order");
        //    }

        //    return View("Preview", orderPreview);
        //}

        [System.Web.Mvc.Authorize]
        public ActionResult Delete(int[] selected)
        {
            _cartRepository.RemoveCartPosition(SessionHelper.CurrentUser, new List<int>(selected));

            return RedirectToAction("Index");
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpGet]
        public void DeletePosition(int id, string returnUrl)
        {
            _cartRepository.RemoveCartPosition(SessionHelper.CurrentUser, new List<int> { id });
            SessionHelper.Cart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
            //return Redirect(returnUrl);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        public void EditCommentPosition(int id, string comment)
        {
           _cartRepository.EditCommentCartPosition(SessionHelper.CurrentUser, id, comment);
            SessionHelper.Cart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
            //return Redirect(returnUrl);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        public JsonResult UpdatePostition(int positionId, decimal value, long? ticks = null)
        {
            _cartRepository.UpdatePosition(SessionHelper.CurrentUser, positionId, value);
            var position = _cartRepository.GetCartPositionsByIdList(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, new[] { positionId }).FirstOrDefault();
            if (position != null)
            {
                var tmpPos = SessionHelper.Cart.FirstOrDefault(i => i.Id == position.Id);
                if (tmpPos != null)
                    tmpPos.WareQnt = position.WareQnt;
            }

            var result = position?.Sum ?? decimal.Zero;
            return ticks == 0 ? new JsonResult { Data = SessionHelper.PriceFormat(result) } : new JsonResult { Data = new { message = TempData["Message"], ticks = ticks } };
            // return SessionHelper.PriceFormat(result);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        public JsonResult UpdatePostitionWCheck(int positionId, decimal value, long? ticks = null)
        {
            _cartRepository.UpdatePosition(SessionHelper.CurrentUser, positionId, value);
            var position = _cartRepository.GetCartPositionsByIdList(UserPreferences.CurrentCulture, SessionHelper.CurrentUser, new[] { positionId }).FirstOrDefault();
            if (position != null)
            {
                var tmpPos = SessionHelper.Cart.FirstOrDefault(i => i.Id == position.Id);
                if (tmpPos != null)
                    tmpPos.WareQnt = position.WareQnt;
            }

            return new JsonResult { Data = new { position, ticks }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult AddCartToStoreOrLocalStorage(string wareId, string offerId, string article, string producer, int offerQnt, decimal price, bool isLocalStorage, FormCollection offerData)
        {
            var carts = new List<CartPosition>();

            var offer = JsonConvert.DeserializeObject<Offer>(offerData[0].Replace("|plus|", "+"));

            if (wareId != null)
            {
                var ware = _catalogRepository.GetWare(UserPreferences.CurrentCulture, wareId, article, producer);

                if (ware == null)
                {
                    TempData["Message"] = "в базе нет такого товара!";
                    return new JsonResult { Data = new { message = TempData["Message"] }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    TempData["Message"] = null;
                    var cart = new CartPosition();

                    //TODO offer request
                    var currentClient = SessionHelper.CurrentClient;

                    //var offers = _catalogRepository.GetWareOffers(UserPreferences.CurrentCulture, wareId, article, producer,
                    //    SessionHelper.CurrentClient.Uid, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", new PageOptions()).FirstOrDefault();

                    cart.WareId = wareId;
                    cart.WareQnt = offerQnt > 999 ? 999 : offerQnt;
                    cart.ProducerId = ware.ProducerId;
                    cart.ProducerName = ware.ProducerName;
                    cart.WareNum = ware.WareNumber;
                    cart.WareName = ware.Name;
                    cart.ClientPrice = price;
                    cart.OfferId = offerId;
                    cart.CreationDate = DateTime.Now;
                    cart.WarehouseName = offer.SupplierWarehouseName;
                    cart.AvailableQntStr = offer.AvailableQntStr;
                    cart.DeliveryTerm = offer.DeliveryTerm;
                    cart.DeliveryDays = offer.DeliveryDays;
                    cart.DeliveryRating = offer.DeliveryRating;
                    cart.ReturnDays = offer.ReturnDays;
                    cart.IsReturnAllowed = offer.ReturnDays > 0;
                    cart.SaleQnt = offer.SaleQnt;

                    Log.Debug($"Adding to cart: WareId: {cart.WareId}, suppId: {cart.SupplierUid}, WareQnt: {cart.WareQnt}, WarehouseId: {cart.WarehouseId}");

                    if (!isLocalStorage)
                    {
                        var currentCart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
                        var existingCartPosition = currentCart.FirstOrDefault(item =>
                            item.OfferId == cart.OfferId && item.ProducerId == cart.ProducerId &&
                            item.WareId == cart.WareId);
                        if (existingCartPosition != null)
                        {
                            TempData["Message"] = SharedResources.ExistingCartItemMessage;
                            existingCartPosition.WareQnt += cart.WareQnt;
                            _cartRepository.EditQntCartPosition(SessionHelper.CurrentUser, existingCartPosition);
                        }
                        else
                        {
                            if (cart.WareQnt > 0) carts.Add(cart);
                            TempData["Cart"] = carts;
                            AddToCart(0);
                        }
                            
                        carts = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
                        SessionHelper.CurrentClient.Breefing.Clear();
                        SessionHelper.Cart = carts;
                    }
                    else
                    {
                        if (cart.WareQnt > 0) carts.Add(cart);
                    }

                }
            }

            return new JsonResult { Data = new { carts }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        public JsonResult CartSyncToLocalStorage(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                var carts = new List<CartPosition>();

                var result = JsonConvert.DeserializeObject<List<CartPosition>>(json);
                var currentCart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
                foreach(var cartItem in result)
                {
                    if (currentCart.Any(item => item.ProducerId == cartItem.ProducerId && item.WareId == cartItem.WareId))
                        {
                        var editPos = currentCart.Where(i => i.ProducerId == cartItem.ProducerId && i.WareId == cartItem.WareId).FirstOrDefault();
                        editPos.WareQnt += cartItem.WareQnt;
                        _cartRepository.EditQntCartPosition(SessionHelper.CurrentUser, editPos);
                    }
                    else
                    {
                        var cart = new CartPosition();
                        cart.WareId = cartItem.WareId;
                        cart.WareQnt = cartItem.WareQnt;
                        cart.ProducerId = cartItem.ProducerId;
                        cart.ProducerName = cartItem.ProducerName;
                        cart.WareNum = cartItem.WareNum;
                        cart.WareName = cartItem.WareName;
                        cart.ClientPrice = cartItem.ClientPrice;
                        cart.OfferId = cartItem.OfferId;
                        if (cart.WareQnt > 0) carts.Add(cart);
                        TempData["Cart"] = carts;
                        AddToCart(0);
                    }
                }
                carts = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
                SessionHelper.CurrentClient.Breefing.Clear();
                SessionHelper.Cart = carts;

                return new JsonResult { Data = new { message = "SyncSuccessful", carts = carts }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
                return new JsonResult { Data = new { message = "SyncError" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [ValidateInput(true)]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult PrepareForCart(string[] wareId, string[] offerId, int[] offerQnt, int? offerTypeId, int? modif, string comment, bool? gotoCart, long? ticks = null)
        {
            //if (ticks == null)
            //    ticks = DateTime.Now.Ticks;
            var carts = new List<CartPosition>();
            if (offerQnt != null && offerId != null && wareId != null)
            {
                if (offerId.Length != offerQnt.Length || offerQnt.Length != wareId.Length) return View("Error");
                TempData["Message"] = null;
                var currentCart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);

                for (int i = 0; i < offerId.Length; i++)
                {
                    var cart = new CartPosition();
                    var offer = new Offer { Id = offerId[i] };
                    cart.SupplierUid = offer.SupplierUid;
                    cart.DeliveryTerm = offer.DeliveryTerm;
                    cart.ClientPrice = offer.ClientPrice;
                    cart.WareId = wareId[i];
                    cart.WareQnt = offerQnt[i] > 999 ? 999 : offerQnt[i];
                    //cart.OfferTypeId = offerTypeId;
                    cart.IsSale = offerTypeId == 2;
                    cart.WarehouseId = offer.SupplierWarehouseUid ?? SessionHelper.CurrentWarehouseId;
                    //if (offer.OfferTypeId != 1)
                    //    cart.WarehouseId = offer?.SupplierId ?? SessionHelper.CurrentWarehouseId;
                    //else if (offer.OfferTypeId > 2)
                    //{
                    //    cart.SupplierId = offer.SupplierId;
                    //}
                    cart.Comment = comment;
                    //cart.ModifId = modif;
                    // cart.WarehouseQnt = whQnt[i];
                    Log.Debug($"Adding to cart: WareId: {cart.WareId}, offerid {offerId}, suppId: {cart.SupplierUid}, WareQnt: {cart.WareQnt}, WarehouseId: {cart.WarehouseId}");
                    if (currentCart.Any(item => item.WareId == cart.WareId))
                        TempData["Message"] = SharedResources.ExistingCartItemMessage;

                    if (cart.WareQnt > 0) carts.Add(cart);
                }
                //
                TempData["Cart"] = carts;
                TempData["GotoCart"] = gotoCart;
                return AddToCart(ticks ?? 0);
            }
            return RedirectToAction("Index", "Cart");
        }

        [System.Web.Mvc.Authorize]
        public ActionResult AddToCart(long ticks)
        {
            if (!(TempData["Cart"] is List<CartPosition> carts)) return RedirectToAction("Index");

            foreach (var cart in carts)
            {
                cart.UserId = SessionHelper.CurrentUser.Id;

                if (SessionHelper.CurrentClientId != null)
                    cart.ClientId = SessionHelper.CurrentClientId;

                _cartRepository.AddCartPosition(SessionHelper.CurrentUser, cart, UserPreferences.CurrentCulture);
            }
            SessionHelper.CurrentClient.Breefing.Clear();
            SessionHelper.Cart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser);
            var gotoCart = (bool?)TempData["GotoCart"];
            return gotoCart == true ? (ActionResult)RedirectToAction("Index") : 
                ticks == 0 ? new JsonResult { Data = TempData["Message"] } : new JsonResult { Data = new { message = TempData["Message"], ticks = ticks } };
        }

        public JsonResult GetCartOrderPosistionsCount()
        {
            var cartString = $"{SessionHelper.CurrentClient.Breefing.Data.CartPositionsCount:d}";
            var orderString = $"{SessionHelper.CurrentClient.Breefing.Data.ActiveOrdersCount} {SharedResources.active}";
            var result = new JsonResult { Data = new { cart = cartString, order = orderString }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ImportToCart(int codeColumn, int brandColumn, int qntColumn)
        {
            if (Request.Files.Count == 0)
                return RedirectToAction("Index");

            var file = Request.Files[0];
            var clientId = SessionHelper.CurrentClientId;

            //var myFile = Request.Files[0];
            //var path = Path.Combine(Server.MapPath("~/App_Data/temp"), myFile.FileName);

            if (!(file?.ContentLength > 0))
                return RedirectToAction("Index");

            using (MemoryStream ms = new MemoryStream())
            {

                file.InputStream.CopyTo(ms);

                var rowIndex = 0;
                var spArray = new List<ImportPosition>();
                using (var reader = ExcelReaderFactory.CreateReader(ms))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            rowIndex++;

                            if (rowIndex > 1) // 1 header
                            {
                                var sp = new ImportPosition();
                                int colNo = 0;
                                try
                                {
                                    colNo = codeColumn - 1;
                                    sp.Number = GetStrVal(reader.GetValue(colNo));

                                    colNo = brandColumn - 1;
                                    sp.Brand = GetStrVal(reader.GetValue(colNo));

                                    colNo = qntColumn - 1;
                                    sp.Quantity = int.TryParse(GetStrVal(reader.GetValue(colNo)), out int qnt) ? qnt : 0;

                                    if (!string.IsNullOrWhiteSpace(sp.Number) && !string.IsNullOrWhiteSpace(sp.Brand) && sp.Quantity != 0)
                                    {
                                        spArray.Add(sp);
                                    }
                                }
                                catch (System.IndexOutOfRangeException ex)
                                {
                                    Log.Error("ImportToCart", ex);
                                    TempData["Title"] = SharedResources.Error;
                                    TempData["Message"] = string.Format(SharedResources.UploadSupplierPriceKrosMissingData, rowIndex, colNo);
                                    TempData["MsgImage"] = Url.Content("~/Content/images/error.jpg");
                                    return RedirectToAction("Show", "Message");
                                }
                            }
                        }
                    } while (reader.NextResult());
                }
                ms.Close();
                var model = new ImportCartResultViewModel
                {
                    ImportResult = _cartRepository.ImportToCart(clientId, SessionHelper.CurrentUser.Id, SessionHelper.CurrentWarehouseId, spArray)
                };

                string currentParentLink = UserPreferences.CurrentCultureLink + "/";
                foreach (var item in model.ImportResult)
                {
                    item.FullUrl = string.IsNullOrEmpty(item.Name) ? null : Url.Content("~/" + currentParentLink + item.URL);
                }
                return View(model);
            }
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        public ActionResult ImportToCartExele(int codeColumn, int brandColumn, int qntColumn)
        {
            if (Request.Files.Count == 0)
            {
                TempData["Title"] = SharedResources.Error;
                TempData["Message"] = "Нет Файла";
                return View(PrepareCartModel(null, new GridViewOptions()));
            }

            var file = Request.Files[0];
            var clientId = SessionHelper.CurrentClientId;

            if (!(file?.ContentLength > 0))
            {
                TempData["Title"] = SharedResources.Error;
                TempData["Message"] = "Файл Пустой";
                return View(PrepareCartModel(null, new GridViewOptions()));
            }

            using (MemoryStream ms = new MemoryStream())
            {

                file.InputStream.CopyTo(ms);

                var rowIndex = 0;
                var spArray = new List<ImportPosition>();
                using (var reader = ExcelReaderFactory.CreateReader(ms))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            rowIndex++;

                            if (rowIndex > 1) // 1 header
                            {
                                var sp = new ImportPosition();
                                int colNo = 0;
                                try
                                {
                                    colNo = codeColumn - 1;
                                    sp.Number = GetStrVal(reader.GetValue(colNo));

                                    colNo = brandColumn - 1;
                                    sp.Brand = GetStrVal(reader.GetValue(colNo));

                                    colNo = qntColumn - 1;
                                    sp.Quantity = int.TryParse(GetStrVal(reader.GetValue(colNo)), out int qnt) ? qnt : 0;

                                    if (!string.IsNullOrWhiteSpace(sp.Number) && !string.IsNullOrWhiteSpace(sp.Brand) && sp.Quantity != 0)
                                    {
                                        spArray.Add(sp);
                                    }
                                }
                                catch (System.IndexOutOfRangeException ex)
                                {
                                    Log.Error("ImportToCart", ex);
                                    TempData["Title"] = SharedResources.Error;
                                    TempData["Message"] = string.Format(SharedResources.UploadSupplierPriceKrosMissingData, rowIndex, colNo);
                                    return View(PrepareCartModel(null, new GridViewOptions()));
                                }
                            }
                        }
                    } while (reader.NextResult());
                }
                ms.Close();

                // TODO Пока нет 1с. После нужно реализовать данный функционал 
                /*var model = new ImportCartResultViewModel
                {
                    ImportResult = _cartRepository.ImportToCart(clientId, SessionHelper.CurrentUser.Id, SessionHelper.CurrentWarehouseId, spArray)
                };

                string currentParentLink = UserPreferences.CurrentCultureLink + "/";
                foreach (var item in model.ImportResult)
                {
                    item.FullUrl = string.IsNullOrEmpty(item.Name) ? null : Url.Content("~/" + currentParentLink + item.URL);
                }*/
                //

                foreach(var item in spArray)
                {
                    //AddCartToStoreOrLocalStorage("0", "testasd", item.Number, item.Brand, item.Quantity, 10, false);
                }
                TempData["Title"] = "Внимание";
                TempData["Message"] = "Товары добавлены в корзину";
            }

            var modelView = PrepareCartModel(null, new GridViewOptions());

            return View(modelView);
        }


        private string GetStrVal(object o)
        {
            return o?.ToString() ?? "";
        }
    }
}
