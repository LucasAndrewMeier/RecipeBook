using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RecipeBook.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*List the first page of recipes from all cuisines*/
            routes.MapRoute(name: null, "", new
                            {
                                Controller = "Recipe",
                                action = "List",
                                cuisine = (string) null,
                                page = 1
                            });
            /*List the specified page of recipes from /Page(x), showing all cuisine*/
            routes.MapRoute(name: null, "Page{page}", new
            {
                Controller = "Recipe",
                action = "List",
                cuisine = (string)null,
                
            },
            new { page = @"\d+" });

            /*/cuisine(x) showing the first page of items from a specific cuisine*/
            routes.MapRoute(name: null, "{cuisine}", new
            {
                Controller = "Recipe",
                action = "List",
                page = 1
            });

            /*List /cuisine(x)/Page(x) specified recipe of specified cuisine*/
            routes.MapRoute(name: null, "{cuisine}/Page{page}", new
            {
                Controller = "Recipe",
                action = "List",
            },
            new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}/");
                
        }
    }
}
