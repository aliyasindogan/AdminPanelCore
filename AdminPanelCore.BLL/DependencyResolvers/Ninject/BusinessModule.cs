using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.BLL.Concrete;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.DAL.Concrete.Contexts;
using AdminPanelCore.DAL.Concrete.EntityFramework;
using AdWebTemplate.Business.Abstarct;
using Ninject.Modules;
using System.Data.Entity;

namespace AdWebTemplate.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<ICategoryTypeService>().To<CategoryTypeManager>().InSingletonScope();
            Bind<ICategoryTypeDal>().To<EfCategoryTypeDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope();

            Bind<ISliderService>().To<SliderManager>().InSingletonScope();
            Bind<ISliderDal>().To<EfSliderDal>().InSingletonScope();

            Bind<DbContext>().To<DatabaseContext>().InSingletonScope();
        }
    }
}