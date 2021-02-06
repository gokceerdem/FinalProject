﻿using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetById(int categoryId);
    }
}
