using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.models
{
    public class MaterialType
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        [Precision(2)]
        public double RejectRate { get; set; }

    }
}
