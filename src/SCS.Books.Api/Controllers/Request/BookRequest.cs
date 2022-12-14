using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using System;

namespace SCS.Books.Api.Controllers.Request
{
	public class BookRequest
	{		
		public Guid Id { get; set; }		
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
	}
}
