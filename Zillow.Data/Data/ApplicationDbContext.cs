using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Data.Models;

namespace Zillow.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Imege> Imeges { get; set; }
    }
}
