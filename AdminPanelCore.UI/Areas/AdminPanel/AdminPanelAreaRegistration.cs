using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
              context.MapRoute(
             "AdminPanel_Home",
              "AdminPanel/Dashboard",
             new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
               "AdminPanel_Login",
               "Login",
               new { controller = "Account", action = "Login", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "AdminPanel_default2",
                "AdminPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}