using AutoMapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Common.Settings;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Scheduler;
using EverestLMS.Services.Implementations;
using EverestLMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace EverestLMS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            var seqUrl = configuration.GetSection("AppSettings:SeqUrl").Value.ToString();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Seq(seqUrl)
                .CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string AllowAllPolicy = "AllowAllPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => 
            {
                options.AddPolicy(AllowAllPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Version = "1.0", Description = "EverestLMS" });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference 
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" 
                            }
                        }, new List<string>() 
                    }
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddScoped<IDbConnection>(x => new SqlConnection(Configuration.GetConnectionString("SqlConnection")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            RegisterServices(services);
            RegisterRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(builder => 
                {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error != null)
                        {
                            Log.Error("An error ocurred with exception: {@Exception}", error);
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(AllowAllPolicy);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Everest LMS!");
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.InjectJavascript("/swagger-ui/custom.js?version=1.0", "text/javascript");
                c.DocumentTitle = "Everest LMS";
                c.DocExpansion(DocExpansion.None);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Register Scheduler to Predict with ML .NET the recommendations of courses
            RegisterScheduler(() => GetPredictionInstance().CreatePredictionCoursesForParticipants());
        }

        #region Privates Methods
        private void RegisterScheduler(Action task)
        {
            //SchedulerManager.IntervalInMinutes(DateTime.Now.Hour, (DateTime.Now.Minute + 1), 10, task); //Test
            SchedulerManager.IntervalInHours(DateTime.Now.Hour, (DateTime.Now.Minute + 1), 12, task);
        }

        private IPredictionTrainerService GetPredictionInstance()
        {
            IDbConnection connection = new SqlConnection(Configuration.GetConnectionString("SqlConnection"));
            var ratingCursoRepository = new RatingCursoRepository(connection);
            var cursoRepository = new CursoRepository(connection);
            var participanteRepository = new ParticipanteRepository(connection);
            var predictionTrainerRepository = new PredictionTrainerRepository(connection);
            var predictionTraienerService = new PredictionTrainerService(ratingCursoRepository, cursoRepository, participanteRepository, predictionTrainerRepository, Configuration);
            return predictionTraienerService;
        }

        private void RegisterServices(IServiceCollection services)
        {            
            services.AddScoped<IParticipanteService, ParticipanteService>();
            services.AddScoped<ILineaCarreraService, LineaCarreraService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IPredictionTrainerService, PredictionTrainerService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ISedeService, SedeService>();
            services.AddScoped<ICalendarioService, CalendarioService>();
            services.AddScoped<IIdiomaService, IdiomaService>();
            services.AddScoped<IDificultadService, DificultadService>();
            services.AddScoped<IEtapaService, EtapaService>();
            services.AddScoped<ICloudinaryFileService, CloudinaryFileService>();
            services.AddScoped<ILeccionService, LeccionService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IExamenService, ExamenService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddScoped<ILineaCarreraRepository, LineaCarreraRepository>();
            services.AddScoped<INivelRepository, NivelRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IConocimientoRepository, ConocimientoRepository>();
            services.AddScoped<IRatingCursoRepository, RatingCursoRepository>();
            services.AddScoped<IPredictionTrainerRepository, PredictionTrainerRepository>();
            services.AddScoped<ISedeRepository, SedeRepository>();
            services.AddScoped<ICalendarioRepository, CalendarioRepository>();
            services.AddScoped<IIdiomaRepository, IdiomaRepository>();
            services.AddScoped<IDificultadRepository, DificultadRepository>();
            services.AddScoped<IEtapaRepository, EtapaRepository>();
            services.AddScoped<ICloudinaryFileRepository, CloudinaryFileRepository>();
            services.AddScoped<ILeccionRepository, LeccionRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IExamenRepository, ExamenRepository>();
        }
        #endregion
    }
}
