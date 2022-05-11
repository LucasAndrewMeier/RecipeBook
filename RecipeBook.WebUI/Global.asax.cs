using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RecipeBook.Domain.Entities;
using RecipeBook.WebUI.Infrastructure.Binders;


namespace RecipeBook.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //add ModelBinders
            ModelBinders.Binders.Add(typeof(Schedule), new ScheduleModelBinder());
        }
    }
}
