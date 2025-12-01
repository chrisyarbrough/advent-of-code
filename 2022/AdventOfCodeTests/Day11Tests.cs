public class Day11Tests : PuzzleTest<Day11>
{
	[Fact]
	public void Part1_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(10605L, result);
	}
	
	[Fact]
	public void Part1_Input()
	{
		// The crux for the real input is, that it overflows the int, and must use long.
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(112221L, result);
	}
	
	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(2713310158L, result);
	}
	
	[Fact]
	public void Part2_Input()
	{
		// The crux for the real input is, that it overflows the int, and must use long.
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(25272176808, result);
	}
}