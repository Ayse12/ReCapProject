using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetByID(int carId);
       
        void Update(Car car);
        void Delete(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IResult Add(Car car);
    }
}
