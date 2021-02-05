using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        IProductDal _productDal; //entity framework ya da in memory olmamalı
                                 //generate constructor diyip injection yapılıyor

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // 

        public List<Product> GetAll()
        {
            //iş kodları
            //yetkisi var mı?
            // InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); // bu şekilde yazılırsa sadece inmemory çalışır

            return _productDal.GetAll();

        }
    }
}
