using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //:IEntityRepository<Product> eklenince yukarı, bu kodlara gerek kalmadı:
        ////aşağıdaki interface methodları default olarak publictir
        ////product ile ilgili veritabanı operasyonları
        //List<Category> GetAll(); //data access entites kullanacak - add referance
        //void Add(Category category);
        //void Update(Category category);
        //void Delete(Category category);

        //List<Category> GetAllByCategory(int categoryId);
    }
}
