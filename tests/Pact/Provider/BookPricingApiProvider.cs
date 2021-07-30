using System;

using Cds.Foundation.Test.Pact.Provider;

using CTechnology.BookPricingApi.Abstractions;
using CTechnology.BookPricingApi.Api.Bootstrap;
using CTechnology.BookPricingApi.Repositories;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
        public BookPricingApiProvider() : base(new Uri("http://a08pact001.cdbdx.biz/"), "book-pricing-api", "master")
        {
            Host = Program.CreateHostBuilder(new string[0])
                    .ConfigureWebHostDefaults(builder =>
                        builder.UseEnvironment("Development")
                            .UseUrls(WebHostUri)
                            .ConfigureTestServices(services =>
                            {
                                services.AddSingleton<IBookPricesRepository, BookPricesInMemoryRepository>();
                            }))
                            .Build();

            Host.Start();
        }
    }
}