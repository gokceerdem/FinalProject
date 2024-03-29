﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

        // ilk hali begin
        //public class EfProductDal : IProductDal
        //    {
        //        //Ef meaning entity framework


        //        public void Add(Product entity)
        //        {
        //            //IDisposable pattern implementation of c#
        //            //this is garbage collector, iş bitince belleği boşaltır:
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                var addedEntity = context.Entry(entity);
        //                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //                context.SaveChanges();
        //            }
        //        }

        //        public void Delete(Product entity)
        //        {
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                var deletedEntity = context.Entry(entity);
        //                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //                context.SaveChanges();
        //            }
        //        }

        //        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //        {
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                //veritabanındaki nesneyi listeye çevir
        //                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();

        //            }
        //        }

        //        public Product GetT(Expression<Func<Product, bool>> filter)
        //        {
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                return context.Set<Product>().SingleOrDefault(filter);
        //            }
        //        }

        //        public void Update(Product entity)
        //        {
        //            using (NorthwindContext context = new NorthwindContext())
        //            {
        //                var updatedEntity = context.Entry(entity);
        //                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //                context.SaveChanges();
        //            }
        //        }
        //    }
        //}
        //ilk hali end
        public List<ProductDetailDto> GetProductDetails()
        {
            /* using(NorthwindContext context = new NorthwindContext())
             {
                 var result = from p in context.Products
                              join c in context.Categories
                              on p.CategoryId equals c.CategoryId
                              select new ProductDetailDto
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  CategoryName = c.CategoryName,
                                  UnitsInStock = p.UnitsInStock
                              };
                 return result.ToList();
             }*/

            using (NorthwindContext context = new NorthwindContext())
            {
                var result2 = context.Products.FirstOrDefault();

                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }

}
    
