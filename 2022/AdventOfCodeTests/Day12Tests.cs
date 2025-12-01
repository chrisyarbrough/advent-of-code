public class Day12Tests : PuzzleTest<Day12>
{
	[Fact]
	public void Part1_Example()
	{
		// Standard path finding (e.g. Breadth First).
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();

		// Why does this fail? My answer is 25 and the actual input works.
		Assert.Equal(31, result);
	}

	[Fact]
	public void Part1_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(528, result);
	}

	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(29, result);
	}

	[Fact]
	public void Part2_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(522, result);
	}
}