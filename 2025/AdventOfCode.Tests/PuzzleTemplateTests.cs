public class PuzzleTemplateTests
{
	private const string input = """

	                             """;

	private readonly PuzzleTemplate puzzle = new PuzzleTemplate();

	[Fact]
	public void Part1_Example()
	{
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