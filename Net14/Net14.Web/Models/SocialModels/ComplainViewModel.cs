﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Models
{
    public class ComplainViewModel
    {
        public int Post { get; set; }
        public int OwnerOfComplain { get; set; }
        public string ReasonOfComplain { get; set; }
        public bool IsChecked { get; set; }

    }
}