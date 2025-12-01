using Day14Namespace;

namespace AdventOfCode.Day15.Tests;

public class Day15Tests : PuzzleTest<Day15>
{
	[Fact]
	public void Part1_Example()
	{
		var puzzle = CreateFromFile("Example");
		puzzle.QueriedRow = 10;
		var result = puzzle.SolutionPart1();
		Assert.Equal(26, result);
	}

	[Fact]
	public void Part1_Input()
	{
		var puzzle = CreateFromFile("Input");
		puzzle.QueriedRow = 2_000_000;
		var result = puzzle.SolutionPart1();
		Assert.Equal(6275922, result);
	}

	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		puzzle.StartingRect = new Rect(0, 0, 20, 20);
		// Beacon: (14, 11)
		var result = puzzle.SolutionPart2();
		Assert.Equal(56000011L, result);
	}

	[Fact]
	public void TuningFrequency()
	{
		Assert.Equal(56000011L, Day15.TuningFrequency(new Coord(14, 11)));
	}

	[Fact]
	public void Part2_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(11747175442119, result);
	}

	[Fact]
	public void ParseInput()
	{
		var puzzle = CreateFromFile("Example");
		Assert.Equal((new Coord(2, 18), new Coord(-2, 15)), puzzle.ParseInput().First());
	}

	[Theory]
	[InlineData(0, 0, 5, 5, 10)]
	public void ManhattenDistance(int x0, int y0, int x1, int y1, int distance)
	{
		Assert.Equal(distance, Day15.ManhattenDistance(
			new Coord(x0, y0), new Coord(x1, y1)));
	}

	[Fact]
	public void SplitRect_Even()
	{
		var rect = new Rect(0, 0, 4, 4);
		Assert.True(rect.Split().Any(r => r == new Rect(0, 0, 2, 2)));
		Assert.True(rect.Split().Any(r => r == new Rect(2, 0, 2, 2)));
		Assert.True(rect.Split().Any(r => r == new Rect(0, 2, 2, 2)));
		Assert.True(rect.Split().Any(r => r == new Rect(2, 2, 2, 2)));
	}

	[Fact]
	public void SplitRect_Even2()
	{
		var rect = new Rect(0, 0, 2, 2);
		Assert.True(rect.Split().Any(r => r == new Rect(0, 0, 1, 1)));
		Assert.True(rect.Split().Any(r => r == new Rect(1, 0, 1, 1)));
		Assert.True(rect.Split().Any(r => r == new Rect(0, 1, 1, 1)));
		Assert.True(rect.Split().Any(r => r == new Rect(1, 1, 1, 1)));
	}

	[Fact]
	public void SplitRect_Odd()
	{
		// TODO: Test width != height
		var rect = new Rect(0, 0, 5, 5);
		Assert.True(rect.Split().Any(r => r == new Rect(0, 0, 2, 2)));
		Assert.True(rect.Split().Any(r => r == new Rect(2, 0, 3, 2)));
		Assert.True(rect.Split().Any(r => r == new Rect(0, 2, 2, 3)));
		Assert.True(rect.Split().Any(r => r == new Rect(2, 2, 3, 3)));
	}
}