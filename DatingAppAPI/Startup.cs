using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DatingAppAPI.Data;
using DatingAppAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DatingAppAPI
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
            //dps de crear nuestro DataContext class para acceso a bd necesitamos inyectarlo como servicio
            services.AddDbContext<DataContext>(e => e.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).
            AddJsonOptions(op => {
               op.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
          
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IDatingRepository,DatingRepository>();
           
            //autenticacion como servicio 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer( opciones => {

                opciones.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true, //indicamos si validamos por clave
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    .GetBytes(Configuration.GetSection("AppSettings:Token").Value)), // indicamos la clave
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            }

            );
        services.AddCors();
        services.AddTransient<SeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedData seeder)
        {
            if (env.IsDevelopment())
            {
                
                //si el ambiente de trabajo es desarrollo veo la web de error
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseHsts();
                //este es el global exception handler para cuando no estoy en development mode
                app.UseExceptionHandler(constructor =>
                {
                    constructor.Run(async contexto =>
                    {
                        contexto.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = contexto.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            //esto primera linea es solo para que no muestre el error de cors
                            contexto.Response.AgregarErrorAplicacion(error.Error.Message);
                            await contexto.Response.WriteAsync(error.Error.Message);
                        }
                    });

                });

            }

           // app.UseHttpsRedirection();y
            //comento esta linea porque solo necesito el seed una vez dps del drop y update 
            //seeder.SeedingUsers();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
