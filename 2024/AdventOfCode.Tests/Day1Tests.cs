public class Day1Tests
{
	private readonly string example = """
	                           3   4
	                           4   3
	                           2   5
	                           1   3
	                           3   9
	                           3   3
	                           """;

	[Fact]
	public void Part1_Example()
	{
		object solution = new Day1().Part1(example);
		Assert.Equal(11, solution);
	}

	[Fact]
	public void Part1_Solution()
	{
		object solution = new Day1().Solve(p => p.Part1);
		Assert.Equal(2378066, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		object solution = new Day1().Part2(example);
		Assert.Equal(31, solution);
	}

	[Fact]
	public void Part2_Solution()
	{
		object solution = new Day1().Solve(p => p.Part2);
		Assert.Equal(18934359, solution);
	}
}