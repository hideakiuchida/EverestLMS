using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverestLMS.DataAccess;
using EverestLMS.Repository;
using EverestLMS.Repository.Participante;
using EverestLMS.Services.Participante;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.POCO;
using EverestLMS.Services.LineaCarreraService;
using EverestLMS.Services.NivelService;
using EverestLMS.Repository.ConocimientoRepository;

namespace EverestLMS.API
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
            services.AddDbContext<everestlmsContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);           
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Everest LMS API", Version = "v1" });
            });
            services.AddAutoMapper();

            services.AddScoped<IParticipanteService, ParticipanteService>();
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();

            services.AddScoped<ILineaCarreraService, LineaCarreraService>();
            services.AddScoped<IEverestRepository<LineaCarrera>, EverestRepository<LineaCarrera>>();

            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IEverestRepository<Nivel>, EverestRepository<Nivel>>();

            services.AddScoped<IConocimientoRepository, ConocimientoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder => 
                {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Everest LMS!"); });
            app.UseMvc();
        }
    }
}
