using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ValmiStore.Model.Entities.Order;
using Webmall.Model;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.Order;
using Webmall.UI.Api;
using Webmall.UI.Api.Models;
using Webmall.UI.Core;
using Webmall.UI.Models.Clients;
using Order = Webmall.Model.Entities.Order.Order;

namespace Webmall.UI.Mappings
{
    public class OrderRepositoryProfile : Profile
    {
        public OrderRepositoryProfile()
        {
            CreateMap<OrderListItem, OrderListItemDto>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.OrderDate, e => e.MapFrom(i => i.OrderDate))
                .ForMember(i => i.Sum, e => e.MapFrom(i => decimal.Parse(string.Format(ConfigHelper.PriceFormat, i.Sum ?? 0))))
                .ForMember(i => i.Status, e => e.MapFrom(i => i.StatusName))
                .ForMember(i => i.StatusId, e => e.MapFrom(i => i.StatusId))
                .ForMember(i => i.NeedToPay, e => e.MapFrom(i => i.PaymentInfo.NeedToPay))
                .ForMember(i => i.CanDelete, e => e.MapFrom(i => i.CanDelete))
                .ForMember(i => i.CanChange, e => e.MapFrom(i => i.CanChange))
                .ForMember(i => i.DeleteBlockMessage, e => e.MapFrom(i => i.DeleteBlockMessage))
                .ForMember(i => i.IsPayed, e => e.MapFrom(i => i.PaymentInfo.IsPayed))
                .ForMember(i => i.IsReserved, e => e.MapFrom(i => i.IsReserved))
                .ForMember(i => i.CurrencyCode, e => e.MapFrom(i => i.PaymentInfo.CurrencyCode));

            CreateMap<OrdersListFilterPayload, OrderFilterOptions>()
                .ForMember(i => i.OrderId, e => e.MapFrom(i => i.OrderId))
                //.ForMember(i => i.Statuses,
                //    e => e.MapFrom((requestFilter, filter) => !string.IsNullOrEmpty(requestFilter.Status)
                //        ? new List<string> { requestFilter.Status }
                //        : null))
                .ForMember(i => i.WareName, e => e.MapFrom(i => i.WareName))
                .ForMember(i => i.DateFrom, e => e.MapFrom(i => i.DateFrom))
                .ForMember(i => i.DateTo, e => e.MapFrom(i => i.DateTo));

            CreateMap<PageSettingsPayload, PageOptions>()
                .ForMember(i => i.PageNumber, e => e.MapFrom(i => i.Skip/i.Take+1))
                .ForMember(i => i.PageSize, e => e.MapFrom(i => i.Take));

            CreateMap<GridViewOptions, PageOptions>()
                .ForMember(i => i.Direction, e => e.MapFrom(i => i.SortDirection))
                .ForMember(i => i.PageNumber, e => e.MapFrom(i => i.CurrentPage))
                .ForMember(i => i.PageSize, e => e.MapFrom(i => i.PageSize))
                .ForMember(i => i.OrderColumn, e => e.MapFrom(i => i.SortColumn));
                

            CreateMap<RefOrderStatus, OrderStatusDto>()
                .ForMember(i => i.Color, e => e.MapFrom(i => i.Color))
                .ForMember(i => i.Text, e => e.MapFrom(i => i.StatusName))
                .ForMember(i => i.Value, e => e.MapFrom(i => i.StatusId));

            CreateMap<Valute, ValuteDto>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.Rate, e => e.MapFrom(i => i.Rate))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.ShortName, e => e.MapFrom(i => i.Code));

            CreateMap<OrderPosition, OrderPositionDto>()
                .ForMember(i => i.PositionId, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.WareId, e => e.MapFrom(i => i.WareNumber))
                // trim WareNum if starts from
                .ForMember(i => i.Name, e => e.MapFrom((pos, dto) =>
                {
                    return pos.WareName.ToLower().StartsWith(pos.WareNumber.ToLower() + " ") ?
                        pos.WareName.Substring(pos.WareNumber.Length).Trim() :
                        pos.WareName;
                }))
                .ForMember(i => i.Brand, e => e.MapFrom(i => i.ProducerName))
                .ForMember(i => i.Price, e => e.MapFrom(i => i.Price))
                .ForMember(i => i.Quantity, e => e.MapFrom(i => i.WareQnt))
                //.ForMember(i => i.WarehouseQuantity, e => e.MapFrom(i => i.WarehouseQnt))
                //.ForMember(i => i.ErrorMessage, e => e.MapFrom(i => i.ErrorMessage))
                .ForMember(i => i.InReserve, e => e.MapFrom(i => i.IsReserved))
                .ForMember(i => i.Weight, e => e.MapFrom(i => i.Weight))
                // max in warehouse
                //.ForMember(i => i.WarehouseQnt, e => e.MapFrom(i => i.WarehouseQnt))

                .ForMember(i => i.Total, e => e.MapFrom(i => i.Sum));

            // In: PosId, Qnt, WareId
            // Out: PosId?, Qnt, Price, Total, OrderTotal, Message

            CreateMap<Order, OrderDto>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.PayerEmail, e => e.MapFrom((i, _) => SessionHelper.CurrentUser.Email))
                //.ForMember(i => i.DeliveryType, e => e.MapFrom((i, dto) =>
                //{
                //    return i.Delivery?.DeliveryTypeId != null ? "Доставка" : "Самовывоз";
                //}))
                //.ForMember(i => i.DeliveryAddressPresenter, e => e.MapFrom(i => i.Delivery.Address))
                //.ForMember(i => i.DeliveryAddressId, e => e.MapFrom(i => i.Delivery.DeliveryAddressId))
                //.ForMember(i => i.DeliveryTypeId, e => e.MapFrom(i => i.Delivery.DeliveryTypeId))
                //.ForMember(i => i.DeliveryArrivalTime, e => e.MapFrom(i => i.Delivery.ArrivalTime))
                // адрес склада для самовывоза 
                //.ForMember(i => i.Total, e => e.MapFrom(i => i.WarehouseAddress))
                .ForMember(i => i.DeliverySchedule, e => e.MapFrom((i, dto) =>
                {
                    // TODO return i.DeliverySchedule;
                    return new[] { 1, 2, 3 }.Select(offset => DateTime.Now.AddDays(offset)).ToArray();
                }))

                .ForMember(i => i.Total, e => e.MapFrom(i => decimal.Parse(string.Format(ConfigHelper.PriceFormat, i.Sum ?? 0))))
                .ForMember(i => i.Positions, e => e.MapFrom(i => i.Positions))
                .ForMember(i => i.StatusId, e => e.MapFrom(i => i.StatusName))
                .ForMember(i => i.HasDebt, e => e.MapFrom(i=>SessionHelper.CurrentClient.Breefing.Data.HaveDebt))
                ;

            CreateMap<Address, AddressDto>()
                .ForMember(d => d.Comment, e => e.MapFrom(a => a.Comment))
                .ForMember(d => d.Flat, e => e.MapFrom(a => a.Flat))
                .ForMember(d => d.House, e => e.MapFrom(a => a.House))
                .ForMember(d => d.AddressId, e => e.MapFrom(a => a.AddressId))
                .ForMember(d => d.LocalityId, e => e.MapFrom(a => a.LocalityId))
                .ForMember(d => d.LocalityName, e => e.MapFrom(a => a.LocalityName))
                .ForMember(d => d.RegionId, e => e.MapFrom(a => a.RegionId))
                .ForMember(d => d.RegionName, e => e.MapFrom(a => a.RegionName))
                .ForMember(d => d.StreetName, e => e.MapFrom(a => a.StreetName));

            CreateMap<DeliveryAddress, DeliveryAddressDto>()
                .ForMember(d => d.AddressPresenter, e => e.MapFrom(a => a.AddressPresentator))
                .ForMember(d => d.IsDefault, e => e.MapFrom(a => a.IsDefault))
                .ForMember(d => d.IsSelectable, e => e.MapFrom(a => a.IsSelectable))
                .ForMember(d => d.IsDeletePossible, e => e.MapFrom(a => a.IsDeletePossible));

            CreateMap<DeliveryAddressesModel, DeliveryAddressesDto>()
                .ForMember(d => d.Addresses, e => e.MapFrom(a => a.Addresses))
                .ForMember(d => d.AllowEdit, e => e.MapFrom(a => a.AllowEdit))
                .ForMember(d => d.MaxAddresses, e => e.MapFrom(a => a.MaxAddresses));

            CreateMap<AddressDto, Address>()
                .ForMember(d => d.Comment, e => e.MapFrom(a => a.Comment))
                .ForMember(d => d.Flat, e => e.MapFrom(a => a.Flat))
                .ForMember(d => d.House, e => e.MapFrom(a => a.House))
                .ForMember(d => d.AddressId, e => e.MapFrom(a => a.AddressId))
                .ForMember(d => d.LocalityId, e => e.MapFrom(a => a.LocalityId))
                .ForMember(d => d.LocalityName, e => e.MapFrom(a => a.LocalityName))
                .ForMember(d => d.RegionId, e => e.MapFrom(a => a.RegionId))
                .ForMember(d => d.RegionName, e => e.MapFrom(a => a.RegionName))
                .ForMember(d => d.StreetName, e => e.MapFrom(a => a.StreetName));

            CreateMap<DeliveryAddressBaseDto, DeliveryAddress>()
                .ForMember(d => d.IsDefault, e => e.MapFrom(a => a.IsDefault));

            CreateMap<SelectListItem, ReferenceItemDto>()
                .ForMember(d => d.Code, e => e.MapFrom(a => a.Value))
                .ForMember(d => d.Name, e => e.MapFrom(a => a.Text))
                .ForMember(d => d.IsSelected, e => e.MapFrom(a => a.Selected));

            CreateMap<DeliverySchedule, DeliveryDateTimeDto>()
                .ForMember(d => d.DeliveryDateTime, e => e.MapFrom(a => a.ReceiveTime));

        }
    }
}