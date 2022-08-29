using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace SCS.Books.Api.Controllers.Request
{
	public class BookRequestFilter : ICustomQueryable, IQueryPaging, IQuerySort
	{
		[QueryOperator(Operator = WhereOperator.Contains)]
		//public int Id { get; set; }

		
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		//public decimal Price { get; set; }


		public int? Limit { get; set; } = 10;
		public int? Offset {get; set; }
		public string Sort { get; set; }
	}
}
