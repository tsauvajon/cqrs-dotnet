using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using FluentValidation;
using StackExchange.Redis;
using CQRS.Employee;
using CQRS.Location;
using Microsoft.Extensions.Configuration;
using StructureMap.Graph;
using CQRSlite.Bus;
using CQRSlite.Commands;
using CQRSlite.Events;
using StructureMap.Web;
using CQRSlite.Domain;
using CQRSlite.Cache;
using CQRS.CQRSCode.WriteModel;
using AutoMapper;
using CQRS.CQRSCode;

namespace CQRS
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddRouting();
            services.AddAutoMapper(typeof(Startup));
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });
        }

        /// <summary>
        /// Configure StructureMap ?
        /// </summary>
        /// <param name="services">Services to configure</param>
        /// <returns>Service provider</returns>
        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.AssemblyContainingType(typeof(Startup));
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<BaseEvent>();
                    scan.Convention<FirstInterfaceConvention>();
                });

                // Repos
                config.For<IEmployeeRepository>().Use<EmployeeRepository>();
                config.For<ILocationRepository>().Use<LocationRepository>();

                // StackExchange.Redis
                ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost");
                config.For<IConnectionMultiplexer>().Use(multiplexer);

                // CQRSLite
                config.For<InProcessBus>().Singleton().Use<InProcessBus>();
                config.For<ICommandSender>().Use(y => y.GetInstance<InProcessBus>());
                config.For<IEventPublisher>().Use(y => y.GetInstance<InProcessBus>());
                //config.For<ICache>().Use(y => y.GetInstance<InProcessBus>()); // Test
                config.For<IHandlerRegistrar>().Use(y => y.GetInstance<InProcessBus>());
                config.For<CQRSlite.Domain.ISession>().HybridHttpOrThreadLocalScoped().Use<Session>();
                config.For<IEventStore>().Singleton().Use<InMemoryEventStore>();
                config.For<IRepository>().HybridHttpOrThreadLocalScoped().Use(y =>
                    new CacheRepository(new Repository(y.GetInstance<IEventStore>()), y.GetInstance<IEventStore>(), new MemoryCache()));

                // AutoMapper
                // automatic with services.AddAutoMapper(...) ??

                //config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
