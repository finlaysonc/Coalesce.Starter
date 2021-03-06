using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Coalesce.TaskListSample.Data;
using Microsoft.EntityFrameworkCore;
using IntelliTect.Coalesce.TypeDefinition;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Coalesce.TaskListSample.Data.Data;

namespace Coalesce.TaskListSample.Web
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose()
        {
        }

        private class MyLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return logLevel == LogLevel.Warning;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                File.AppendAllText(@"C:\temp\log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }


    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                // .AddJsonFile($"appsettings.{System.Environment.MachineName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Console.WriteLine($"Configuration Complete for {System.Environment.MachineName}");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionName = "DefaultConnection";
            Console.WriteLine($"Connection Name: {connectionName}");

            string connString = Configuration.GetConnectionString(connectionName);
            Console.WriteLine($"Connection String: {connString}");

            // Add Entity Framework services to the services
            services.AddSingleton<IConfigurationRoot, IConfigurationRoot>(sp => Configuration);
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connString).
                ConfigureWarnings(warnings =>
                    {
                        warnings.Log(CoreEventId.IncludeIgnoredWarning);
                        warnings.Log(RelationalEventId.OpeningConnection);
                        warnings.Log(RelationalEventId.PossibleIncorrectResultsUsingLikeOperator);
                        warnings.Log(RelationalEventId.PossibleUnintendedUseOfEqualsWarning);
                        warnings.Log(RelationalEventId.QueryClientEvaluationWarning);
                    }));
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null) (resolver as DefaultContractResolver).NamingStrategy = null;

                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddDefaultTokenProviders();

            ReflectionRepository.AddContext<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Warning);
            loggerFactory.AddProvider(new MyLoggerProvider());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                // Dummy authentication for initial development.
                // Replace this with ASP.NET Core Identity, Windows Authentication, or some other auth scheme.
                // This exists only because Coalesce restricts all generated pages and API to only logged in users by default.
                const string Scheme = "TestAuth";
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationScheme = Scheme,
                    AutomaticAuthenticate = true
                });
                app.Use(async (context, next) =>
                {
                    Claim[] claims = new[] { new Claim(ClaimTypes.Name, "developmentuser") };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await context.Authentication.SignInAsync(Scheme, context.User = new ClaimsPrincipal(identity));

                    await next.Invoke();
                });
                // End Dummy Authentication.
            }


            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Run database migrations.
            AppDbContext db = app.ApplicationServices.GetService<AppDbContext>();
            DbInitializer.Initialize(db);
            //db.Initialize();
        }
    }
}
