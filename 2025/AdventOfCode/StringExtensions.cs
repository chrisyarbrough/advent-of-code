public static class StringExtensions
{
	public static string[] Lines(this string input)
	{
		return input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
	}
}