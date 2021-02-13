using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        //List<Product> GetAll();//bunun yerine aşağıdaki gibi bir şey yazmak istiyorum:      
                               // hem data hem result döndüren method:
        IDataResult<List<Product>> GetAll();

        //List<Product> GetAllByCategoryId(int Id);
        IDataResult<List<Product>> GetAllByCategoryId(int Id);

        //List<Product> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        //List<ProductDetailDto> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product);// ilk böyle yazdık:void Add(Product product); değiştirdik sonra void Add(Product product);

        //Product GetById(int productId);
        IDataResult<Product> GetById(int productId);
    }
}
