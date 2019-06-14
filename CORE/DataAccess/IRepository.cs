using AdminPanelCore.CORE.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.CORE.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// List dönüş türü olan ve koşullu ve koşulsuz filtre yapılabilen listeleme
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// Entity tipinde dönüş tipi olan ve filtre verilmesi zorunlu ve tek sorgu getiren liste (GetById gibi..)
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Kayıt Ekleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// Güncelleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);
        /// <summary>
        ///Silme İşleme
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select);
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> select);
        bool Delete(Expression<Func<T, bool>> filter);
        decimal Max(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> column);
        decimal Min(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> column);
        int? Max(Expression<Func<T, bool>> filter, Expression<Func<T, Nullable<int>>> column);
        int? Min(Expression<Func<T, bool>> filter, Expression<Func<T, Nullable<int>>> column);
        decimal Sum(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> column);
        int Count(Expression<Func<T, bool>> filter);
        bool Any(Expression<Func<T, bool>> filter);
    }
}