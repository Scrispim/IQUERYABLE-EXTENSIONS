using BookStore.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositores.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositores
{
	public class BooksRepository : IBooksRepository
	{
		public IList<BooksEntity> GetAll() => DataSource.GetBooksEntity();
		public BooksEntity Get(string id) => DataSource.GetBooksEntityById(id);

		public BooksEntity Insert(BooksEntity booksentity) => DataSource.AddBooksEntity(booksentity);

		public BooksEntity Update(BooksEntity booksentity) => DataSource.UpdateBooksEntity(booksentity);
		public bool Delete(string id) => DataSource.DeleteBooksEntity(id);
	}
}
