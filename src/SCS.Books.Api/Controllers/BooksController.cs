using BookStore.Data;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SCS.Books.Api.Extension;
using SCS.Books.Api.Controllers.Request;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using AspNetCore.IQueryable.Extensions;

namespace BookStore.Controllers
{
    [Route("api/Books")]
	public class BooksController : Controller
	{
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    //context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        // Return all books
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            var books = _db.Books;
            return Ok(books);
        }

        // Returns a specific book given its key
        [Route("GetBook")]
        [HttpGet]
        public IActionResult Get(int key)
        {
            var book = _db.Books.FirstOrDefault(c => c.Id == key);

            return Ok(book);
        }

        [Route("GetFilter")]
        [HttpGet]
        public async Task<IActionResult> GetByTitle([FromQuery] BookRequest query)
        {
            var books1 = await _db.Books.AsQueryable().Filter(query).Paginate(query).Sort(query).ToListAsync();
            var books = await _db.Books.AsQueryable().Apply(query).ToListAsync();

            //if (title.IsExists()) {
            //    queryBooks = queryBooks.Where(c => c.Title == title);
            //}

            //var books = await queryBooks.ToListAsync();

            return Ok(books);
        }
        // Create a new book
        [Route("PostBook")]
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(book);
        }
    }
}
