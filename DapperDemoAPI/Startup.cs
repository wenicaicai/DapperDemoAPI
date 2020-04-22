using AutoMapper;
using DapperDemoAPI.DAL;
using DapperDemoAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLifeCycle;

namespace DapperDemoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbConnection>(Configuration.GetSection("DbConnectionConfig"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API 404" });

            });

            services.AddTransient<IOperationTransient, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddScoped<IOperationScoped, Operation>();

            services.AddTransient<OperationService, OperationService>();

            services.AddSingleton<IOrderService, OrderService>();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<AuthorizationFilter>();
            //    options.Filters.Add<ResourceFilter>();
            //    options.Filters.Add<ActionFilter>();
            //    options.Filters.Add<ResultFilter>();
            //    options.Filters.Add<DapperExceptionFilter>();
            //});

            //services.AddControllersWithViews(config=> 
            //{
            //    config.Filters.Add(new AuthorizationFilter());
            //});



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API 404");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=ServiceLifeCycle}/{id?}");
                    //pattern: "{controller=Home}/{action=UseFilter}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});endpoints.MapControllerRoute(


        }
    }
}
