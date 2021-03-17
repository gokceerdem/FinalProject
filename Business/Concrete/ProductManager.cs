using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

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

        public IResult Add(Product product)
        {//bussiness rules will be here
            //ürünleri ekleme şartları
            if (product.ProductName.Length<2)
            {
                //return new ErrorResult("ürün ismi en az 2 karakter olmalı"); //magic strings antipattern hatayı bu şekilde yazdırmak
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            //return new Result(true,"Ürün eklendi"); //bu şekilde olması için constructor eklemek gerek
            //veya aşağıdakiler kullanılabilir:
            /*
             * return new SuccessResult();//mesaj döndürmez fakat sonuç success
             * return new SuccessResult("Ürün eklendi");//mesaj döndürür
             */


            //constant messages eklenince:
            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //yetkisi var mı?

            if(DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
                // postman çıktısı:
                //{
                //"data": null,
                //"success": false,
                //"message": "Şu anda işleminizi gerçekleştiremiyoruz"
                // }
            
            


        }

            // InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); // bu şekilde yazılırsa sadece inmemory çalışır
            /*fonksiyon ismi public List<Product> GetAll() iken,
             *return _productDal.GetAll();
             *
             */

            //return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductAdded);
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(), Messages.ProductsListed);
        }

public IDataResult<List<Product>> GetAllByCategoryId(int Id)
{
    return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
}


public IDataResult<Product> GetById(int productId)
{
    //return _productDal.Get(p => p.ProductId == productId);
    return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
}

public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)//List<Product> GetByUnitPrice(decimal min, decimal max)
{
   //return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
  return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
}

public IDataResult<List<ProductDetailDto>>GetProductDetails()
{
return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
}
}
}
