using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CTechnology.BookPricingApi.Abstractions;
using CTechnology.BookPricingApi.Domain;

namespace CTechnology.BookPricingApi.Tests.Pact.Provider.Fakes
{
    public class FakeBookPricesInMemoryRepository : IBookPricesRepository
    {
        public Task<List<BookPrice>> FindAllAsync(Guid bookId)
        {
            var list = new List<BookPrice>
            {
                new BookPrice { 
                    BookId = Guid.Parse("8500c31a-b16d-4dab-81bd-dd84e9038a41"),
                    Price = new Price 
                    { 
                        Id =  Guid.Parse("94235bd9-a208-4b53-aca5-bd2b665656fb"),
                        Value = 39.00m,
                        Currency = Currency.EUR,
                        Symbol = "\u20AC", Raw ="39.00\u20AC"
                    },
                    UpdatedAt = DateTime.UtcNow},
                new BookPrice {
                    BookId = Guid.Parse("8500c31a-b16d-4dab-81bd-dd84e9038a41"),
                    Price = new Price
                    {
                        Id =  Guid.Parse("4c2e45ba-9564-4b72-a1bd-a20bed322675"),
                        Value = 35.99m,
                        Currency = Currency.EUR,
                        Symbol = "\u20AC", Raw ="35.99\u20AC"
                    },
                    UpdatedAt = DateTime.UtcNow}
            };

            return Task.FromResult(list);
        }

        public Task<BookPrice> GetOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(BookPrice bookPrice)
        {
            return Task.CompletedTask;
        }
    }
}
