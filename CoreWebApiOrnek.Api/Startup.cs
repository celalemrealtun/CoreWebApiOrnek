using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork;
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using CoreWebApiOrnek.BL.Containers.MicrosoftIoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace CoreWebApiOrnek.Api
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
            services.AddCors(options =>
                             options.AddDefaultPolicy(builder =>builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("doc", new OpenApiInfo
                {
                    Title = "Test Api",
                    Description = "Test Api Document",
                    Contact = new OpenApiContact
                    {
                        Email = "cea_tr@msn.com"
                    }
                });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header, //jwtyi headerde taþýdýðýmz için.
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Description = "Bearer {token}"
                });
            }
            );

            services.AddAutoMapper(typeof(Startup));
            services.AddDependencies();
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CoreWebApiOrnek.DAL")));
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddFluentValidation();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                      ClockSkew = TimeSpan.Zero//default 5min
                  };
                  options.Events = new JwtBearerEvents
                  {
                      OnTokenValidated = ctx =>
                      {

                          return Task.CompletedTask;
                      },
                      OnAuthenticationFailed = ctx =>
                      {
                          Console.WriteLine("Exception:{0}", ctx.Exception.Message);
                          return Task.CompletedTask;
                      }
                  };
              });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/doc/swagger.json", "Test Api");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            DbData.DbDataDoldur(app);
        }
    }
}
