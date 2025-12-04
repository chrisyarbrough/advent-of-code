public class Day3Tests
{
	private readonly Day3 day3 = new Day3();

	[Fact]
	public void Part1_Example()
	{
		const string input = """
		                     987654321111111
		                     811111111111119
		                     234234234234278
		                     818181911112111
		                     """;
		Assert.Equal(357L, day3.Part1(input));
	}

	[Theory]
	[InlineData(98L, "987654321111111")]
	[InlineData(89L, "811111111111119")]
	[InlineData(78L, "234234234234278")]
	[InlineData(92L, "818181911112111")]
	public void Part1_FindLargestPossibleJoltage(long expected, string bank)
	{
		// The crux of this part is to realize that we are not searching for the two largest individual digits,
		// but the largest combined number.
		// For example: 8192 -> 8 and 9 are the largest individually, but 92 is larger combined.
		Assert.Equal(expected, day3.FindLargestPossibleJoltage(bank));
	}

	[Fact]
	public void Part1_Solution()
	{
		Assert.Equal(17193L, day3.Solve(p => p.Part1));
	}

	[Fact]
	public void Part2_Example()
	{
		const string input = """
		                     987654321111111
		                     811111111111119
		                     234234234234278
		                     818181911112111
		                     """;
		Assert.Equal(3121910778619L, day3.Part2(input));
	}

	[Theory]
	[InlineData(987654321111L, "987654321111111")]
	[InlineData(811111111119L, "811111111111119")]
	[InlineData(434234234278L, "234234234234278")]
	[InlineData(888911112111L, "818181911112111")]
	public void Part2_FindLargestPossibleJoltage(long expected, string bank)
	{
		// The crux of this part is to realize that we are not searching for the two largest individual digits,
		// but the largest combined number.
		// For example: 8192 -> 8 and 9 are the largest individually, but 92 is larger combined.
		Assert.Equal(expected, day3.FindLargestPossibleJoltage(bank, digits: 12));
	}

	[Theory]
	[InlineData(987L, "498765")]
	[InlineData(444, "4444")]
	public void Part2_ThreeDigits(long expected, string bank)
	{
		var result = day3.FindLargestPossibleJoltage(
			bank,
			digits: 3);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(98L, "987654321111111")]
	[InlineData(89L, "811111111111119")]
	[InlineData(78L, "234234234234278")]
	[InlineData(92L, "818181911112111")]
	public void Part2_TwoDigits(long expected, string bank)
	{
		var result = day3.FindLargestPossibleJoltage(
			bank,
			digits: 2);
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		Assert.Equal(171297349921310L, day3.Solve(p => p.Part2));
	}
}