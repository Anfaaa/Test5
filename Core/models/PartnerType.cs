﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class PartnerType
    {
        public int Id { get; set; }

        [StringLength(5)]
        public string Name { get; set; }

    }
}
