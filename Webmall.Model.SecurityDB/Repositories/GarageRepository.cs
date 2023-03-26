using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using log4net;
using log4net.Config;
using Webmall.Model.Database.DataLayer;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Garage;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Database.Repositories
{
    class GarageRepository : IGarageRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        static GarageRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        readonly WebmallDbContext _db = new WebmallDbContext();
        private readonly IMapper _mapper;

        public GarageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        ~GarageRepository()
        {
            try
            {
                _db.Dispose();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public List<Car> GetCars(string clientId)
        {
            return _mapper.Map<List<Car>>(_db.Garages.Where(i=>i.ClientId == clientId));
        }

        public string UpsertCar(Car aCar)
        {
            var id = aCar.Id.ToInt();
            var car = _db.Garages.FirstOrDefault(i => i.Id == id);
            if (car == null)
                _db.Garages.Add(car = _mapper.Map<DbCar>(aCar));
            else
                _mapper.Map(aCar, car);

            _db.SaveChanges();
            return car.Id.ToString();
        }

        public void RemoveCar(string carId)
        {
            var id = carId.ToInt();
            var car = _db.Garages.FirstOrDefault(i => i.Id == id);
            if (car != null)
            {
                _db.Garages.Remove(car);
                _db.SaveChanges();
            }
        }
    }
}
