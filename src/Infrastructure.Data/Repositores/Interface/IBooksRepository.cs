using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositores.Interface
{
	public interface IBooksRepository
	{
		IList<BooksEntity> GetAll();
		BooksEntity Get(string id);
		BooksEntity Insert(BooksEntity booksentity);
		BooksEntity Update(BooksEntity booksentity);
		bool Delete(string id);
	}
}
