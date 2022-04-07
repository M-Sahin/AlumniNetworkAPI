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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Group>()
                .HasMany(p => p.Users)
                .WithMany(p => p.Groups)
                .UsingEntity(j => j.ToTable("GroupUsers"));
        }
        public AlumniNetworkDbContext(DbContextOptions options) : base(options)
            {

            }
    }
}
