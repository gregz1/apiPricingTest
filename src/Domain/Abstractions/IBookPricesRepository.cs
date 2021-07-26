using CTechnology.BookPricingApi.Domain;
using System;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Abstractions
{
    public interface IBookPricesRepository
    {
        Task SaveAsync(BookPrice bookPrice);

        Task<BookPrice> GetOneAsync(Guid id);
    }
}
