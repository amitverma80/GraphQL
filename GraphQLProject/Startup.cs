using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLProject.GraphQL.GraphQLSchema;
using GraphQLProject.OType;
using GraphQLProject.Query;
using GraphQLProject.Repository;
using GraphQLProject.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphiQl;

namespace GraphQLProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();

            services.AddScoped<EmployeeService>();

            services.AddScoped<EmployeeRepository>();

            services.AddScoped<EmployeeQuery>();

            services.AddScoped<EmployeeType>();

            services.AddScoped<ISchema, EmployeeSchema>();

            services.AddControllers(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");
            app.UseMvc();
            app.UseRouting();         
        }
    }
}
