using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Abstarct
{
    public interface ICategoryService
    {
        List<CategoryDetail> GetCategoryDetails(int RolID);

        CategoryDetail GetByIdCategoryDetails(int? id);

        List<Category> GetList(Expression<Func<Category, bool>> filter = null); //tümünü getir

        Category Get(Expression<Func<Category, bool>> filter); //ID ye göre getir

        Category Add(Category entity);

        Category Update(Category entity);

        void Delete(Category entity);

        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Category, TResult>> select);

        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TResult>> select);

        bool Delete(Expression<Func<Category, bool>> filter);

        //decimal Max(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column);
        decimal Min(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column);

        int? Max(Expression<Func<Category, bool>> filter, Expression<Func<Category, Nullable<int>>> column);

        int? Min(Expression<Func<Category, bool>> filter, Expression<Func<Category, Nullable<int>>> column);

        decimal Sum(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column);

        int Count(Expression<Func<Category, bool>> filter);

        bool Any(Expression<Func<Category, bool>> filter);
    }
}