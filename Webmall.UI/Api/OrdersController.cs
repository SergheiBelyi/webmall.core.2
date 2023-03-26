using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Webmall.Model;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.Order;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Api.Models;
using Webmall.UI.Core;
using Webmall.UI.Models.Clients;

namespace Webmall.UI.Api
{
    [Authorize]
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(OrdersController));

        static OrdersController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IReferenceRepository _referenceRepository;
        private readonly ICmsRepository _cmsRepository;
        private readonly IAddressRepository _addressRepository;

        public OrdersController(IMapper mapper, IOrderRepository orderRepository,
            IReferenceRepository referenceRepository, ICmsRepository cmsRepository, IAddressRepository addressRepository)
        {
            _cmsRepository = cmsRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
            _referenceRepository = referenceRepository;
            _orderRepository = orderRepository;
        }

        //[HttpPost]
        //[Route("list")]
        //public OrderListResponse List(OrdersListFilterPayload requestFilterPayload)
        //{
        //    // + order repeat btn
        //    // + order remove btn canDelete: false deleteBlockMessage: ""
        //    // <> "" => доставка (click on Info=bubble: DeliveryAddress) / самовывоз
        //    try
        //    {
        //        var filter = _mapper.Map<OrderFilterOptions>(requestFilterPayload);
        //        var paging = _mapper.Map<PageOptions>(requestFilterPayload.PageSettings);

        //        var result =
        //            _orderRepository.GetOrderList(SessionHelper.CurrentUser, filter, paging);
        //        //var rate = (SessionHelper.Valutes.Count() > 1) ? SessionHelper.CurrentValute.Rate : 1;
        //        foreach (var item in result.List)
        //        {
        //            if (item.StatusId == OrderStatuses.Draft.ToString() && item.IsReserved)
        //            {
        //                item.StatusId = OrderStatuses.Reserved.ToString();
        //                item.Status = SharedResources.Reserved;
        //            }
        //            if (SessionHelper.CurrentUser.CurrentPresenter.CanSeePrices)
        //                item.Sum = item.Sum;
        //            else
        //                item.Sum = 0.0M;
        //            item.DeliveryInfo.Address = item.DeliveryInfo.Address.Replace("\n", "<br>");
        //        }

        //        return new OrderListResponse
        //        {
        //            List = result.List.Select(_mapper.Map<OrderListItemDto>).OrderByDescending(i => i.OrderDate)
        //                .ToArray(),
        //            Total = result.Total
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error("Orders list error", e);
        //        throw;
        //    }
        //}

        [HttpGet]
        [Route("order-statuses")]
        public OrderStatusDto[] GetOrderStatuses()
        {
            return _orderRepository.GetOrderStatuses(UserPreferences.CurrentCulture)
                .Select(_mapper.Map<OrderStatusDto>).ToArray();
        }

        [HttpGet]
        [Route("order")]
        public OrderDto GetOrder(string orderId)
        {
            // TODO fetch order positions errors
            var order = _orderRepository.GetOrder(UserPreferences.CurrentCulture, SessionHelper.CurrentClientId, orderId, true);
            if (order == null)
                return null;
            ////ProcessOrderPositions(order);
            //if (order.Status == OrderStatuses.Draft.ToString())
            //    order.PaymentType = 1;
            var result = _mapper.Map<OrderDto>(order);
            CheckOrderDebt(order, result);
            result.AllowPickup = true; // SessionHelper.CurrentUser?.CurrentClient?.Client.AllowSelfDelivery ?? false;

            if (SessionHelper.CurrentUser.CurrentPresenter.CanSeePrices)
                return result;
            else
                return ClearPricesFromOrder(result);
        }

        private OrderDto ClearPricesFromOrder(OrderDto result)
        {
            OrderDto notPricesAvdOrderDto = new OrderDto();
            notPricesAvdOrderDto.Total = 0.0M;
            notPricesAvdOrderDto.Positions = result.Positions.Select(i => new OrderPositionDto
            {
                Brand = i.Brand,
                DeliveryTerm = i.DeliveryTerm,
                Price = 0.0M,
                ErrorMessage = i.ErrorMessage,
                InReserve = i.InReserve,
                Name = i.Name,
                PositionId = i.PositionId,
                Quantity = i.Quantity,
                Total = 0.0M,
                Warehouse = i.Warehouse,
                WareId = i.WareId,
                Weight = i.Weight
            }).ToArray();

            return notPricesAvdOrderDto;
        }

        protected void CheckOrderDebt(Order order, OrderDto result)
        {
            // Контроль задолженности
            //if (order.Status == OrderStatuses.Draft.ToString())
            //{
            //    var debtInfo = _orderRepository.CheckClientDebtBlock(SessionHelper.CurrentUser, order.Id, UserPreferences.CurrentCulture);
            //    string debtMessage = debtInfo?.Message;
            //    if (string.IsNullOrEmpty(debtMessage))
            //    {
            //        SessionHelper.CurrentUser.HaveDebtBlock = false;
            //    }
            //    else
            //    {
            //        SessionHelper.CurrentUser.HaveDebtBlock = true;
            //        result.DebtMessage = debtMessage + " " + SharedResources.ThankForUnderstanding;
            //    }
            //    result.Limit = debtInfo?.Limit ?? 0;
            //}
            //else
            //{
            //    SessionHelper.CurrentUser.HaveDebtBlock = false;
            //}
        }

        //protected static void ProcessOrderPositions(Order order)
        //{
        //    if (order?.Positions == null)
        //        return;
        //    foreach (var pos in order.Positions)
        //    {
        //        // Контроль кратности
        //        if (pos.SaleMultiplier > 1 && pos.WareQnt % pos.SaleMultiplier != 0)
        //            pos.ErrorMessage = SharedResources.MultComment;
        //        // Контроль превышения складских запасов
        //        else if (pos.WareQnt > pos.WarehouseQnt && !(SessionHelper.AllowCustomOrders && pos.OfferTypeId != 2))
        //            pos.ErrorMessage = string.Format(SharedResources.OvervalueComment, pos.WarehouseQnt);
        //    }
        //}

        [HttpPost]
        [Route("positions")]
        public OrderDto UpdateOrderPosition(UpdateOrderPositionPayload payload)
        {
            throw new NotImplementedException();
            //var result = _orderRepository.UpdateOrderPositionQuantity(payload.PositionId, payload.Quantity);
            //var order = GetOrder(payload.OrderId);
            //if (!string.IsNullOrEmpty(result))
            //{
            //    var position = order.Positions.FirstOrDefault(i => i.PositionId == payload.PositionId);
            //    if (position != null)
            //    {
            //        //position.Quantity = position.WarehouseQuantity;
            //        position.WarningMessage = string.Format(SharedResources.MaxWarehouseQntAchived, position.WarehouseQuantity);
            //    }
            //}

            //return order;
        }

        [HttpDelete]
        [Route("positions-delete")]
        public OrderDto RemoveOrderPositions(RemoveOrderPositionsPayload payload)
        {
            //if (payload.PositionIds?.Length > 0)
            //    _orderRepository.DeletePositions(SessionHelper.CurrentUser, payload.OrderId, payload.PositionIds.ToList());
            //var order = GetOrder(payload.OrderId);
            //return order;
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("address")]
        public DeliveryAddressesDto DeliveryAddresses()
        {
            var clientId = SessionHelper.CurrentClientId;
            var model = new DeliveryAddressesModel()
            {
                Addresses = _addressRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, clientId, UserPreferences.CurrentCulture),
                AllowEdit = true,  //SessionHelper.IsGross,
                MaxAddresses = _cmsRepository.GetDeliveryConfig().MaxAdressesCount,
                //Regions = SimpleReference.Convert(referenceRepository.GetRegions(null, UserPreferences.CurrentCulture), false).OrderBy(i => i.Text)
            };
            foreach (var item in model.Addresses)
            {
                item.IsSelectable = item.IsDeliveryPoint || SessionHelper.IsGross;
            }
            return _mapper.Map<DeliveryAddressesDto>(model);
        }

        /// <summary>
        /// Заполняются только данные *Id класса Address  
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("address")]
        public DeliveryAddressesDto AddOrUpdateAddress(DeliveryAddressBaseDto address)
        {
            if (SessionHelper.CurrentClientId != null)
            {
                var addressModel = _mapper.Map<DeliveryAddress>(address);
                _addressRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, addressModel);
            }
            return DeliveryAddresses();
        }

        [HttpDelete]
        [Route("address")]
        public DeliveryAddressesDto RemoveAddress(string addressId)
        {
            _addressRepository.RemoveDeliveryAddress(addressId, SessionHelper.CurrentClientId);
            return DeliveryAddresses();
        }

        [HttpGet]
        [Route("delivery-types")]
        public ReferenceItemDto[] GetDeliveryTypes()
        {
            var list = _referenceRepository.GetDeliveryTypes(SessionHelper.CurrentClientId, UserPreferences.CurrentCulture).ToArray();
            return _mapper.Map<ReferenceItemDto[]>(list);
        }

        [HttpGet]
        [Route("delivery-datetimes")]
        public DeliveryDateTimeDto[] GetDeliveryDateTimes(string orderId, string deliveryAddressId, int paymentType)
        {
            //var order = _orderRepository.GetOrder(SessionHelper.CurrentUser, orderId, false, UserPreferences.CurrentCulture, true);
            //var list = _orderRepository
            //        .GetDeliverySchedule(SessionHelper.CurrentUser, orderId, deliveryAddressId ?? "", order.WarehouseId, DateTime.Now,
            //            paymentType, UserPreferences.CurrentCulture, out _);
            //return _mapper.Map<DeliveryDateTimeDto[]>(list);
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("delivery-references")]
        public DeliveryReferencesResponse DeliveryReferences(string regionCode)
        {
            var result = new DeliveryReferencesResponse();
            var defaultRegionId = ConfigHelper.DefaultRegionId;

            result.Regions = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture)
                .Select(i => new ReferenceItemDto { Code = i.Id, Name = i.Value, IsSelected = (i.Id == defaultRegionId) })
                .OrderBy(i => i.Name)
                .ToArray();

            if (string.IsNullOrEmpty(regionCode))
            {
                regionCode = result.Regions.FirstOrDefault(i => i.IsSelected)?.Code ?? result.Regions.FirstOrDefault()?.Code;
            }

            result.Cities = _addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, regionCode)
                    .Select(i => new ReferenceItemDto { Code = i.Id, Name = i.Value })
                    .OrderBy(i => i.Name)
                    .ToArray();

            return result;
        }

        /// <summary>
        /// Возвращает сптсок улиц (мспользуется рекомендательно)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("streets")]
        public ReferenceItemDto[] Streets()
        {
            return _addressRepository.GetStreets(UserPreferences.CurrentCulture, null)
                 .Select(i => new ReferenceItemDto { Code = i.Id, Name = i.Value })
                 .OrderBy(i => i.Name)
                 .ToArray();
        }

        [HttpGet]
        [Route("valute")]
        public Valute GetValute()
        {
            return SessionHelper.CurrentValute;
        }

        [HttpGet]
        [Route("client")]
        public ClientDto GetClientInfo()
        {
            throw new NotImplementedException();
            //var result = new ClientDto
            //{
            //    Id = SessionHelper.CurrentClientId,
            //    Valute = _mapper.Map<ValuteDto>(SessionHelper.CurrentValute),
            //};
            //result.AllowedPaymentTypes = (result.Valute.Id == "398") ? new[] { (int)PaymentTypes.Cash, (int)PaymentTypes.EPayKKB } : new[] { (int)PaymentTypes.Cash };
            //result.CurrentWarehouseId = SessionHelper.CurrentWarehouseId;
            //result.IsGross = SessionHelper.IsGross;

            //return result;
        }

        [HttpDelete]
        [Route("remove-order")]
        public void RemoveOrder([FromUri] string orderId)
        {
            _orderRepository.DeleteOrder(SessionHelper.CurrentUser, orderId);
        }

        [HttpGet]
        [Route("clone-order")]
        public string CloneOrder(string orderId)
        {
            return _orderRepository.DuplicateOrder(SessionHelper.CurrentUser, orderId);
        }

        //ReferenceRepository.GetDeliveryTypes
    }

    public class DeliveryReferencesResponse
    {
        /// <summary>
        /// Области
        /// </summary>
        public ReferenceItemDto[] Regions { get; set; }
        /// <summary>
        /// Города
        /// </summary>
        public ReferenceItemDto[] Cities { get; set; }
        ///// <summary>
        ///// Районы
        ///// </summary>
        //public ReferenceItemDto[] Areas { get; set; }
    }

    public class ReferenceItemDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isSelected")]
        public bool IsSelected { get; set; }

        [JsonProperty("disabled")]
        public bool IsNotAvailable { get; set; }
    }

    public class ReferenceOfficeItemDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isSelected")]
        public bool IsSelected { get; set; }

        [JsonProperty("disabled")]
        public bool IsNotAvailable { get; set; }

        [JsonProperty("maxWeight")]
        public decimal MaxWeight { get; set; }
    }

    public class DeliveryAddressesDto
    {
        [JsonProperty("allowEdit")]
        public bool AllowEdit { get; set; }

        [JsonProperty("addresses")]
        public List<DeliveryAddressDto> Addresses { get; set; }

        [JsonProperty("maxAddresses")]
        public int MaxAddresses { get; set; }
    }

    public class AddressDto
    {
        [JsonProperty("addressId")]
        public string AddressId { get; set; }

        /// <summary>
        /// Код региона
        /// </summary>
        [JsonProperty("regionId")]
        public string RegionId { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        /// <summary>
        /// Код нас. пункта
        /// </summary>
        [JsonProperty("localityId")]
        public string LocalityId { get; set; }

        /// <summary>
        /// Наименование нас. пункта
        /// </summary>
        [JsonProperty("localityName")]
        public string LocalityName { get; set; }

        /// <summary>
        /// Наименование улицы
        /// </summary>
        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [JsonProperty("flat")]
        public string Flat { get; set; }

        /// <summary>
        /// Подробности проезда
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }

    public class DeliveryAddressBaseDto : AddressDto
    {
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }


    public class DeliveryDateTimeDto
    {
        [JsonProperty("deliveryDateTime")]
        public DateTime DeliveryDateTime { get; set; }
    }

    public class DeliveryAddressDto : DeliveryAddressBaseDto
    {
        [JsonProperty("isDeletePossible")]
        public bool IsDeletePossible { get; set; }

        [JsonProperty("isSelectable")]
        public bool IsSelectable { get; set; }

        [JsonProperty("addressPresenter")]
        public string AddressPresenter { get; set; }
    }
}