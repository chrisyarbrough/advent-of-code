public class Day13Tests : PuzzleTest<Day13>
{
	[Fact]
	public void Part1_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(13, result);
	}

	[Fact]
	public void Pairs()
	{
		var puzzle = CreateFromFile("Example");
		Assert.Equal(8, puzzle.Pairs().Count());
		Assert.Equal("[[1],[2,3,4]]", puzzle.Pairs().ElementAt(1).Item1);
		Assert.Equal("[[1],4]", puzzle.Pairs().ElementAt(1).Item2);
	}

	[Fact]
	public void Part1_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(5684, result);
	}

	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(140, result);
	}

	[Fact]
	public void Part2_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(22932, result);
	}
}