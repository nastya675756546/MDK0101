﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Connect
    {
        public static Database1Entities c;
        public static Database1Entities context
        {
            get
            {
                if (c == null)
                    c = new Database1Entities();
                return c;
            }
        }
    }
}

