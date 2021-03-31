using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Repositories;
using UserDetails.Domain.Services;
using UserDetails.Mapping;
using UserDetails.Persistence.Contexts;
using UserDetails.Persistence.Repositories;
using UserDetails.Services;

namespace UserDetails
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
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserDetailService", Version = "v1", });
            });
            services.AddMvc(Options => Options.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("userDetails-api-in-memory");
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserDetailRepository, UserRepository>();
            services.AddScoped<IUserDetailService, UserDetailService>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IUserDetailAddressService, UserAddressDetailService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserDetailService");
                
            });
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

          
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
