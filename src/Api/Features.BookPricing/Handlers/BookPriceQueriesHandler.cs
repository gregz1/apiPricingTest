using CTechnology.BookPricingApi.Abstractions;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Mappers;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Queries;
using System;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public class BookPriceQueriesHandler : IBookPriceQueriesHandler
    {
        private readonly IBookPricesRepository _repository;

        public BookPriceQueriesHandler(IBookPricesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<HandleResult> HandleAsync(GetBookPriceQuery query)
        {
            var bookPrice = await _repository.GetOneAsync(query.Id);
            if (bookPrice is null) return HandleResult.NotFound();
            return HandleResult.Success(bookPrice.ToModel());
        }
    }
}
