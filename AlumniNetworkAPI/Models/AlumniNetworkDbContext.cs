using System;
using System.Linq;
using AlumniNetworkAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace AlumniNetworkAPI.Models
{
    public class AlumniNetworkDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public object User { get; internal set; }

        public AlumniNetworkDbContext(DbContextOptions options) : base(options)
            {

            }

    }
}
