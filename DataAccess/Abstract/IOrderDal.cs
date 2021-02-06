using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        //veritabanı nesnesi(tablo) entities altına eklenir
        //bu nesnenin interface'i olmalı. sql cümlelerini taşır bu interface
    }
}
