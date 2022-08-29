namespace SCS.Books.Api.Extension
{
	public static class StringExtension
	{
		public static bool IsExists(this string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}
	}
}
