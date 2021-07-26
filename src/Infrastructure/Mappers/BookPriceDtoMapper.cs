using CTechnology.BookPricingApi.Domain;
using CTechnology.BookPricingApi.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace CTechnology.BookPricingApi.Mappers
{
    public static class BookPriceDtoMapper
    {
        public static BookPriceDto ToDto(this BookPrice bookPrice) =>
            new BookPriceDto
            {
                Id = bookPrice.Price.Id,
                BookId = bookPrice.BookId,
                Value = bookPrice.Price.Value,
                Currency = (CurrencyDto)bookPrice.Price.Currency,
                Symbol = bookPrice.Price.Symbol,
                Raw = bookPrice.Price.Raw,
                CreatedAt = bookPrice.CreatedAt,
                UpdatedAt = bookPrice.UpdatedAt
            };

        public static BookPrice ToDomain(this BookPriceDto bookPriceDto) =>
            new BookPrice
            {
                BookId = bookPriceDto.BookId,
                Price = new Price
                {
                    Id = bookPriceDto.Id,
                    Value = bookPriceDto.Value,
                    Currency = (Currency)bookPriceDto.Currency,
                    Symbol = bookPriceDto.Symbol,
                    Raw = bookPriceDto.Raw
                }
            };

        public static IEnumerable<BookPrice> ToDomain(this IEnumerable<BookPriceDto> bookPriceDtos) =>
            bookPriceDtos.Select(b => b.ToDomain());
    }
}
