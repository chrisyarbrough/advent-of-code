public class Day9Tests
{
	private const string input = """
	                             7,1
	                             11,1
	                             11,7
	                             9,7
	                             9,5
	                             2,5
	                             2,3
	                             7,3
	                             """;

	private readonly Day9 puzzle = new Day9();

	public Day9Tests()
	{
		puzzle.Renderer.Enabled = false;
	}

	[Fact]
	public void Part1_Example()
	{
		// ..............
		// .......#...#..
		// ..............
		// ..#....#......
		// ..............
		// ..#......#....
		// ..............
		// .........#.#..
		// ..............
		var result = puzzle.Part1(input);
		Assert.Equal(50L, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(4743645488L, solution);
		Assert.NotEqual(2147410078L, solution); // too low
	}

	[Fact]
	public void Part2_Example()
	{
		var result = puzzle.Part2(input);
		Assert.Equal(24L, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}