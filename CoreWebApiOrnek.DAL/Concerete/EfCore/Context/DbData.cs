using CoreWebApiOrnek.Entities.Concrete;
using CoreWebApiOrnek.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWebApiOrnek.DAL.Concerete.EfCore.Context
{
    public static class DbData
    {
        public static void DbDataDoldur(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApiContext>();

                // var context = app.ApplicationServices.GetRequiredService<ApiContext>();
                context.Database.Migrate();

                if (!context.Users.Any()) //Site Genel ayarları
                {
                    var UserAdd = new[]
                    {
                    new User()
                    {
                        Name="Celal Emre ALTUN",
                        UserName="celalemrealtun",
                        PassWord=Converter.ToHashMd5("123456"),
                        IsAdmin=true,
                    }
                };
                    context.Users.AddRange(UserAdd);
                    context.SaveChanges();
                }

            }
        }
    }
}
