public class Day14Tests : PuzzleTest<Day14>
{
	[Fact]
	public void Part1_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(24, result);
	}

	[Fact]
	public void Part1_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(719, result);
	}

	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(93, result);
	}

	[Fact]
	public void Part2_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(23390, result);
	}
}