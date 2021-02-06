using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;


namespace Core.DataAccess
{
    //add generic constraint for T
    //class:referans tip olabilir anlmına geliyor. int,decimal,string vs olamaz
    //class,IEntity yazınca referans tip olacak ve (IEntity olabilir veya IEntity implemente eden bir nesne olabilir)
    //new() : New'lenebilir olmalı demek
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //filter = null --> filtreleme olmayabilir
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtreleme, kriterlere göre sorgu getirme
        //system refactoring:
        T GetT(Expression<Func<T, bool>> filter); // filtreleme zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId);// buna gerek kalmadı,List<T> GetAll kullanılacak 
    }
}
