using Bogus;
using BookStore.Contract;
using BookStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data
{
	public static class DataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            // book #1
            Book book = new Book();

            for (int i = 1; i < 100; i++)
            {
                // Fake Item
                var ids = i;
                decimal min = 50m;
                decimal max = 10000m;
                int decimals = 2;
                book = new Faker<Book>("pt_BR")
                    .RuleFor(x => x.Id, f => ids)
                    .RuleFor(x => x.ISBN, f => f.Finance.CreditCardNumber())
                    .RuleFor(x => x.Title, f => f.Company.CompanyName())
                    .RuleFor(x => x.Author, f => f.Person.FullName)
                    .RuleFor(x => x.Price, f => f.Commerce.Price(min, max, decimals).FirstOrDefault());
                    //.RuleFor(x => x.Location, f => new Address { City = f.Address.City(), Street = f.Address.StreetName() })
                    //.RuleFor(x => x.Press, f => new Press { Id = ids, Name = f.Commerce.ProductName(), Category = ICategory.EBook });

                // generate 1000 items
                _books.Add(book);
            }
            

            return _books;
        }
    }
}
