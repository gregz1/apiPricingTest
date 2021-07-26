using CTechnology.BookPricingApi.Api.Features.BookPricing.Commands;
using System;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public class BookPriceCommandsHandler : IBookPriceCommandsHandler
    {
        public BookPriceCommandsHandler()
        {

        }

        public Task<HandleResult> HandleAsync(CreateBookPriceCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
