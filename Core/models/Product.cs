using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.models
{
    [PrimaryKey("Article")]
    public class Product
    {
        [StringLength(7)]
        public string Article { get; set; }

        public string Name { get; set; }

        [Precision(2)]
        public double MinPrice { get; set; }

        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }



    }
}
