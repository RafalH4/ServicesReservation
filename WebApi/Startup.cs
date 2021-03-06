using System.Net;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebApi.AvaiableServiceDirectory;
using WebApi.DataContext;
using WebApi.DayWorkDirectory;
using WebApi.Helpers;
using WebApi.ServiceDirectory;
using WebApi.UserDirectory;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace WebApi
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
            var dbConnectionString = Configuration.GetSection("AppSettings:DbConnection").Value;
            services.AddDbContext<Context>(opt =>
                opt.UseSqlServer(dbConnectionString));
            services.AddControllers();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Api", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                opt.OperationFilter<SecurityRequirementsOperationFilter>();
            }
                );
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(opt =>
             {
                 opt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("admin", policy => policy.RequireRole("admin"));
                opt.AddPolicy("client", policy => policy.RequireRole("client"));
            });

            var autoMapperConfig = new MapperConfiguration(opt => {
                opt.AddProfile(new AutoMapping());
            });

            IMapper mapper = autoMapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IDayWorkRepository, DayWorkRepository>();
            services.AddScoped<IDayWorkService, DayWorkService>();
            services.AddScoped<IItemServiceRepository, ItemServiceRepository>();
            services.AddScoped<IItemServiceService, ItemServiceService>();
            services.AddScoped<IJwtHandler, JwtHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }
            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1")); 

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
