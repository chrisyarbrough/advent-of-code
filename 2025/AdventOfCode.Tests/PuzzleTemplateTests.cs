public class PuzzleTemplateTests
{
	private readonly Puzzle puzzle = new Day();

	[Fact]
	public void Part1_Example()
	{
		const string input = """
		                     
		                     """;
		var result = puzzle.Part1(input);
		Assert.Equal("XMAS", result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(0, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		const string input = """
		                     
		                     """;
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