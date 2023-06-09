﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teknik.ViewModels;

namespace Teknik.Areas.Users.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HomepageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string CallbackUrl { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
    }
}
