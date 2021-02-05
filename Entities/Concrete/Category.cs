using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    //çıplak class kalmasın
    //eğer bir class herhangi bir inheritance veya interface implementasyon almazsa
    //ileride problem yaratma olasılığı çok yüksek
    //entites kısmındaki classlar veritabanında tablolara karşılık geliyor
    public class Category : IEntity //category bir veritabanı tablosudur anlamına gelir
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
