using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Abstarct
{
    public interface ISliderService
    {
        List<Slider> GetList(Expression<Func<Slider, bool>> filter = null); //tümünü getir
        Slider Get(Expression<Func<Slider, bool>> filter); //ID ye göre getir
        Slider Add(Slider entity);
        Slider Update(Slider entity);
        void Delete(Slider entity);

        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Slider, TResult>> select);
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, TResult>> select);
        bool Delete(Expression<Func<Slider, bool>> filter);
        decimal Min(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, decimal>> column);
        int? Max(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, Nullable<int>>> column);
        int? Min(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, Nullable<int>>> column);
        decimal Sum(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, decimal>> column);
        int Count(Expression<Func<Slider, bool>> filter);
        bool Any(Expression<Func<Slider, bool>> filter);

    }
}
