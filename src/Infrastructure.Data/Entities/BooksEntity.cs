using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Data.Entities
{
	public class BooksEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
		public BooksEntity()
		{
			Id = Guid.NewGuid();
		}

		public void AddBook(string isbn, string tilte, string author, decimal price)
		{
			ISBN = isbn;
			Title = tilte;
			Author = author;
			Price = price;
		}
	}
}
