﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models
{
    public class AddProductVewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Category { get; set; }
        public int Quantity { get; set; }
        public string Material { get; set; }
    }
}
