using CBApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.Database
{
    public class CBApiContext : DbContext
    {
        public CBApiContext(DbContextOptions<CBApiContext> options)
            //and also give the instance of the generic to the class
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
