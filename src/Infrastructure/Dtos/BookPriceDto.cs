using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Dtos
{
    public class BookPriceDto
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public decimal Value { get; set; }

        public CurrencyDto Currency { get; set; }

        public string Symbol { get; set; }

        public string Raw { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
