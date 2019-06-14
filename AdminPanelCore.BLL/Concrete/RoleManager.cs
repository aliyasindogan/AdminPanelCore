using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{

    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role Add(Role entity)
        {
            return _roleDal.Add(entity);
        }

        public void Delete(Role entity)
        {
            _roleDal.Delete(entity);
        }

        public Role Get(Expression<Func<Role, bool>> filter)
        {
            return _roleDal.Get(filter);
        }

        public List<Role> GetList(Expression<Func<Role, bool>> filter = null)
        {
            return _roleDal.GetList(filter);
        }

        public Role Update(Role entity)
        {
            return _roleDal.Update(entity);
        }
    }
}
