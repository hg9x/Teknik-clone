﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Teknik
{
    public class SubdomainRoute : Route
    {
        public List<string> Subdomains { get; set; }

        public SubdomainRoute(List<string> subdomains, string url, IRouteHandler handler)
        : base(url, handler)
        {
            this.Subdomains = subdomains;
        }
        public SubdomainRoute(List<string> subdomains, string url, RouteValueDictionary defaults, IRouteHandler handler)
        : base(url, defaults, handler)
        {
            this.Subdomains = subdomains;
        }

        public SubdomainRoute(List<string> subdomains, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler handler)
        : base(url, defaults, constraints, handler)
        {
            this.Subdomains = subdomains;
        }

        public SubdomainRoute(List<string> subdomains, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler handler)
        : base(url, defaults, constraints, dataTokens, handler)
        {
            this.Subdomains = subdomains;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            if (routeData == null) return null; // Only look at the subdomain if this route matches in the first place.
            string subdomain = httpContext.Request.QueryString["sub"]; // A subdomain specified as a query parameter takes precedence over the hostname.
            string host = httpContext.Request.Headers["Host"];
            string curSub = host.GetSubdomain();

            // special consideration for 'dev' subdomain
            if (subdomain == null || subdomain == "dev")
            {
                if (!string.IsNullOrEmpty(curSub) && curSub == "dev")
                {
                    // if we are on dev, and the param is dev or empty, we need to initialize it to 'www'
                    subdomain = "www";
                }
            }

            if (subdomain == null)
            {
                subdomain = curSub;
            }
            else
            {
                if (routeData.Values["sub"] == null)
                {
                    routeData.Values["sub"] = subdomain;
                }
                else
                {
                    subdomain = routeData.Values["sub"].ToString();
                }
            }

            //routeData.Values["sub"] = subdomain;
            if (Subdomains.Contains("*") || Subdomains.Contains(subdomain))
            {
                return routeData;
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            object subdomainParam = requestContext.HttpContext.Request.QueryString["sub"];
            if (subdomainParam != null && values["sub"] == null)
                values["sub"] = subdomainParam;
            return base.GetVirtualPath(requestContext, values); // we now have the route based on subdomain
        }
    }
}