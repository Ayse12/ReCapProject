using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarId=1, BrandId=1, ColorId=1, ModelYear="1998", DailyPrice=300, Description="Audi A3"  },
                new Car { CarId=2, BrandId=1, ColorId=2, ModelYear="2001", DailyPrice=400, Description="Audi A3"  },
                new Car { CarId=3, BrandId=2, ColorId=3, ModelYear="2006", DailyPrice=150, Description="Renault Megane"  },
                new Car { CarId=4, BrandId=2, ColorId=4, ModelYear="2000", DailyPrice=500, Description="Renault Megane"  },
                new Car { CarId=5, BrandId=3, ColorId=5, ModelYear="2021", DailyPrice=240, Description="Honda Civic"  },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByld()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
