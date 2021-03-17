using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory //in memory sanki veritabanından geliyor gibi simüle etmek
{
    public class InMemoryProductDal : IProductDal //bellekte çalışacağız //entity framework gerçek veritabanında çalışma
    {
        List<Product> _products; //class içinde bütün methodlar dışında tanımlanınca global veridir
                                 //ctor tab tab consturctor oluşturur
                                 //alt çizgi ile isimlendirince global olduğunu belirtir
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId = 1, ProductName="bardak" , UnitPrice = 15, UnitsInStock =15},
                new Product{ProductId=2, CategoryId = 1, ProductName="çatal" , UnitPrice = 500, UnitsInStock =3 },
                new Product{ProductId=3, CategoryId = 2, ProductName="tel" , UnitPrice = 1500, UnitsInStock =2},
                new Product{ProductId=4, CategoryId = 2, ProductName="klavye" , UnitPrice = 150, UnitsInStock =65},
                new Product{ProductId=5, CategoryId = 2, ProductName="fare" , UnitPrice = 85, UnitsInStock =15},
            };
        }



        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // _products.Remove(product); //sadece bu çalışmaz
            //referans tip ürünler bu şekilde silinemez
            //product ismi verilse bile id aynı bile olsa ürünler listesinden heap'teki bir veriyi silmeye çalışır ve bulamaz
            //silme işlemi için link kullanılmalı

            //*** versiyon1 başla
            //verilen id ile referans numarasını bulmamız gerekir

            /*
            Product productToDelete = null;//=new Product(); --> yazmak yanlış

            foreach (var p in _products) {
                if(product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }
            _products.Remove(productToDelete);
            */
            //** versiyon1 bitir


            //LINQ - language integrated query versiyon 2:
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //SingleOrDefault tek tek dolaşmaya yarar
            //first
            //firstordefault da kullanılabilir
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            Console.WriteLine('1');
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
