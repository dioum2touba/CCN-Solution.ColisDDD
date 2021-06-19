using CCN_Solution.ColisDDD.Application.Interfaces;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using CCN_Solution.ColisDDD.Application.Wrappers;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Domain.Settings;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using CCNSolution.ColisDDD.Application.Wrappers;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            switch (configuration["SGBDType"])
            {
                case "UseInMemoryDatabase":
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseInMemoryDatabase("ApplicationDb"));
                    break;
                case "PostgresQl":
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
                    break;
                case "MySQL":
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(configuration.GetConnectionString("DefaultConnection")));
                    break;
                default:
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                    break;
            }

            services.AddIdentity<ApplicationUser, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            #region Services
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAgenceService, AgenceService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<ITypeDeColisService, TypeDeColisService>();
            services.AddTransient<IColisService, ColisService>();
            services.AddTransient<ILivraisonService, LivraisonService>();
            services.AddTransient<ITypeLivraisonService, TypeLivraisonService>();
            services.AddTransient<ITypeAgenceService, TypeAgenceService>();
            services.AddTransient<IMoyenTransportService, MoyenTransportService>();
            services.AddTransient<IPrixVoyageRegionService, PrixVoyageRegionsService>();
            #endregion

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                    };
                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized in this API"));
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not authorized to access this resource"));
                            return context.Response.WriteAsync(result);
                        },
                    };

                });

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IAgenceRepository, AgenceRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ITypeDeColisRepository, TypeDeColisRepository>();
            services.AddTransient<IColisRepository, ColisRepository>();
            services.AddTransient<ILivraisonRepository, LivraisonRepository>();
            services.AddTransient<IPrixVoyageRegionRepository, PrixVoyageRegionRepository>();
            services.AddTransient<IMoyenTransportRepository, MoyenTransportRepository>();
            services.AddTransient<ITypeLivraisonRepository, TypeLivraisonRepository>();
            services.AddTransient<ITypeAgenceRepository, TypeAgenceRepository>();
            #endregion
        }
    }
}
