using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Garage;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class GarageRepository : IGarageRepository
    {

        #region Data

        private static readonly List<Car> Cars = new List<Car> {
            new Car
            {
                Id = "1",
                Marka = "FIAT 501 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2002,
                Modification = "1.20"
            },
            new Car
            {
                Id = "2",
                Marka = "FIAT 502 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2004,
                Modification = "2.20"
            },
            new Car
            {
                Id = "3",
                Marka = "FIAT 503 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2005,
                Modification = "4.50"
            },
            new Car
            {
                Id = "4",
                Marka = "FIAT 504 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2002,
                Modification = "1.20"
            },
            new Car
            {
                Id = "5",
                Marka = "FIAT 505 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2004,
                Modification = "2.20"
            },
            new Car
            {
                Id = "6",
                Marka = "FIAT 506 УНИВЕРСАЛ",
                Vin = "VF1RFC006576699",
                Year = 2005,
                Modification = "4.50"
            }
        };

        #endregion Data

        public List<Car> GetCars(string clientId)
        {
            return Cars.Where(i=>i.ClientId == clientId).ToList();
        }

        public string UpsertCar(Car aCar)
        {
            RemoveCar(aCar.Id);

            Cars.Add(aCar);
            return aCar.Id;
        }

        public void RemoveCar(string carId)
        {
            var car = Cars.FirstOrDefault(i => i.Id == carId);
            if (car != null)
                Cars.Remove(car);
        }
    }
}
