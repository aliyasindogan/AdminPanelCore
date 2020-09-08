using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdWebTemplate.Business.Abstarct
{
    public interface IUserRoleService
    {
        List<UserRole> GetList(Expression<Func<UserRole, bool>> filter = null); //tümünü getir

        UserRole GetById(Expression<Func<UserRole, bool>> filter); //ID ye göre getir

        UserRole Add(UserRole entity);

        UserRole Update(UserRole entity);

        void Delete(UserRole entity);

        bool Any(Expression<Func<UserRole, bool>> filter);

        int? Max(Expression<Func<UserRole, bool>> filter, Expression<Func<UserRole, Nullable<int>>> column);
    }
}