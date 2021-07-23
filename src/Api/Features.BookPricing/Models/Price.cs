using System;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Models
{
    public class Price
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Currency Currency { get; set; }

        public string Symbol { get; set; }

        public string Raw { get; set; }
    }
}
