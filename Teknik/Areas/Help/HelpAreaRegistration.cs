﻿using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Teknik.Areas.Help
{
    public class HelpAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Help";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapSubdomainRoute(
                 "Help.Index", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "",    // URL with parameters 
                 new { controller = "Help", action = "Index" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.API", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "API/{version}/{service}",    // URL with parameters 
                 new { controller = "Help", action = "API", version = UrlParameter.Optional, service = UrlParameter.Optional },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.Blog", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "Blog",    // URL with parameters 
                 new { controller = "Help", action = "Blog" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.Git", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "Git",    // URL with parameters 
                 new { controller = "Help", action = "Git" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.IRC", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "IRC",    // URL with parameters 
                 new { controller = "Help", action = "IRC" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.Mail", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "Mail",    // URL with parameters 
                 new { controller = "Help", action = "Mail" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.Mumble", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "Mumble",    // URL with parameters 
                 new { controller = "Help", action = "Mumble" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.RSS", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "RSS",    // URL with parameters 
                 new { controller = "Help", action = "RSS" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );
            context.MapSubdomainRoute(
                 "Help.Upload", // Route name
                 new List<string>() { "dev", "help" }, // Subdomains
                 "Upload",    // URL with parameters 
                 new { controller = "Help", action = "Upload" },  // Parameter defaults 
                 new[] { typeof(Controllers.HelpController).Namespace }
             );

            // Register Style Bundles
            BundleTable.Bundles.Add(new StyleBundle("~/Content/help").Include(
                      "~/Areas/Help/Content/Help.css"));
        }
    }
}