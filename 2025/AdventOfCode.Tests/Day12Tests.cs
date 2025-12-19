public class Day12Tests
{
	private const string input = """
	                             0:
	                             ###
	                             ##.
	                             ##.

	                             1:
	                             ###
	                             ##.
	                             .##

	                             2:
	                             .##
	                             ###
	                             ##.

	                             3:
	                             ##.
	                             ###
	                             ##.

	                             4:
	                             ###
	                             #..
	                             ###

	                             5:
	                             ###
	                             .#.
	                             ###

	                             4x4: 0 0 0 0 2 0
	                             12x5: 1 0 1 0 2 2
	                             12x5: 1 0 1 0 3 2
	                             """;

	private readonly Day12 puzzle = new Day12();

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