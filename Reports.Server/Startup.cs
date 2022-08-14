using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Reports.BLL.Resources;
using Reports.BLL.Services;
using Reports.DAL.Database;
using Reports.DAL.Entities;
using Reports.DAL.Repository;

namespace Reports.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reports.Server", Version = "v1" });
            });

            services.AddDbContext<ReportsDatabaseContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("MyServer"));
            });

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();

            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<IRepository<Problem>, ProblemRepository>();

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRepository<Report>, ReportRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Employee),
                typeof(EmployeeResource),
                typeof(SaveEmployeeResource),
                typeof(UpgradeEmployeeResource));
            services.AddAutoMapper(typeof(Problem),
                typeof(ProblemResource),
                typeof(SaveProblemResource),
                typeof(UpgradeProblemResource));
            services.AddAutoMapper(typeof(Report),
                typeof(ReportResource),
                typeof(SaveReportResource),
                typeof(UpgradeReportResource));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reports.Server v1"));
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