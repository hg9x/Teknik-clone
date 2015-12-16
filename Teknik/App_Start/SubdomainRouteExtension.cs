﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Teknik
{
    public static class SubdomainRouteExtension
    {
        public static SubdomainRoute MapSubdomainRoute(this RouteCollection routes, string name, string subDomain, string url, object defaults)
        {

            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new MvcRouteHandler());
            routes.Add(name, route);

            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this RouteCollection routes, string name, string subDomain, string url, object defaults, object constraints)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(constraints),
                new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this RouteCollection routes, string name, string subDomain, string url, object defaults, string[] namespaces)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(namespaces),
                new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, object defaults)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(new {}),
                new RouteValueDictionary(new {Area = context.AreaName}),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, object defaults, object constraints)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(constraints),
                new RouteValueDictionary(new {Area = context.AreaName}),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, object defaults, string[] namespaces)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(new {}),
                new RouteValueDictionary(new { Area = context.AreaName, Namespaces = namespaces }),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, string area, object defaults)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(new { }),
                new RouteValueDictionary(new { Area = area }),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, string area, object defaults, object constraints)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(constraints),
                new RouteValueDictionary(new { Area = area }),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }

        public static SubdomainRoute MapSubdomainRoute(this AreaRegistrationContext context, string name, string subDomain, string url, string area, object defaults, string[] namespaces)
        {
            SubdomainRoute route = new SubdomainRoute(
                subDomain,
                url,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(new { }),
                new RouteValueDictionary(new { Area = area, Namespaces = namespaces }),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
            return route;
        }
    }
}