using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using log4net;
using log4net.Config;
using PriceAggregator.Domain.Common;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.PriceAggregator.Core;
using Webmall.Model.PriceAggregator.DataModels;
using Webmall.Model.PriceAggregator.DataModels.AutoData;
using Webmall.Model.Repositories.Abstract;
using AutoMarka = Webmall.Model.Entities.Auto.AutoMarka;
using AutoModel = Webmall.Model.Entities.Auto.AutoModel;
using WareListItem = Webmall.Model.Entities.Catalog.WareListItem;


namespace Webmall.Model.PriceAggregator.Repositories
{
    public class AutoDataRepository : IAutoDataRepository
    {
        private static readonly HttpClient Client;
        private readonly IMapper _mapper;

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(AutoDataRepository));

        static AutoDataRepository()
        {
            Client = HttpHelper.InitPriceAggregatorClient();
            XmlConfigurator.Configure();
        }
        #endregion

        public AutoDataRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly List<AutoMarka> EmptyMarkList = new List<AutoMarka>();
        private static readonly object GetMarksListLock = new object();
        public List<AutoMarka> GetMarksList(string localeId)
        {
            var key = MethodBase.GetCurrentMethod()?.Name;
            var list = HttpRuntime.Cache.Get(key, GetMarksListLock, () =>
            {
                var result = EmptyMarkList;
                try
                {
                    var requestModel = Client.GetRequest<List<DataModels.AutoData.AutoMarka>>(Core.ConfigHelper.AutoMarks);
                    result = _mapper.Map<List<AutoMarka>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetMarksList error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetModelsListLock = new object();
        private static readonly List<AutoModel> EmptyModelList = new List<AutoModel>();
        public List<AutoModel> GetModelsList(string localeId, string markaId)
        {
            if (string.IsNullOrEmpty(markaId))
                return EmptyModelList;
            var key = MethodBase.GetCurrentMethod()?.Name + markaId;
            var list = HttpRuntime.Cache.Get(key, GetModelsListLock, () =>
            {
                var result = EmptyModelList;
                try
                {
                    var requestModel = Client.GetRequest<List<DataModels.AutoData.AutoModel>>(Core.ConfigHelper.AutoModels, new[,] { { "markaId", markaId } });
                    result = _mapper.Map<List<AutoModel>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetModelsList error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetModifsListLock = new object();
        private static readonly List<AutoModification> EmptyModifList = new List<AutoModification>();
        public List<AutoModification> GetModifList(string localeId, string modelId, 
            int? yearOfProduce = null, int? volume = null, int? volumePercent = null, int? fuelType = null, 
            int? power = null, int? powerUnits = null, int? powerPercent = null)
        {
            if (string.IsNullOrEmpty(modelId))
                return EmptyModifList;
            var key = MethodBase.GetCurrentMethod()?.Name + $"|{modelId}|{fuelType}|{yearOfProduce}|{volume}|{volumePercent}|{power}|{powerUnits}|{powerPercent}";
            var list = HttpRuntime.Cache.Get(key, GetModifsListLock, () =>
            {
                var result = EmptyModifList;
                try
                {
                    var requestModel = Client.GetRequest<List<AutoModificationData>>(Core.ConfigHelper.AutoModifications, 
                        new[,] { 
                            { "modelId", modelId }, 
                            { "year", yearOfProduce.ToString() },
                            { "Volume", volume.ToString() },
                            { "VolumePercent", volumePercent.ToString() },
                            { "FuelType", fuelType.ToString() },
                            { "Power", power.ToString() },
                            { "PowerUnit", powerUnits.ToString() },
                            { "PowerPercent", powerPercent.ToString() }
                        });
                    result = _mapper.Map<List<AutoModification>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetModifList error", e);
                }
                return result;

            });
            return list;
        }

        public AutoModification GetModifData(string localeId, string modifId)
        {
            if (string.IsNullOrEmpty(modifId))
                return null;
            var key = MethodBase.GetCurrentMethod()?.Name + modifId;
            var list = HttpRuntime.Cache.Get(key, GetModifsListLock, () =>
            {
                AutoModification result = null;
                try
                {
                    var requestModel = Client.GetRequest<AutoModificationFull>(Core.ConfigHelper.AutoModification, new[,] { { "modifId", modifId } });
                    result = _mapper.Map<AutoModification>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetModifData error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetTecDocAssembliesTreeLock = new object();
        private static readonly List<Group> EmptyAssembliesList = new List<Group>();
        public List<Group> GetTecDocAssembliesTree(string localeId, string modifId)
        {
            if (string.IsNullOrEmpty(modifId))
                return EmptyAssembliesList;
            var key = MethodBase.GetCurrentMethod()?.Name + modifId;
            var list = HttpRuntime.Cache.Get(key, GetTecDocAssembliesTreeLock, () =>
            {
                var result = EmptyAssembliesList;
                try
                {
                    var requestModel = Client.GetRequest<AssemblyTree>(Core.ConfigHelper.AutoAssemblies, new[,] { { "modifId", modifId } });
                    result = _mapper.Map<List<Group>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetTecDocAssembliesTree error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetTecDocAssemblyWaresLock = new object();
        private static readonly List<WareListItem> EmptyAssembliesWaresList = new List<WareListItem>();
        public List<WareListItem> GetTecDocAssemblyWares(string localeId, string modifId, string assemlyId)
        {
            if (string.IsNullOrEmpty(modifId))
                return EmptyAssembliesWaresList;
            var key = MethodBase.GetCurrentMethod()?.Name + $"M{modifId}A{assemlyId}";
            var list = HttpRuntime.Cache.Get(key, GetTecDocAssemblyWaresLock, () =>
            {
                var result = EmptyAssembliesWaresList;
                try
                {
                    var requestModel = Client.GetRequest<WareListModel>(Core.ConfigHelper.AutoAssemblyArticles, 
                        new[,] { { "modifId", modifId }, { "assemblyId", assemlyId } });
                    result = _mapper.Map<List<WareListItem>>(requestModel.Wares);
                }
                catch (Exception e)
                {
                    Log.Error("GetTecDocAssembliesTree error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetRefLock = new object();
        public List<SelectListItem> GetFuelTypes(string culture, string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
                return null;
            var key = MethodBase.GetCurrentMethod()?.Name + modelId;
            var list = HttpRuntime.Cache.Get(key, GetRefLock, () =>
            {
                List<SelectListItem> result = null;
                try
                {
                    var requestModel = Client.GetRequest<List<BaseReference<int, string>>>(Core.ConfigHelper.FuelTypes, new[,] { { "modelId", modelId } });
                    result = _mapper.Map<List<SelectListItem>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetFuelTypes error", e);
                }
                return result;

            });
            return list;
        }
    }
}
