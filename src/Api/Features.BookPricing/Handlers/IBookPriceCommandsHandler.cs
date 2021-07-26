using CTechnology.BookPricingApi.Api.Features.BookPricing.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public interface IBookPriceCommandsHandler
    {
        Task<HandleResult> HandleAsync(CreateBookPriceCommand command);
    }
}
