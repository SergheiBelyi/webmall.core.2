using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Laximo.Guayaquil.Data.Entities;
using Laximo.Guayaquil.Data.Interfaces;
using Laximo.Guayaquil.Data.net.laximo.ws;

namespace Laximo.Guayaquil.Data
{
    public class Command
    {
        private readonly string _commandName;
        private IDictionary<string, string> _params = new Dictionary<string, string>();

        public Command(string commandName)
        {
            _commandName = commandName;
        }

        public Command AddParam(string name, string value)
        {
            _params.Add(name, value);

            return this;
        }

        public Command AddParams(IDictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                _params.Add(pair);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_commandName);
            sb.Append(':');

            bool first = true;

            foreach (KeyValuePair<string, string> pair in _params)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append('|');
                }

                sb.Append(pair.Key);
                sb.Append('=');
                sb.Append(pair.Value);
            }

            return sb.ToString();
        }
    }

    public class CatalogProvider : LaximoWSProviderBase
    {

        public CatalogProvider(string certPath, string certPwd, string authMode, string login, string password, ICatalogCache cache) : base(certPath, certPwd, authMode, login, password, cache)
        {
        }

        public CatalogProvider(string certPath, string certPwd, string authMode, string login, string password, ICatalogCache cache, string locale) : base(certPath, certPwd, authMode, login, password,cache, locale)
        {
        }

        protected override ILaximoProxy CreateProxy()
        {
            return new Catalog();
        }

        #region request

        IList<Command> _commands = new List<Command>();

        public void AddCommand(Command command)
        {
            if (!_commands.Contains(command))
            {
               _commands.Add(command);
            }
        }

        public response Execute()
        {
            if (_commands.Count > 5)
            {
                throw new Exception("Maximum supports 5 command per request");
            }

            StringBuilder sb = new StringBuilder();

            foreach (Command command in _commands)
            {

                if (sb.Length > 0)
                {
                    sb.Append("\n");
                }

                sb.Append(command);
            }

            _commands = new List<Command>();

            return GetData(sb.ToString());
        }

        public void Clear()
        {
            _commands = new List<Command>();
        }

        #endregion

        #region commands

        public ListCatalogs CatalogsList(string locale = null)
        {
            return GetData(GetQueryListCatalogs(locale)).ListCatalogs[0];
        }

        public GetCatalogInfo GetCatalogInfo(string catalogCode, string locale = null)
        {
            return GetData(GetQueryGetCatalogInfo(catalogCode, locale)).GetCatalogInfo[0];
        }

        public FindVehicleByVIN FindVehicleByVIN(string vin, string catalogCode = null, string locale = null)
        {
            return GetData(GetQueryFindVehicleByVin(vin, catalogCode, locale)).FindVehicleByVin[0];
        }

        public FindVehicleByFrame FindVehicleByFrame(string frame, string frameNo, string catalogCode = null, string locale = null)
        {
            return GetData(GetQueryFindVehicleByFrame(frame, frameNo, catalogCode, locale)).FindVehicleByFrame[0];
        }

        public FindVehicleByWizard2 FindVehicleByWizard2(string catalogCode, string ssd, string locale = null)
        {
            return GetData(GetQueryFindVehicleByWizard2(catalogCode, ssd, locale)).FindVehicleByWizard2[0];
        }

        public ExecCustomOperation ExecCustomOperation(string catalogCode, string operationName, IDictionary<string, string> parameters, string locale = null)
        {
            return GetData(GetQueryExecCustomOperation(catalogCode, operationName, parameters, locale)).ExecCustomOperation[0];
        }

        public GetVehicleInfo GetVehicleInfo(string catalogCode, string vehicleId, string ssd, string locale = null)
        {
            return GetData(GetQueryGetVehicleInfo(catalogCode, vehicleId, ssd, locale)).GetVehicleInfo[0];
        }

        public ListCategories GetCategoriesList(string catalogCode, string vehicleId, string categoryId, string ssd, string locale  = null)
        {
            return GetData(GetQueryListCategories(catalogCode, vehicleId, categoryId, ssd, locale)).ListCategories[0];
        }

        public ListUnits GetUnitsList(string catalogCode, string vehicleId, string categoryId, string ssd, string locale = null)
        {
            return GetData(GetQueryListUnits(catalogCode, vehicleId, categoryId, ssd, locale)).ListUnits[0];
        }

        public GetUnitInfo GetUnitInfo(string catalogCode, string unitId, string ssd, string locale = null)
        {
            return GetData(GetQueryGetUnitInfo(catalogCode, unitId, ssd, locale)).GetUnitInfo[0];
        }

        public ListImageMapByUnit GetListImageMapByUnit(string catalogCode, string unitId, string ssd, string locale = null)
        {
            return GetData(GetQueryListImageMapByUnit(catalogCode, unitId, ssd, locale)).ListImageMapByUnit[0];
        }

        public ListDetailsByUnit GetListDetailByUnit(string catalogCode, string unitId, string ssd, string locale = null)
        {
            return GetData(GetQueryListDetailByUnit(catalogCode, unitId, ssd, locale)).ListDetailsByUnit[0];
        }

        public GetWizard2 GetWizard2(string catalogCode, string ssd, string locale = null)
        {
            return GetData(GetQueryGetWizard2(catalogCode, ssd, locale)).GetWizard2[0];
        }

        public GetFilterByUnit GetFilterByUnit(string catalogCode, string vehicleId, string unitId, string filter, string ssd, string locale = null)
        {
            return GetData(GetQueryGetFilterByUnit(catalogCode, filter, vehicleId, unitId, ssd, locale)).GetFilterByUnit[0];
        }

        public GetFilterByDetail GetFilterByDetail(string catalogCode, string unitId, string filter, string detailId, string ssd, string locale = null)
        {
            return GetData(GetQueryGetFilterByDetail(catalogCode, filter, unitId, detailId, ssd, locale)).GetFilterByDetail[0];
        }

        public ListQuickGroups GetListQuickGroup(string catalogCode, string vehicleId, string ssd, string locale = null)
        {
            return GetData(GetQueryListQuickGroup(catalogCode, vehicleId, ssd, locale)).ListQuickGroups[0];
        }

        public ListQuickDetail GetListQuickDetail(string catalogCode, string vehicleId, string groupId, string ssd, bool all, string locale = null)
        {
            return GetData(GetQueryListQuickDetail(catalogCode, vehicleId, groupId, ssd, all, locale)).ListQuickDetail[0];
        }

        #endregion

        #region query

        public Command GetQueryListCatalogs(string locale = null)
        {
            return new Command("ListCatalogs")
                .AddParam("Locale", GetLocale(locale));
        }

        public Command GetQueryGetCatalogInfo(string catalog, string locale = null)
        {
            return new Command("GetCatalogInfo")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale));
        }

        public Command GetQueryFindVehicleByVin(string vin, string catalog = null, string locale = null)
        {
            Command command = new Command("FindVehicleByVIN")
                .AddParam("VIN", GetLocale(vin))
                .AddParam("Localized", "true")
                .AddParam("Locale", GetLocale(locale));

            if (!string.IsNullOrEmpty(catalog))
            {
                command.AddParam("Catalog", catalog);
            }

            return command;
        }

        public Command GetQueryFindVehicleByFrame(string frame, string frameNo, string catalog = null, string locale = null)
        {
            Command command = new Command("FindVehicleByFrame")
                .AddParam("Localized", "true")
                .AddParam("Frame", frame)
                .AddParam("FrameNo", frameNo)
                .AddParam("ssd", "")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale));

            return command;
        }

        public Command GetQueryFindVehicleByWizard2(string catalog, string ssd, string locale = null)
        {
            return new Command("FindVehicleByWizard2")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd);
        }

        public Command GetQueryExecCustomOperation(string catalog, string operationName, IDictionary<string, string> parameters, string locale = null)
        {
            return new Command("ExecCustomOperation")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("operation", operationName)
                .AddParams(parameters);
        }

        public Command GetQueryGetVehicleInfo(string catalog, string vehicleId, string ssd, string locale = null)
        {
            return new Command("GetVehicleInfo")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("Localized", "true")
                .AddParam("VehicleId", vehicleId);
        }

        public Command GetQueryListCategories(string catalog, string vehicleId, string categoryId, string ssd, string locale = null)
        {
            return new Command("ListCategories")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("CategoryId", categoryId)
                .AddParam("ssd", ssd)
                .AddParam("VehicleId", vehicleId);
        }

        public Command GetQueryListUnits(string catalog, string vehicleId, string categoryId, string ssd, string locale = null)
        {
            return new Command("ListUnits")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("CategoryId", categoryId)
                .AddParam("ssd", ssd)
                .AddParam("VehicleId", vehicleId);
        }

        public Command GetQueryGetUnitInfo(string catalog, string unitId, string ssd, string locale = null)
        {
            return new Command("GetUnitInfo")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("UnitId", unitId);
        }

        public Command GetQueryListImageMapByUnit(string catalog, string unitId, string ssd, string locale = null)
        {
            return new Command("ListImageMapByUnit")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("UnitId", unitId);
        }

        public Command GetQueryListDetailByUnit(string catalog, string unitId, string ssd, string locale = null)
        {
            return new Command("ListDetailByUnit")
                .AddParam("Catalog", catalog)
                .AddParam("Localized", "true")
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("UnitId", unitId);
        }

        public Command GetQueryGetWizard2(string catalog, string ssd, string locale = null)
        {
            return new Command("GetWizard2")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd);
        }

        public Command GetQueryGetFilterByUnit(string catalog, string filter, string vehicleId, string unitId, string ssd, string locale = null)
        {
            return new Command("GetFilterByUnit")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("Filter", filter)
                .AddParam("ssd", ssd)
                .AddParam("VehicleId", vehicleId)
                .AddParam("UnitId", unitId);
        }

        public Command GetQueryGetFilterByDetail(string catalog, string filter, string unitId, string ssd, string locale = "", string detailId = "")
        {
            return new Command("GetFilterByDetail")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("Filter", filter)
                .AddParam("ssd", ssd)
                .AddParam("DetailId", detailId)
                .AddParam("UnitId", unitId);
        }

        public Command GetQueryListQuickGroup(string catalog, string vehicleId, string ssd, string locale = null)
        {
            return new Command("ListQuickGroup")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("VehicleId", vehicleId);
        }

        public Command GetQueryListQuickDetail(string catalog, string vehicleId, string groupId, string ssd, bool all, string locale = null)
        {
            Command command = new Command("ListQuickDetail")
                .AddParam("Catalog", catalog)
                .AddParam("Locale", GetLocale(locale))
                .AddParam("ssd", ssd)
                .AddParam("Localized", "true")
                .AddParam("VehicleId", vehicleId)
                .AddParam("QuickGroupId", groupId);

            if (all)
            {
                command.AddParam("All", "1");
            }

            return command;
        }

        #endregion
    }

}
