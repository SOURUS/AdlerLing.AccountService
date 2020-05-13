using AdlerLing.AccountService.Core.Settings;
using AdlerLing.AccountService.Infrustructure.DAL.Implementations;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.Service.Implementation;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using AdlerLing.AccountService.WebApi.Helpers;
using AdlerLing.AccountService.WebApi.Model.Request;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace AdlerLing.AccountService.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");

            services.AddMvc(setup =>
            {
                setup.Filters.Add(typeof(ValidateModelStateAttribute));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IValidator<UserModel>, UserModelValidator>();

            services.Configure<DBSettings>(
                Configuration.GetSection("ConnectionStrings"));

            //services.AddSingleton(new ResourceManager("AdlerLing.AccountService.WebApi.Resources", typeof(Startup).GetTypeInfo().Assembly));

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserDAL>(x =>
                ActivatorUtilities.CreateInstance<UserDAL>(x, Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<SharedErrorResource>();

            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var cultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo ("ru-RU")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions{
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
