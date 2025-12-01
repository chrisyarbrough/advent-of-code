public class Day5Tests : PuzzleTest<Day5>
{
	[Fact]
	public void Part1_Example()
	{
		Day5 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal("CMZ", result);
	}

	[Fact]
	public void Part1_Input()
	{
		Day5 puzzle = CreateFromFile("Input");
		var message = puzzle.SolutionPart1();
		Assert.Equal("VRWBSFZWM", message);
	}

	[Fact]
	public void Part2_Example()
	{
		Day5 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal("MCD", result);
	}

	[Fact]
	public void Part2_Input()
	{
		Day5 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal("RBTWJWMCF", result);
	}
}