﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik.ViewModels;

namespace Teknik.Areas.Paste.ViewModels
{
    public class PasteViewModel : ViewModelBase
    {
        public string Url { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Syntax { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
