using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {

    }
}
