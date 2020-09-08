using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Abstarct
{
    public interface ICategoryTypeService
    {
        List<CategoryType> GetList(Expression<Func<CategoryType, bool>> filter = null); //tümünü getir

        CategoryType Get(Expression<Func<CategoryType, bool>> filter); //ID ye göre getir

        CategoryType Add(CategoryType entity);

        CategoryType Update(CategoryType entity);

        void Delete(Category entity);
    }
}