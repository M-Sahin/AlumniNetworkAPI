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
        public DbSet<Event> Events { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                .HasKey(bc => new { bc.UserId, bc.GroupId });
            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.GroupUsers)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.Group)
                .WithMany(c => c.GroupUsers)
                .HasForeignKey(bc => bc.GroupId);
        }
        public AlumniNetworkDbContext(DbContextOptions options) : base(options)
            {

            }
    }
}
