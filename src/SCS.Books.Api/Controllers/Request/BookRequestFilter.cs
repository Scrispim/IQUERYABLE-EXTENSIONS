using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using System;

namespace SCS.Books.Api.Controllers.Request
{
	public class BookRequestFilter : ICustomQueryable, IQueryPaging, IQuerySort
	{
		[QueryOperator(Operator = WhereOperator.Contains)]
		public string ISBN { get; set; }
		[QueryOperator(Operator = WhereOperator.Contains)]
		public string Title { get; set; }
		[QueryOperator(Operator = WhereOperator.Contains)]
		public string Author { get; set; }
		[QueryOperator(Operator = WhereOperator.GreaterThanOrEqualTo)]
		public decimal Price { get; set; }


		public int? Limit { get; set; } = 10;
		public int? Offset {get; set; }
		public string Sort { get; set; }
	}
}
