public class Day3Tests
{
	[Fact]
	public void Part1_Example()
	{
		//                          2*4 +                        5*5 +                    11*8 + 8*5
		const string example = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
		Day3 puzzle = new();
		var result = puzzle.Part1(example);
		Assert.Equal(161, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		Day3 puzzle = new();
		var result = puzzle.Solve(p => p.Part1);
		Assert.Equal(183669043, result);
	}

	[Fact]
	public void Part2_Example()
	{
		//                           2*4 +           dont                                 do        8*5
		const string example = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
		Day3 puzzle = new();
		var result = puzzle.Part2(example);
		Assert.Equal(48, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		Day3 puzzle = new();
		var result = puzzle.Solve(p => p.Part2);
		Assert.Equal(59097164, result);
	}
}