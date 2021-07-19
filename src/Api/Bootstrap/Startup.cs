using System;
using System.Diagnostics.CodeAnalysis;


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CTechnology.BookPricingApi.Api.Bootstrap
{
#pragma warning disable S1200

    /// <summary>
    /// Represents the application's bootstrap.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        #region Fields

        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="configuration">The configuration.</param>
        public Startup(IHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddHealthChecks()
                .AddCheck("Default", () => HealthCheckResult.Healthy("OK"))
                // [You can add more checks here...]
            ;

            services
                // Registers the Swagger generator, defining one Swagger document.
                .AddCustomSwaggerGen<Startup>()
                // Registers a single HTTP client in `IHttpClientFactory` with Cdiscount default policies (Polly).
                .AddDefaultHttpClient()
                // Registers services to compress outputs.
                .AddResponseCompression()
                // Registers sensitive encryption services (e.g. to encrypt cookies).
                .AddDataProtection();

            services
                // Registers MVC & Web API services.
                .AddMvcCore()
                    .AddDataAnnotations()
                    .AddAuthorization()
                    // Registers services to generate OpenApi Specifications (via third party library).
                    .AddApiExplorer()
                    // Registers Cdiscount's services to handle field selection, paging, etc.
                    .AddUnifiedRestApi(options => options.UseCamelCaseNamingPolicy());

            // [You can add your own application services here...]
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Configure(IApplicationBuilder application)
        {
            if (_environment.IsLocal())
            {
                // Uses development tools.
                application
                    .UseBrowserLink()
                    .UseDeveloperExceptionPage()
                    .UseWebApiExceptionHandler();
            }
            else
            {
                application.UseExceptionMonithorLogging();
            }

            application.UseRouting();

            application
                .UseResponseCompression()
                .UseCustomSwagger<Startup>()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks();
                });
        }
    }
#pragma warning restore S1200
}
