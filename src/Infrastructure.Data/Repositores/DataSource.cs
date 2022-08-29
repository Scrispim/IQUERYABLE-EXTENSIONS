using Bogus;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data
{
	public static class DataSource
    {
        private static IList<BooksEntity> _booksEntity { get; set; }

        public static IList<BooksEntity> GetBooksEntity()
        {
            if (_booksEntity != null)
            {
                return _booksEntity;
            }

            _booksEntity = new List<BooksEntity>();

            for (int i = 1; i < 100; i++)
            {
                // Fake Item
                var ids = i;
                decimal min = 50m;
                decimal max = 10000m;
                int decimals = 2;
                var book = new Faker<BooksEntity>("pt_BR")
                    .RuleFor(x => x.Id, f => Guid.NewGuid())
                    .RuleFor(x => x.ISBN, f => f.Finance.CreditCardNumber())
                    .RuleFor(x => x.Title, f => f.Company.CompanyName())
                    .RuleFor(x => x.Author, f => f.Person.FullName)
                    .RuleFor(x => x.Price, f => f.Commerce.Price(min, max, decimals).FirstOrDefault());

               _booksEntity.Add(book);
            }
            

            return _booksEntity;
        }

        public static BooksEntity GetBooksEntityById(string id)
        {
            return _booksEntity.ToList().FirstOrDefault(x => x.Id.ToString().Equals(id));
        }

        public static BooksEntity AddBooksEntity(BooksEntity booksentity) 
        {
            _booksEntity.Add(booksentity);

            return booksentity;
        }

        public static BooksEntity UpdateBooksEntity(BooksEntity booksentity)
        {
            var book = GetBooksEntityById(booksentity.Id.ToString());

            book.Title = booksentity.Title;
            book.Author = booksentity.Author;
            book.ISBN = booksentity.ISBN;
            book.Price = booksentity.Price;

            return booksentity;
        }

        public static bool DeleteBooksEntity(string id)
        {
            _booksEntity.Remove(GetBooksEntityById(id));

            return true;
        }
    }
}
