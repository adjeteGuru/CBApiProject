using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CBApi.Database
{
    public class CBApiContextFactory : IDesignTimeDbContextFactory<CBApiContext>
    {
        //public CBApiContext CreateDbContext(string[] args)
        //{
        //    throw new NotImplementedException();
        //}

        public CBApiContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") //just reference
                .Build();//and call the build

            //this instance created is needed in order to pass the connection string to the sql server instance
            var builder = new DbContextOptionsBuilder<CBApiContext>();
            var connectionString = configuration.GetConnectionString("CBApiDb");
            builder.UseSqlServer(connectionString);
            return new CBApiContext(builder.Options);
        }
    }
}
