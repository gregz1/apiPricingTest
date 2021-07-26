using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Models
{
    public class BookPrice
    {
        public Price Price { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
