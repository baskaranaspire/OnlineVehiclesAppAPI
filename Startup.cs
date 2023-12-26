using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnlineVehiclesApplication.Constants;
using OnlineVehiclesApplication.Interfaces;
using OnlineVehiclesApplication.Repositories;
using OnlineVehiclesApplication.Services;
using System.Reflection;

namespace OnlineVehiclesApplication
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
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            services.AddSession();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            Global.ConnectionStringPostgreSQL = Configuration.GetConnectionString("DBConnection");

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineVehicles", Version = "v1" });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });
            services.AddHttpClient();
            //services.AddWebApi();
            services.AddMvc();
            services.AddScoped<IVehiclesRepository, VehiclesRepository>();
            services.AddScoped<IVehicleServices, VehicleServices>();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(typeof(VehiclesRepository).Assembly);
            services.AddMediatR(typeof(VehicleServices).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineVehicles v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineVehicles API");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
