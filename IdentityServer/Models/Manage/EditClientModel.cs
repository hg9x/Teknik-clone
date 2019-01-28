﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teknik.IdentityServer.Models.Manage
{
    public class EditClientModel
    {
        public string Username { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string HomepageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string CallbackUrl { get; set; }
    }
}
