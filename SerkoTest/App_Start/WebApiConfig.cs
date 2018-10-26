using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SerkoTest.Interface;
using SerkoTest.Services;
using Ninject.Modules;
using Ninject;
using System.Reflection;
using SerkoTest.Interface;
using SerkoTest.Controllers;
using Unity;
using Unity.Lifetime;

namespace SerkoTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
