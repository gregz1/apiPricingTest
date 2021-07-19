using Cds.Foundation.Test.Pact.Provider;
using CTechnology.BookPricingApi.Api.Bootstrap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace CTechnology.BookPricingApi.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the BookPricingApi provider
    /// </summary>
    public class BookPricingApiProvider : BaseProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookPricingApiProvider"/> class
        /// </summary>
        public BookPricingApiProvider() : base()
        {
            Host = Program.CreateHostBuilder(new string[0])
                    .ConfigureWebHostDefaults(builder =>
                        builder.UseEnvironment("Development")
                            .UseUrls(WebHostUri)
                            .ConfigureTestServices(services =>
                            {

            #pragma warning disable S125
                                //Add your mocks here
                                /*Exemple to mock HttpClient :
                                 * services
                                   .AddHttpClient([MyHttpClient])
                                   .AddHttpMessageHandler(() => new GlobalServiceHandler());
                                */
            #pragma warning restore S125
                            }))
                            .Build();

            Host.Start();
        }
    }
}