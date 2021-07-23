using CTechnology.BookPricingApi.Api.Features.BookPricing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Commands
{
    public class CreateBookPriceCommand
    {
        public Guid BookId { get; set; }

        public decimal Value { get; set; }

        public Currency Currency { get; set; }
    }
}
