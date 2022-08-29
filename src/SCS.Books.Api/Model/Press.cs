using BookStore.Contract;

namespace BookStore.Model
{
	public class Press : IPress
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public ICategory Category { get; set; }
	}
}
