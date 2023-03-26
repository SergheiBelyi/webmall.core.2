using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValmiStore.Model.Entities;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Client;
using Webmall.UI.Models.Ware;

namespace Webmall.UI.Core.Core
{
    public static class WareListHelper
    {
        static Valute Valute => SessionHelper.CurrentValute;
        static decimal  Rate => Valute.Rate;
        static bool ShowFullQuantity => SessionHelper.IsOrganizationManager;
        static bool AllowCustomOrders => SessionHelper.AllowCustomOrders;
        static string CurrentParentLink => UserPreferences.CurrentCultureLink + "/";

        public static WareCardList WareToWareCardList(WaresCatalogModel catalog, HttpRequestBase request, UrlHelper url)
        {
            var modelParameterUrlPart = (catalog.ModifId != null ? "modif=" + catalog.ModifId : "");
            modelParameterUrlPart += (catalog.GroupId != null ? "&groupId=" + catalog.GroupId : "");
            modelParameterUrlPart += (catalog.NeedReturnURL ? (string.IsNullOrEmpty(modelParameterUrlPart) ? "" : "&") + "returnUrl=" + request.Url : "");
            modelParameterUrlPart = (string.IsNullOrEmpty(modelParameterUrlPart) ? "" : "?") + modelParameterUrlPart;

            var result = MakeWareCardList(catalog.Wares.List, modelParameterUrlPart, catalog.CanAddToCart, catalog.AllowCustomOrders, url);

            return result;
        }


        public static WareCardList MakeWareCardList(IEnumerable<ValmiStore.Model.Entities.Ware> wares, string modelParameterUrlPart, bool canAddToCart, bool allowCustomOrders, UrlHelper url)
        {
            var result = new WareCardList
            {
                CanAddToCart = canAddToCart,
                AllowCustomOrders = allowCustomOrders
            };

            foreach (var ware in wares)
            {
                WareCard wareDto = WareToWareCard(ware, url, modelParameterUrlPart);
                result.Add(wareDto);
            }
            return result;
        }

        public static WareCard WareToWareCard(ValmiStore.Model.Entities.Ware ware, UrlHelper urlHelper, string parameterUrlPart)
        {
            var url = urlHelper.Content("~/" + CurrentParentLink + ware.URL) + parameterUrlPart;
            //var wareName = ((string.IsNullOrEmpty(ware.WareType)) ? "" : ware.WareType + " ") + ware.Name;
            //var canAddToCart = ware.CanAddToCart && (ware.WareQntTotal > 0 || AllowCustomOrders);
            //var mult = ware.SaleMultiplier > 1 ? ware.SaleMultiplier : 1;
            var imgUrl = urlHelper.Content("~/Content/images/noWareImageSmall.png");
            if (ware.HasImage && !string.IsNullOrEmpty(ware.MainImageCode)) { imgUrl = urlHelper.Action("GetImage", "Images", new { imageId = ware.MainImageCode }); }
            var warePrice = SessionHelper.PriceFormat(ware.ClientPrice / Rate);
            var retailPrice = SessionHelper.PriceFormat(ware.RetailPrice / Rate);
            var offerTypeId = ware.WareQnt > 0 ? "1" : "";
            var offer = ware.Offers?.FirstOrDefault() ?? ware.Offer;
            var inStockQty = Helper.QuantityDigitalPresenter(ware.WareQntTotal, ShowFullQuantity);

            var offersCnt = ware.Offers?.Count ?? 0;
            if (offersCnt == 0)
            {
                if (ware.Offers == null)
                    ware.Offers = new List<Offer>();
                ware.Offers.Add(EmptyOffer(ware, null));
                offersCnt = 1;
            }

            //var onePrice = ware.Offers.All(of => of.Price == ware.Offers[0].Price) && !ware.IsSale;

            var wareDto = new WareCard
            {
                Id = ware.Id,
                IdNorm = ware.IdNorm,
                Name = ware.Name,
                PartNumber = ware.WareNum,
                ProducerName = ware.ProducerName,
                UOM = ware.MeasureUnit?.ToLower(),
                InStockQty = inStockQty,
                ValuteName = Valute.Code,
                Url = url,
                ImgUrl = imgUrl,
                Price = warePrice,
                RetailPrice = retailPrice,
                OfferId = (offer != null) ? offer.Id : "",
                OfferTypeId = offerTypeId,
                Offers = ware.Offers.CloneCollection().ToList(),
                CanAddToCart = ware.CanAddToCart,
                OnlyForReservation = ware.OnlyForReservation,
                SaleMultiplier = ware.SaleMultiplier > 1 ? ware.SaleMultiplier : 1,
                OnePrice = ware.Offers.All(of => of.Price == ware.Offers[0].Price) && !ware.IsSale,
                IsPresent = ware.IsPresent,
                IsSale = ware.IsSale,
                IsAction = ware.IsAction,
                IsNew = ware.IsNew,
                ShowAction = ware.ShowAction,
                DiscGroupTypeId = ware.DiscGroupTypeId,
                CurrentWarehouseId = SessionHelper.CurrentWarehouseId,
                InCart = ware.InCart,
                LoadAnalogues = ware.LoadAnalogues,
            };

            if (wareDto.IsNew)
                wareDto.Stickers.Add(new Sticker { ClassName = "new", Title = SharedResources.NewWare });
            if (wareDto.IsAction)
                wareDto.Stickers.Add(new Sticker { ClassName = "action", Title = SharedResources.Action });
            if (wareDto.IsSale)
                wareDto.Stickers.Add(new Sticker { ClassName = "action", Title = SharedResources.Sale });

            if (ConfigHelper.AlwaysCurrentWarehouseOffer && wareDto.Offers.All(i=>i.WarehouseId != SessionHelper.CurrentWarehouseId))
            {
                wareDto.Offers.Insert(0, EmptyOffer(ware, null));
                //offersCnt++;
            }

            var qp = new QuantityPresenter(SessionHelper.IsOrganizationManager);
            foreach (var item in wareDto.Offers)
            {
                item.InStockQty = qp.ShippingStockQnt(item);
                item.MainValutePrice = item.Price;
                item.Price = item.Price / Rate;
                item.RetailPrice = item.RetailPrice / Rate;
            }

            return wareDto;
        }

        private static Offer EmptyOffer(ValmiStore.Model.Entities.Ware ware, DateTime? deliveryTerm)
        {
            return new Offer
            {
                MaxQuantity = ware.WareQntTotal,
                MinQuantity = 0,
                ShippingStockQnt = ware.WareQntTotal,
                DeliveryTerm = deliveryTerm, // DateTime.Now.AddMonths(1),
                BasePrice = ware.ClientPrice,
                DiscountPercentage = 0,
                Price = ware.ClientPrice,
                RetailPrice = ware.RetailPrice,
                OfferTypeId = 1,
                WarehouseId = SessionHelper.CurrentWarehouseId,
                WarehouseName = SessionHelper.CurrentWarehouseName,
            };
        }

        //public static void FillOffersCartQnt (Ware ware, IList<CartPosition> cart)
        //{
        //    if (ware?.Offers == null)
        //        return;
        //    foreach (var offer in ware.Offers)
        //    {
        //        var inCartQnt = SessionHelper.Cart.Where(c => IsOfferInCartPosition(ware.Id, offer, c)).Sum(i => i.WareQnt);
        //        offer.InCart = (int)(inCartQnt ?? 0);
        //    }
        //}


        public static bool IsOfferInCartPosition (string wareId, Offer offer, CartPosition cartPos)
        {
            return cartPos.WareId == wareId
                && (string.IsNullOrEmpty(offer.SupplierId) || cartPos.SupplierUid == offer.SupplierId)
                && (string.IsNullOrEmpty(offer.WarehouseId) || cartPos.WarehouseId == offer.WarehouseId);
        }
    }

}
