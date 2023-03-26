using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Entities.Garage;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.ViewModel.Garage;

namespace Webmall.UI.Controllers
{
    
    public class GarageController : Controller
    {
        private readonly IGarageRepository _garageRepository;
        private readonly IAutoDataRepository _autoDataRepository;

        public GarageController(IGarageRepository garageRepository, IAutoDataRepository autoDataRepository)
        {
            _garageRepository = garageRepository;
            _autoDataRepository = autoDataRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            var client = SessionHelper.CurrentClient;
            //var clientId = SessionHelper.CurrentClientId;
            var model = new GarageViewModel
            {
                Cars = _garageRepository.GetCars(client.Id),
                Client = client,
                AutoMarks = _autoDataRepository.GetMarksList(UserPreferences.CurrentCulture)
            };

            return View(model);
        }

        public ActionResult Delete(string id)
        {
            _garageRepository.RemoveCar(id);
            SessionHelper.InvalidateGarage();
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveCar(Car car)
        {
            var currentClientId = SessionHelper.CurrentClientId;
            if (currentClientId != null)
            {
                car.ClientId = currentClientId;
                var currentCulture = UserPreferences.CurrentCulture;
                if (!string.IsNullOrEmpty(car.MarkaId))
                    car.Marka = _autoDataRepository.GetMarksList(currentCulture).FirstOrDefault(i => i.Id == car.MarkaId)?.Name;
                if (!string.IsNullOrEmpty(car.ModelId))
                    car.Model = _autoDataRepository.GetModelsList(currentCulture, car.MarkaId).FirstOrDefault(i => i.Id == car.ModelId)?.ShortName;
                if (!string.IsNullOrEmpty(car.ModificationId))
                    car.Modification = _autoDataRepository.GetModifData(currentCulture, car.ModificationId).Name;
                _garageRepository.UpsertCar(car);
            }

            SessionHelper.InvalidateGarage();
            return RedirectToAction("Index");
        }

        public ActionResult Select(string id)
        {
            var car = SessionHelper.Garage.FirstOrDefault(i => i.IsSelected);
            if (car != null)
            {
                car.IsSelected = false;
                _garageRepository.UpsertCar(car);
            }

            car = SessionHelper.Garage.FirstOrDefault(i => i.Id == id);
            if (car != null)
            {
                car.IsSelected = true;
                _garageRepository.UpsertCar(car);
            }

            SessionHelper.InvalidateGarage();
            return null;
        }
    }
}
