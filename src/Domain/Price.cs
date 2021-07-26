using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Domain
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
