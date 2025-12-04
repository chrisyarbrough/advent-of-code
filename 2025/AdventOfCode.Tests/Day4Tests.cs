public class Day4Tests
{
	private Day4 day4 = new Day4()
	{
		RenderGrid = () =>
		{
			// Disabled for tests.
		},
	};

	private const string exampleInput = """
	                                    ..@@.@@@@.
	                                    @@@.@.@.@@
	                                    @@@@@.@.@@
	                                    @.@@@@..@.
	                                    @@.@@@@.@@
	                                    .@@@@@@@.@
	                                    .@.@.@.@@@
	                                    @.@@@.@@@@
	                                    .@@@@@@@@.
	                                    @.@.@@@.@.
	                                    """;

	[Fact]
	public void Part1_Example()
	{
		Assert.Equal(13, day4.Part1(exampleInput));
	}

	[Fact]
	public void Part1_Solution()
	{
		Assert.Equal(1502, day4.Solve(p => p.Part1));
	}

	[Fact]
	public void Part2_Example()
	{
		Assert.Equal(43, day4.Part2(exampleInput));
	}

	[Fact]
	public void Part2_Solution()
	{
		Assert.Equal(9083, day4.Solve(p => p.Part2));
	}
}