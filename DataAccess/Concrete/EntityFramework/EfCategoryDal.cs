﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        /*
         * ilk hal begin
        public class EfCategoryDal : ICategoryDal
        {
            public void Add(Category entity)
            {
                throw new NotImplementedException();
            }

            public void Delete(Category entity)
            {
                throw new NotImplementedException();
            }

            public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
            {
                throw new NotImplementedException();
            }

            public Category GetT(Expression<Func<Category, bool>> filter)
            {
                throw new NotImplementedException();
            }

            public void Update(Category entity)
            {
                throw new NotImplementedException();
            }
        }
        * ilk hal end
        */
    }
}
