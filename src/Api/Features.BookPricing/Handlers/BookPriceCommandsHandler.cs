using CTechnology.BookPricingApi.Abstractions;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Commands;
using CTechnology.BookPricingApi.Domain;
using System;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public class BookPriceCommandsHandler : IBookPriceCommandsHandler
    {
        private readonly IBookPricesRepository _repository;

        public BookPriceCommandsHandler(IBookPricesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<HandleResult> HandleAsync(CreateBookPriceCommand command)
        {
            var bookPrice = BookPrice.CreateNew(command.BookId, command.Value, (Currency)command.Currency);
            await _repository.SaveAsync(bookPrice);
            return HandleResult.Success((Guid)bookPrice.Price.Id);
        }
    }
}
