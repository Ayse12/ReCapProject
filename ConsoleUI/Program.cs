using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemory();
            //EfGetCars();
            //CarManager carManager = AddNewCar();
            //BrandTest();
            //CarDetailsTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("-----------------------M A R K A---------------------------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static CarManager AddNewCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, ColorId = 4, ModelYear = "2016", DailyPrice = 0, Description = " Volkswagen, rengi kırmızı" });
            return carManager;
        }

        private static void EfGetCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(4))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void InMemory()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
