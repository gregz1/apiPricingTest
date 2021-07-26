using System;

namespace CTechnology.BookPricingApi.Domain
{
    public class BookPrice
    {
        public Guid BookId { get; set; }

        public Price Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
