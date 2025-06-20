using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.models
{
    public class ProductType
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Precision(2)]
        public double Rate { get; set; }    
    }
}
