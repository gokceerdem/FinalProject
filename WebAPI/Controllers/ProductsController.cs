using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled

        //IoC container --inversion of control
        IProductService _productService; //naming convention: private objeler için bu şekilde isimlendirilir

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// 
        /// controller : sisteme yapılabileck olan istekler yazılır
        /// sistemi kullanacak olan clientlar hangi operasyonlar için ve nasıl istekte bulunabilir?
        /// bir web uygulaması mvc ile yazılmışsa enter'a basıp web sitesine gidince ne yapılacağına controller karar verir
        ///
        /*
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product{ProductId= 1, ProductName = "Elma"},
                new Product{ProductId= 2, ProductName = "Armut"}
            };
        }
        
        [HttpGet]
        public List<Product> Get()
        {
            IProductService productService = new ProductManager(new EfProductDal());
            var result = productService.GetAll();

            return result.Data;

        }
        */
        //dependency chain

        //gelebilecek taleplere göre kodlama yapılır
        //ya da ne çıkacağını bilmeden SOLID prensiplerine uygun geliştirme yapılır.
        [HttpGet]
        /*public List<Product> Get()
        { 
            var result = _productService.GetAll();
            return result.Data;
        }
        */

        //farklı http statü kodu döndürme olanağı kodun yeni hali:
        public IActionResult Get()
        {//swagger dökümantasyon
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200 kod başarılı döndüğü yer
                                  //postman -->     "success": true,
                                  //                "message": "Ürünler listelendi"
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Product product) //client, angular, react'ten gönderilen ürün buraya koyulur
        {
            //post request'te gönderi verilir, bir bilgi yollanır
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
