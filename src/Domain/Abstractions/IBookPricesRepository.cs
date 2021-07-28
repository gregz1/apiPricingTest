using CTechnology.BookPricingApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Abstractions
{
    public interface IBookPricesRepository
    {
        Task SaveAsync(BookPrice bookPrice);

        Task<BookPrice> GetOneAsync(Guid id);

        Task<List<BookPrice>> FindAllAsync(Guid bookId);
    }
}
