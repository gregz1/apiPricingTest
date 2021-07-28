using System;

namespace CTechnology.BookPricingApi.Domain
{
    public class BookPrice
    {
        public Guid BookId { get; set; }

        public Price Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public static BookPrice CreateNew(
            Guid bookId,
            decimal value,
            Currency currency
            ) =>
            new BookPrice
            {
                BookId = bookId,
                Price = new Price { 
                    Id = Guid.NewGuid(), 
                    Value = value, 
                    Currency = currency, 
                    Symbol = currency is Currency.EUR ? "\u20AC" : currency is Currency.USD ? "$" : "",
                    Raw = string.Format("{0}{1}", value.ToString(), currency is Currency.EUR ? "\u20AC" : currency is Currency.USD ? "$" : "")
                },
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
    }
}
