using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Interface
{
 public   class TestTeckDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        //public TestTeckDbContext()
        //{

        //}
       
        public TestTeckDbContext(DbContextOptions options) : base(options) { }

        public DbSet<FirstResults> results { get; set; }

    }
}
