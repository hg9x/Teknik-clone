﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teknik.IdentityServer.Models.Manage
{
    public class CreateClientModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string RedirectURI { get; set; }
        public string PostLogoutRedirectURI { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
    }
}
