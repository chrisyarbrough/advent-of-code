public class Day11Tests
{
	// Device name: outputs
	// Start with "you"
	// End with "out"
	// Find every path from start to end
	private const string input = """
	                             aaa: you hhh
	                             you: bbb ccc
	                             bbb: ddd eee
	                             ccc: ddd eee fff
	                             ddd: ggg
	                             eee: out
	                             fff: out
	                             ggg: out
	                             hhh: ccc fff iii
	                             iii: out
	                             """;

	private readonly Day11 puzzle = new Day11();

	[Fact]
	public void Part1_Example()
	{
		var result = puzzle.Part1(input);
		Assert.Equal(5, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(506, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		var result = puzzle.Part2(input);
		Assert.Equal("XMAS", result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}