using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EventManagement.Models;
namespace EventManagement.Context
{
    public class LoginContext: DbContext
    {
        public virtual DbSet<UserModel> Users { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}