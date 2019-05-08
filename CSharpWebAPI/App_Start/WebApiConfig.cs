using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using CSharpWebAPI.Filters;
using CSharpWebAPI.Models;
using Ninject;

namespace CSharpWebAPI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults : new {
                    id = RouteParameter.Optional
                }
            );

            config.Filters.Add(new ValidationActionFilter());
            var kernel = new StandardKernel();
            kernel.Bind<ICommentRepository>().ToConstant(new InitialData());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}
