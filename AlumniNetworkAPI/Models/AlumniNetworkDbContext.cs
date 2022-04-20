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
        public DbSet<EventGroupInvite> EventGroupInvites { get; set; }
        public DbSet<EventTopicInvite> EventTopicInvites { get; set; }
        public DbSet<EventUserInvite> EventUserInvites { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<PostReplies> PostReplies { get; set; }



        public AlumniNetworkDbContext(DbContextOptions options) : base(options)
            {

            }
    }
}
