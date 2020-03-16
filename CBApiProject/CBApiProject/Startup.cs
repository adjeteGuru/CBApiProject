
using CBApi.DataAccess.Repository;
using CBApi.DataAccess.Repository.Contracts;
using CBApi.Database;
using CBApi.Types;
using CBApiProject.Queries;
using CBApiProject.Schema;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
//using HotChocolate;

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

            //this is registered from Repository interface in order to use them
            //so a new instance will be provided to every controller and every service
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<CBApiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CBApiDb")));

            //to register IDocument as singleton
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new CBApiSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            // this enables you to use DataLoader in your resolvers.
            //services.AddDataLoaderRegistry();

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CBApiContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseGraphiQl();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app
             
            //   .UseWebSockets()
            //  // .UseGraphQL("/graphql")
            //   //.UsePlayground("/graphql")
            //   .UseVoyager("/graphql");

            db.EnsureSeedData();
        }
    }
}
