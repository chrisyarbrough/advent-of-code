public class Day7Tests
{
	private readonly Day7 puzzle = new Day7
	{
		RenderGrid = () =>
		{
			// Disable grid rendering in tests.
		},
	};

	[Fact]
	public void Part1_Example()
	{
		puzzle.InputFileName = "example.txt";
		var result = puzzle.Solve(p => p.Part1);
		Assert.Equal(21, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		puzzle.InputFileName = "input.txt";
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(1566, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		puzzle.InputFileName = "example.txt";
		var result = puzzle.Solve(p => p.Part2);
		Assert.Equal(40, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		puzzle.InputFileName = "input.txt";
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}