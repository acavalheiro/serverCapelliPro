// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace CapelliPro.WebApi
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using CapelliPro.Authorization;
    using CapelliPro.Authorization.Models;
    using CapelliPro.Domain.Data;
    using CapelliPro.Domain.Data.Repositories;
    using CapelliPro.Domain.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ApplicationAuthorizationContext>(
                options => options.UseMySql(
                    this.Configuration.GetConnectionString("AuthorizationConnectionString"),
                    new MySqlServerVersion(new Version(8, 0, 20))));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationAuthorizationContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationContext>(
                options => options.UseMySql(
                    this.Configuration.GetConnectionString("AuthorizationConnectionString"),
                    new MySqlServerVersion(new Version(8, 0, 20))));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })

                // Adding Jwt Bearer  
                .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = false,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidAudience = Configuration["JWT:ValidAudience"],
                            ValidIssuer = Configuration["JWT:ValidIssuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]))
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CapelliPro.WebApi", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                                   {
                                                       {
                                                           new OpenApiSecurityScheme
                                                               {
                                                                   Reference = new OpenApiReference
                                                                                   {
                                                                                       Type = ReferenceType.SecurityScheme,
                                                                                       Id = "Bearer"
                                                                                   }
                                                               },
                                                           new string[] {}

                                                       }
                                                   });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CapelliPro.WebApi v1"));
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
