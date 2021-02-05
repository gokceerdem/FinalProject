using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        /*
         
        //aşağıdaki interface methodları default olarak publictir
        //product ile ilgili veritabanı operasyonları
        List<Product> GetAll(); //data access entites kullanacak - add referance
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);
        */
    }
}
