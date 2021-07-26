using System;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Queries
{
    public class GetBookPriceQuery
    {
        public Guid Id { get; set; }

        public GetBookPriceQuery(Guid id)
        {
            Id = id;
        }
    }
}
