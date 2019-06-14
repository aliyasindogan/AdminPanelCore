using Ninject;
using Ninject.Modules;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPanelCore.CORE.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel _kernel;
        public NinjectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}
