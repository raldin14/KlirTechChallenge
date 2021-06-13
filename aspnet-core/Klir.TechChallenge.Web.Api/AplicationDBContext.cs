using Klir.TechChallenge.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api
{
    public class AplicationDBContext: DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Promotions> Promotions { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
