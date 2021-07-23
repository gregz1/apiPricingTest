using CTechnology.BookPricingApi.Api.Features.BookPricing.Models;
using System.Collections.Generic;
using System.Linq;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Mappers
{
    internal static class BookPriceMapper
    {
        internal static BookPrice ToModel(this Domain.BookPrice bookPrice) =>
            new BookPrice
            {
                Price = new Price
                {
                    Id = bookPrice.Price.Id,
                    Value = bookPrice.Price.Value,
                    Currency = (Currency)bookPrice.Price.Currency,
                    Symbol = bookPrice.Price.Symbol,
                    Raw = bookPrice.Price.Raw
                },
                UpdatedAt = bookPrice.UpdatedAt
            };

        internal static IEnumerable<BookPrice> ToModel(this IEnumerable<Domain.BookPrice> bookPrices) =>
            bookPrices.Select(b => b.ToModel());
    }
}
