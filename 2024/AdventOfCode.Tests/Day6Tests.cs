public class Day6Tests
{
	private const string example = """
	                               ....#.....
	                               .........#
	                               ..........
	                               ..#.......
	                               .......#..
	                               ..........
	                               .#..^.....
	                               ........#.
	                               #.........
	                               ......#...
	                               """;

	private Day6 puzzle = new Day6 { Renderer = new NullRenderer() };

	[Fact]
	public void Part1_Example()
	{
		Assert.Equal(41, puzzle.Part1(example));
	}

	[Fact]
	public void Part1_Solution()
	{
		Assert.Equal(5461, puzzle.Solve(p => p.Part1));
	}

	[Fact]
	public void Part2_Example()
	{
		Assert.Equal(6, puzzle.Part2(example));
	}

	[Fact]
	public void Part2_Solution()
	{
		Assert.Equal(1836, puzzle.Solve(p => p.Part2));
	}
}