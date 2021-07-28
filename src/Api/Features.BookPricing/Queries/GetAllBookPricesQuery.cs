using System;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Queries
{
    public class FindAllBookPricesQuery
    {
        public Guid BookId { get; set; }

        public FindAllBookPricesQuery(Guid id)
        {
            BookId = id;
        }
    }
}
