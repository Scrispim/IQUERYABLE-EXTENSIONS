using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositores.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCS.Books.Api.Controllers.Request;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
	[Route("api/Books")]
    [ApiController]
	public class BooksController : Controller
	{
        private readonly IBooksRepository _bookReository;

        public BooksController(IBooksRepository bookReository)
        {
            _bookReository = bookReository;
        }

        // Return all books
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookReository.GetAll();
            return Ok(books);
        }

        // Returns a specific book given its key
        [Route("GetBook")]
        [HttpGet]
        public IActionResult Get(string key)
        {
            var book = _bookReository.Get(key);

            return Ok(book);
        }

        [Route("GetFilter")]
        [HttpGet]
        public async Task<IActionResult> GetSearch([FromQuery] BookRequestFilter query)
        {
            var booksList = _bookReository.GetAll().ToList().AsQueryable();//.Filter(query).Paginate(query).Sort(query).ToListAsync();
            var books = await booksList.Apply(query).ToListAsync();

            //if (title.IsExists()) {
            //    queryBooks = queryBooks.Where(c => c.Title == title);
            //}

            //var books = await queryBooks.ToListAsync();

            return Ok(books);
        }
        // Create a new book
        [Route("CreateBook")]
        [HttpPost]
        public IActionResult Create([FromBody] BookRequest book)
        {
            var entity = new BooksEntity();

            entity.Author = book.Author;
            entity.ISBN = book.ISBN;
            entity.Title = book.Title;
            entity.Price = book.Price;


            _bookReository.Insert(entity);
           
            return Ok(book);
        }

        // Update a book
        [Route("UpdateBook")]
        [HttpPost]
        public IActionResult Update([FromBody] BookRequest book)
        {
            var entity = new BooksEntity();
            entity.Id = book.Id;
            entity.Author = book.Author;
            entity.ISBN = book.ISBN;
            entity.Title = book.Title;
            entity.Price = book.Price;


            _bookReository.Update(entity);

            return Ok(book);
        }

        // Update a book
        [Route("DeleteBook")]
        [HttpPost]
        public IActionResult Delete(string id)
        {           

            return Ok(_bookReository.Delete(id));
        }
    }
}
