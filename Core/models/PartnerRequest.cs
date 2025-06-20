using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class PartnerRequest
    {

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string DirectorSurname{ get; set; }

        [StringLength(50)]
        public string DirectorName { get; set; }

        [StringLength(50)]
        public string? DirectorMiddleName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(13)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public int Rating { get; set; }

        public int PartnerTypeId { get; set; }
        public virtual PartnerType PartnerType { get; set; }

        public virtual ICollection<RequestProduct> RequestProduct { get; set; }

        [NotMapped]
        public double TotalPrice
        {
            get
            {
                return RequestProduct?.Sum(rp => rp.Amount * (rp.Product.MinPrice)) ?? 0;

            }
        }
    }
}
