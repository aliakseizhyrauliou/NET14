﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.ArtImage
{
    public class AddCategoriVewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
