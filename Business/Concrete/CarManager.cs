using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        /*public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _ICarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba adı 2 harften uzun değil ya da günlük fiyat 0'dan küçük)");
            }
        }*/

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _ICarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public void Delete(Car car)
        {
            _ICarDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş Kodu
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_ICarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetByID(int carId)
        {
            return new SuccessDataResult<Car>(_ICarDal.Get(c=>c.CarId==carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_ICarDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ICarDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ICarDal.GetAll(p => p.ColorId == id));
        }

        public void Update(Car car)
        {
            _ICarDal.Update(car);
        }
    }
}
