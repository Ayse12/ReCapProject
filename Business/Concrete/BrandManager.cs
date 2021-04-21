using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public List<Brand> GetAll()
        {
            //İş kodları
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
           // return _brandDal.GetAll(b => b.BrandId == brandId);
        }
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2 )
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Araba markası 2 harften uzun değil");
            }
        }
    }
}
