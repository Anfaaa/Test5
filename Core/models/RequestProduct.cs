using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class RequestProduct
    {
        public int Id { get; set; }

        public string ProductArticle {  get; set; }
        public virtual Product Product { get; set; }

        public int PartnerRequestId { get; set; }
        public virtual PartnerRequest PartnerRequest { get; set; }

        public int Amount { get; set; } 
    }
}
