using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICarDal;

        public CarManager(ICarDal IcarDal)
        {
            _ICarDal = IcarDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _ICarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba adı 2 harften uzun değil ya da günlük fiyat 0'dan küçük)");
            }
        }

        public void Delete(Car car)
        {
            _ICarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //İş Kodu
            return _ICarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _ICarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _ICarDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _ICarDal.Delete(car);
        }
    }
}
