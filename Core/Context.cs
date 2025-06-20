using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.models;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class Context : DbContext
    {
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<PartnerRequest> PartnerRequests  {get; set; }
        public DbSet<ProductType> ProductTypes  {get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RequestProduct> RequestsProducts { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=12345;Database=TransportCompany1");
        }
    }
}
