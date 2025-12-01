public class Day4Tests : PuzzleTest<Day4>
{
	[Fact]
	public void Part1_Example()
	{
		string[] inputLines =
		{
			"2-4,6-8",
			"2-3,4-5",
			"5-7,7-9",
			"2-8,3-7",
			"6-6,4-6",
			"2-6,4-8"
		};

		// The number of assignment pairs in which one range
		// fully contains the other.
		Puzzle puzzle = CreateFromLines(inputLines);
		var pairCount = puzzle.SolutionPart1();
		Assert.Equal(2, pairCount);
	}

	[Fact]
	public void GetRange()
	{
		Range range = Day4.GetRange("9-42");
		Assert.Equal(9, range.Start);
		Assert.Equal(42, range.End);
	}

	[Fact]
	public void GetRanges()
	{
		(Range a, Range b) = Day4.GetRanges("9-42,11-17");
		Assert.Equal(9, a.Start);
		Assert.Equal(42, a.End);

		Assert.Equal(11, b.Start);
		Assert.Equal(17, b.End);
	}

	[Fact]
	public void Part1_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(494, result);
	}

	[Fact]
	public void Part2_Example()
	{
		string[] inputLines =
		{
			"2-4,6-8",
			"2-3,4-5",
			"5-7,7-9",
			"2-8,3-7",
			"6-6,4-6",
			"2-6,4-8"
		};

		// 1-2, 3-4
		// 3-4, 1-2
		// 1-3, 2-4  A
		// 3-5, 2-4  B
		// 2-4, 1-3  C
		// 2-4, 3-5  D

		// The number of overlapping pairs.
		Puzzle puzzle = CreateFromLines(inputLines);
		var pairCount = puzzle.SolutionPart2();
		Assert.Equal(4, pairCount);
	}

	[Fact]
	public void Part2_CustomExample()
	{
		string[] inputLines =
		{
			"1-1,1-1",
			"1-3,1-1",
			"1-4,3-5",
		};

		// The number of overlapping pairs.
		Puzzle puzzle = CreateFromLines(inputLines);
		var pairCount = puzzle.SolutionPart2();
		Assert.Equal(3, pairCount);
	}

	[Fact]
	public void Part2_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(833, result);
	}
}