public class Day11Tests
{
	private readonly Day11 puzzle = new Day11();

	[Fact]
	public void Part1_Example()
	{
		// Device name: outputs
		// Start with "you".
		// End with "out".
		// Find every path from start to end.
		const string input = """
		                     aaa: you hhh
		                     you: bbb ccc
		                     bbb: ddd eee
		                     ccc: ddd eee fff
		                     ddd: ggg
		                     eee: out
		                     fff: out
		                     ggg: out
		                     hhh: ccc fff iii
		                     iii: out
		                     """;

		var result = puzzle.Part1(input);
		Assert.Equal(5, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(506, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		// Find every path from svr to out.
		// But the paths need to visit dac and fft.
		const string input = """
		                     svr: aaa bbb
		                     aaa: fft
		                     fft: ccc
		                     bbb: tty
		                     tty: ccc
		                     ccc: ddd eee
		                     ddd: hub
		                     hub: fff
		                     eee: dac
		                     dac: fff
		                     fff: ggg hhh
		                     ggg: out
		                     hhh: out
		                     """;
		var result = puzzle.Part2(input);
		Assert.Equal(2, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}