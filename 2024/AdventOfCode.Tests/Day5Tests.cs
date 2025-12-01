public class Day5Tests
{
	public const string example = """
	                              47|53
	                              97|13
	                              97|61
	                              97|47
	                              75|29
	                              61|13
	                              75|53
	                              29|13
	                              97|29
	                              53|29
	                              61|53
	                              97|53
	                              61|29
	                              47|13
	                              75|47
	                              97|75
	                              47|61
	                              75|61
	                              47|29
	                              75|13
	                              53|13

	                              75,47,61,53,29
	                              97,61,53,29,13
	                              75,29,13
	                              75,97,47,61,53
	                              61,13,29
	                              97,13,75,29,47
	                              """;

	private Day5 day5 = new();

	[Fact]
	public void Part1_Example()
	{
		Assert.Equal(143, day5.Part1(example));
	}

	[Theory]
	[InlineData("75,47,61,53,29", 61)]
	[InlineData("97,61,53,29,13", 53)]
	[InlineData("75,29,13", 29)]
	public void FindMiddlePageNumber(string input, int number)
	{
		int[] pageNumbers = input.Split(",").Select(int.Parse).ToArray();
		Assert.Equal(number, Day5.FindMiddlePageNumber(pageNumbers));
	}

	[Fact]
	public void Part1_Solution()
	{
		Assert.Equal(5713, day5.Solve(p => p.Part1));
	}

	[Fact]
	public void Part2_Example()
	{
		Assert.Equal(123, day5.Part2(example));
	}

	[Theory]
	[InlineData("75,97,47,61,53", "97,75,47,61,53")]
	[InlineData("61,13,29", "61,29,13")]
	[InlineData("97,13,75,29,47", "97,75,47,29,13")]
	public void FixOrder(string incorrect, string corrected)
	{
		Day5.ParseInput(example, out _, out (int, int)[] orderingRules);
		int[] update = incorrect.Split(",").Select(int.Parse).ToArray();
		IEnumerable<int> result = Day5.FixOrder(update, orderingRules);
		int[] expected = corrected.Split(",").Select(int.Parse).ToArray();
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData("75,97,47,61,53", "97,75,47,61,53")]
	[InlineData("61,13,29", "61,29,13")]
	[InlineData("97,13,75,29,47", "97,75,47,29,13")]
	public void FixOrder2(string incorrect, string corrected)
	{
		Day5.ParseInput(example, out _, out (int, int)[] orderingRules);
		int[] update = incorrect.Split(",").Select(int.Parse).ToArray();
		IEnumerable<int> result = Day5.FixOrder(update, orderingRules);
		int[] expected = corrected.Split(",").Select(int.Parse).ToArray();
		Assert.Equal(expected, result);
	}

	[Fact]
	public void SimpleSorting()
	{
		int[] sorted = Day5.SimpleSort([3, 1, 5, 4, 2]);
		Assert.Equal([1, 2, 3, 4, 5], sorted);
	}

	[Fact]
	public void Part2_Solution()
	{
		Assert.Equal(5180, day5.Solve(p => p.Part2));
	}
}