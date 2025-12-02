public class Day2Tests
{
	[Fact]
	public void Part1_Example()
	{
		const string input =
			"11-22,95-115,998-1012,1188511880-1188511890,222220-222224," +
			"1698522-1698528,446443-446449,38593856-38593862,565653-565659," +
			"824824821-824824827,2121212118-2121212124";
		long result = (long)new Day2().Part1(input);
		Assert.Equal(1227775554, result);
	}

	[Theory]
	[InlineData("11")]
	[InlineData("22")]
	[InlineData("99")]
	public void Examples_TwoDigits_Invalid(string input)
	{
		Assert.False(Day2.IsValidID_Part1(input));
	}

	[Theory]
	[InlineData("15")]
	[InlineData("21")]
	[InlineData("98")]
	public void Examples_TwoDigits_Valid(string input)
	{
		Assert.True(Day2.IsValidID_Part1(input));
	}

	[Theory]
	[InlineData("1010")]
	[InlineData("1188511885")]
	[InlineData("222222")]
	[InlineData("446446")]
	[InlineData("38593859")]
	public void Examples_MoreDigits(string input)
	{
		Assert.False(Day2.IsValidID_Part1(input));
	}

	[Fact]
	public void Part1_Solution()
	{
		long result = (long)new Day2().Solve(p => p.Part1);
		Assert.Equal(41294979841, result);
	}

	[Fact]
	public void Part2_Example()
	{
		const string input =
			"11-22,95-115,998-1012,1188511880-1188511890,222220-222224," +
			"1698522-1698528,446443-446449,38593856-38593862,565653-565659," +
			"824824821-824824827,2121212118-2121212124";
		long result = (long)new Day2().Part2(input);
		Assert.Equal(4174379265, result);
	}

	[Theory]
	[InlineData("11")]
	[InlineData("22")]
	[InlineData("99")]
	[InlineData("111")]
	[InlineData("999")]
	[InlineData("1010")]
	[InlineData("123123123")]
	[InlineData("1188511885")]
	[InlineData("222222")]
	[InlineData("446446")]
	[InlineData("38593859")]
	[InlineData("565656")]
	[InlineData("824824824")]
	[InlineData("2121212121")]
	public void Examples_MoreDigits_Part2(string input)
	{
		Assert.False(Day2.IsValidID_Part2(input));
	}

	[Theory]
	[InlineData("17")]
	[InlineData("123")]
	[InlineData("21")]
	[InlineData("1000")]
	[InlineData("1325")]
	[InlineData("956485")]
	[InlineData("222220")]
	public void Examples_Valid_Part2(string input)
	{
		Assert.True(Day2.IsValidID_Part2(input));
	}

	[Fact]
	public void Part2_Solution()
	{
		long result = (long)new Day2().Solve(p => p.Part2);
		Assert.Equal(66500947346, result);
	}
}