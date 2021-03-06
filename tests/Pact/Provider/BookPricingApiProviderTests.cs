using System.Threading.Tasks;

using Cds.Foundation.Test.Pact.Provider;

using Xunit;
using Xunit.Abstractions;

namespace CTechnology.BookPricingApi.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the BookPricingApi provider tests
    /// </summary>
    public class BookPricingApiProviderTests : BaseProviderTests<BookPricingApiProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookPricingApiProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public BookPricingApiProviderTests(ITestOutputHelper output, BookPricingApiProvider provider) : base(output, provider)
        {
        }

        [Fact]
        public Task Provider_BookPricingApi() => EnsureProviderHonoursPactAsync();
    }
}
