using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "homeeventdetails",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "login",
                url: "Accounts/Login",
                defaults: new { controller = "Accounts", action = "Login" }
                );
            routes.MapRoute(
               name: "signup",
               url: "Accounts/Signup",
               defaults: new { controller = "Accounts", action = "Signup" }
               );
            routes.MapRoute(
                name: "events",
                url: "events",
                defaults: new { controller = "Events", action = "Index" }
                );
            routes.MapRoute(
                name: "addevent",
                url: "events/add",
                defaults: new { controller = "Events", action = "Create" }
            );
            routes.MapRoute(
                name: "eventdetail",
                url: "events/details/{id}",
                defaults: new { controller = "Events", action = "Details" }
            );
            routes.MapRoute(
                name: "editevent",
                url: "events/edit/{id}",
                defaults: new { controller = "Events", action = "Edit" }
            );
            routes.MapRoute(
                name: "eventinvitedto",
                url: "events/invited",
                defaults: new { controller = "Events", action = "EventInvitedTo" }
            );
            routes.MapRoute(
                name: "totaleventdetails",
                url: "Home/details/{id}",
                defaults: new { controller = "Home", action = "Details" }
            );
          
            routes.MapRoute(
                name: "customerSupport",
                url: "Home/GoToUrl",
                defaults: new { controller = "Home", action = "GoToUrl" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
