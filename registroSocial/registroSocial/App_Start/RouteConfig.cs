﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace registroSocial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("RegistroSocial/editarRegistroSocial");
            routes.IgnoreRoute("RegistroSocial/guardarRegistroSocial");
            routes.IgnoreRoute("RegistroSocial/eliminarRegistroSocial");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
