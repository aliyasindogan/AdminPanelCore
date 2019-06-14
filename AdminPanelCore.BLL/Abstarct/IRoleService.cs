using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Abstarct
{
    public interface IRoleService
    {
        List<Role> GetList(Expression<Func<Role, bool>> filter = null); //tümünü getir
        Role Get(Expression<Func<Role, bool>> filter); //ID ye göre getir
        Role Add(Role entity);
        Role Update(Role entity);
        void Delete(Role entity);
 
    }
}
