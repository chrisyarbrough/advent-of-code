using Coord = Day9.Coord;

public class Day9Tests : PuzzleTest<Day9>
{
	[Fact]
	public void Part1_Example()
	{
		string[] input =
		{
			"R 4",
			"U 4",
			"L 3",
			"D 1",
			"R 4",
			"D 1",
			"L 5",
			"R 2"
		};
		Day9 puzzle = CreateFromLines(input);
		var visitedPositions = puzzle.SolutionPart1();
		Assert.Equal(13, visitedPositions);
	}

	[Fact]
	public void AreTouching()
	{
		Assert.True(Coord.AreTouching(new Coord(0, 0), new Coord(0, 0)));

		Assert.True(Coord.AreTouching(new Coord(1, 0), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(-1, 0), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(0, 1), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(0, -1), new Coord(0, 0)));

		Assert.True(Coord.AreTouching(new Coord(1, 1), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(-1, 1), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(-1, -1), new Coord(0, 0)));
		Assert.True(Coord.AreTouching(new Coord(1, -1), new Coord(0, 0)));

		Assert.False(Coord.AreTouching(new Coord(2, 0), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(-2, 0), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(0, 2), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(0, -2), new Coord(0, 0)));

		Assert.False(Coord.AreTouching(new Coord(2, 2), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(-2, 2), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(-2, -2), new Coord(0, 0)));
		Assert.False(Coord.AreTouching(new Coord(2, -2), new Coord(0, 0)));
	}

	[Fact]
	public void Part1_Input()
	{
		Day9 puzzle = CreateFromFile("Input");
		var visitedPositions = puzzle.SolutionPart1();
		Assert.Equal(6486, visitedPositions);
	}

	[Fact]
	public void Part2_Example1()
	{
		string[] input =
		{
			"R 4",
			"U 4",
			"L 3",
			"D 1",
			"R 4",
			"D 1",
			"L 5",
			"R 2"
		};
		Day9 puzzle = CreateFromLines(input);
		var visitedPositions = puzzle.SolutionPart2();
		Assert.Equal(1, visitedPositions);
	}
	
	[Fact]
	public void Part2_Example2()
	{
		string[] input =
		{
			"R 5",
			"U 8",
			"L 8",
			"D 3",
			"R 17",
			"D 10",
			"L 25",
			"U 20"
		};
		Day9 puzzle = CreateFromLines(input);
		var visitedPositions = puzzle.SolutionPart2();
		Assert.Equal(36, visitedPositions);
	}

	[Fact]
	public void Part2_Input()
	{
		Day9 puzzle = CreateFromFile("Input");
		var visitedPositions = puzzle.SolutionPart2();
		Assert.Equal(2678, visitedPositions);
	}
}