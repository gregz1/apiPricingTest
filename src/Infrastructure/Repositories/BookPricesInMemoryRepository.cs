using CTechnology.BookPricingApi.Abstractions;
using CTechnology.BookPricingApi.Domain;
using CTechnology.BookPricingApi.Dtos;
using CTechnology.BookPricingApi.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Repositories
{
    public class BookPricesInMemoryRepository : IBookPricesRepository
    {
        private static string _bookPricesFileName = @"Dataset\book-prices.json";
        private static readonly Dictionary<Guid, BookPriceDto> _bookPrices = InitializeInMemoryDictionary();

        public BookPricesInMemoryRepository()
        {
        }

        public async Task SaveAsync(BookPrice bookPrice)
        {
            var bookPriceDto = bookPrice.ToDto();
            _bookPrices[bookPriceDto.Id] = bookPriceDto;
            await Task.CompletedTask;
        }

        public async Task<BookPrice> GetOneAsync(Guid id)
        {
            if (_bookPrices.TryGetValue(id, out var bookPriceDto))
                return await Task.FromResult(bookPriceDto.ToDomain());
            return await Task.FromResult<BookPrice?>(null);
        }

        private static Dictionary<Guid, BookPriceDto> InitializeInMemoryDictionary()
        {
            var path = Assembly.GetExecutingAssembly().Location.Replace(Assembly.GetExecutingAssembly().GetName().Name + ".dll", "");

            string jsonString = File.ReadAllText(Path.Combine(path, @"Dataset/book-prices.json"));
            //string jsonString = File.ReadAllText(@"Dataset/books.json");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var bookDtos = JsonSerializer.Deserialize<List<BookPriceDto>>(jsonString, options);

            return bookDtos.ToDictionary(b => b.Id);
        }
    }
}
