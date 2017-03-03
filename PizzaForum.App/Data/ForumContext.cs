namespace PizzaForum.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PizzaForum.App.Models;

    public class ForumContext : DbContext
    {
        
        public ForumContext()
            : base("ForumContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Session> Sessions { get; set; }
    }
}