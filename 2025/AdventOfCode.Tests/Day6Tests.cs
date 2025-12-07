public class Day6Tests
{
	// Part 2
	// The rightmost problem is 4 + 431 + 623 = 1058
	// The second problem from the right is 175 * 581 * 32 = 3253600
	// The third problem from the right is 8 + 248 + 369 = 625
	// Finally, the leftmost problem is 356 * 24 * 1 = 8544
	private const string input = """
	                             123 328  51 64 
	                              45 64  387 23 
	                               6 98  215 314
	                             *   +   *   +  
	                             """;

	private readonly Puzzle puzzle = new Day6();

	[Fact]
	public void Part1_Example()
	{
		var result = puzzle.Part1(input);
		Assert.Equal(4277556L, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(5977759036837L, solution);
		Assert.NotEqual(42114233765L, solution); // too low (because mul op requires long)
	}

	[Fact]
	public void Part2_Example()
	{
		var result = puzzle.Part2(input);
		Assert.Equal(3263827L, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(9630000828442L, solution);
	}
}