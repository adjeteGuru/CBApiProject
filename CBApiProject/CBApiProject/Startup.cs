using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBApi.DataAccess.Repository;
using CBApi.DataAccess.Repository.Contracts;
using CBApi.Database;
using CBApi.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CBApiProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<CBApiContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:CBApiDb"]));

            services.AddGraphQL(SchemaBuilder.New()
                .AddQueryType<UserType>());
                //AddType<>(CharacterType));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CBApiContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseGraphQL("/graphql");

            db.EnsureSeedData();
        }
    }
}
