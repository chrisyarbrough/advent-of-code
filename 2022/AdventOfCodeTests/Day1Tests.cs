public class Day1Tests : PuzzleTest<Day1>
{
	[Fact]
	public void Part1_Example()
	{
		Day1 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(24000L, result);
	}

	[Fact]
	public void Part1_Input()
	{
		Day1 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(67622L, result);
	}

	[Fact]
	public void Part2_Example()
	{
		Day1 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(45000L, result);
	}

	[Fact]
	public void Part2_Input()
	{
		Day1 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(201491L, result);
	}
}