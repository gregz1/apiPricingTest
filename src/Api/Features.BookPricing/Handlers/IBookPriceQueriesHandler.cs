using CTechnology.BookPricingApi.Api.Features.BookPricing.Queries;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public interface IBookPriceQueriesHandler
    {
        Task<HandleResult> HandleAsync(GetBookPriceQuery query);
    }
}
