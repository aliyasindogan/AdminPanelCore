using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{
    public class SliderManager : ISliderService
    {
        private ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public Slider Add(Slider entity)
        {
            return _sliderDal.Add(entity);
        }

        public bool Any(Expression<Func<Slider, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Slider, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public bool Delete(Expression<Func<Slider, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Slider Get(Expression<Func<Slider, bool>> filter)
        {
            return _sliderDal.Get(filter);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Slider, TResult>> select)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, TResult>> select)
        {
            throw new NotImplementedException();
        }

        public List<Slider> GetList(Expression<Func<Slider, bool>> filter = null)
        {
            return _sliderDal.GetList(filter);
        }

        public int? Max(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, int?>> column)
        {
            return _sliderDal.Max(filter, column);
        }

        public decimal Min(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, decimal>> column)
        {
            throw new NotImplementedException();
        }

        public int? Min(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, int?>> column)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(Expression<Func<Slider, bool>> filter, Expression<Func<Slider, decimal>> column)
        {
            throw new NotImplementedException();
        }

        public Slider Update(Slider entity)
        {
            return _sliderDal.Update(entity);

        }
    }
}
