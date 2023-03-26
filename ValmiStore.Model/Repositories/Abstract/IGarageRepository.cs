using System.Collections.Generic;
using Webmall.Model.Entities.Garage;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IGarageRepository
    {
        /// <summary>
        /// Получение списка автопарка клиента
        /// </summary>
        /// <returns></returns>
        List<Car> GetCars(string clientId);

        /// <summary>
        /// Добавление/обновление автомобиля в гараже клиента
        /// </summary>
        /// <returns></returns>
        string UpsertCar(Car aCar);

        /// <summary>
        /// Удаление автомобиля из гаража клиента
        /// </summary>
        /// <returns></returns>
        void RemoveCar(string carId);

    }
}
