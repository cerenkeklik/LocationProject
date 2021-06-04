using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.EFDal;
using Infrastructure.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Security;
using SharedKernel.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
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
            services.AddSingleton<IEmployeeService, EmployeeManager>();
            services.AddSingleton<IEmployeeDal, EfEmployeeDal>();
            services.AddSingleton<IDepartmentService, DepartmentManager>();
            services.AddSingleton<IDepartmentDal, EfDepartmentDal>();
            services.AddSingleton<IManagerService, ManagerManager>();
            services.AddSingleton<IManagerDal, EfManagerDal>();
            services.AddSingleton<IInspectionService, InspectionManager>();
            services.AddSingleton<IInspectionDal, EfInspectionDal>();
            services.AddSingleton<IAuthService<Employee, EmployeeRegisterDto>, AuthEmployeeManager>();
            services.AddSingleton<IAuthService<Manager, ManagerRegisterDto>, AuthManagerManager>();
            services.AddSingleton<ITokenHelper<Employee>, JwtHelper<Employee>>();
            services.AddSingleton<ITokenHelper<Manager>, JwtHelper<Manager>>();



            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            ServiceTool.Create(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
