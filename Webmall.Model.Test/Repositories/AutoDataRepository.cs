using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class AutoDataRepository : IAutoDataRepository
    {
        private readonly AutoTestData _testData;

        public AutoDataRepository()
        {
            _testData = new AutoTestData();
        }

        public List<AutoMarka> GetMarksList(string localeId)
        {
            return _testData.Marks;
        }

        public List<AutoModel> GetModelsList(string localeId, string markaId)
        {
            return _testData.Models.Where(i => i.MarkaId == markaId).ToList();
        }

        public AutoModification GetModifData(string localeId, string modifId)
        {
            return _testData.Modifications.FirstOrDefault(i => i.Id == modifId);
        }

        public List<Group> GetTecDocAssembliesTree(string localeId, string modifId)
        {
            throw new NotImplementedException();
        }

        public List<WareListItem> GetTecDocAssemblyWares(string localeId, string modifId, string assemlyId)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetFuelTypes(string culture, string modelId)
        {
            throw new NotImplementedException();
        }

        public List<AutoModification> GetModifList(string culture, string modelId, int? yearOfProduce = null, int? volume = null,
            int? volumePercent = null, int? fuelType = null, int? power = null, int? powerUnits = null,
            int? powerPercent = null)
        {
            return _testData.Modifications.Where(i => i.Model.Id == modelId).ToList();
        }
    }
}
