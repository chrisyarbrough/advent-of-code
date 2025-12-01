public class Day2Tests
{
	private readonly string example = """
	                                    7 6 4 2 1
	                                    1 2 7 8 9
	                                    9 7 6 2 1
	                                    1 3 2 4 5
	                                    8 6 4 4 1
	                                    1 3 6 7 9
	                                    """;

	[Fact]
	public void Part1_Example()
	{
		object solution = new Day2().Part1(example);
		Assert.Equal(2, solution);
	}

	[Fact]
	public void Part1_Solution()
	{
		object solution = new Day2().Solve(p => p.Part1);
		Assert.Equal(306, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		object solution = new Day2().Part2(example);
		Assert.Equal(4, solution);
	}

	[Fact]
	public void Part2_Solution()
	{
		object solution = new Day2().Solve(p => p.Part2);
		Assert.Equal(366, solution);
	}
}