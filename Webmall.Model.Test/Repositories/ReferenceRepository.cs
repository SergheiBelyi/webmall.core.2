using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.References;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        public void ClearValuteCache(User user, string culture)
        {
            //throw new NotImplementedException();
        }

        public List<SelectListItem> GetAvailableRetailOrganizations(string culture, string country)
        {
            var list = new List<SelectListItem> {
                new SelectListItem { Text = "test name 1", Value = "1" },
                new SelectListItem { Text = "test name 2", Value = "2" }};

            return list;
        }

        public List<SelectListItem> GetDeliveryTypes(string clientId, string culture)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetDocumentTypes(string culture)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetFuelTypes(string culture)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetPaymentForms(string culture)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetPaymentStatuses(string culture)
        {
            throw new NotImplementedException();
        }


        public List<Valute> GetValutes(User user, string culture)
        {
            return new List<Valute>
            {
                new Valute {Id = "1", Name = "EUR", Rate = 1, Code = "EUR"}
            };
        }

        public List<Warehouse> GetWarehouses(string clientId, string culture)
        {
            var list = new List<Warehouse> {
                new Warehouse { Value = "test name 1", Id = "1", Address = "Address line 1", IsSelected = true},
                new Warehouse { Value = "test name 2", Id = "2", Address = "Address line 1" }};

            return list;
        }
    }
}
