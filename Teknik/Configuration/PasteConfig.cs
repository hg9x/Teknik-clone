﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik.Configuration
{
    public class PasteConfig
    {
        public int UrlLength { get; set; }
        public int KeySize { get; set; }
        public int BlockSize { get; set; }

        public PasteConfig()
        {
            UrlLength = 5;
            KeySize = 256;
            BlockSize = 128;
        }
    }
}
