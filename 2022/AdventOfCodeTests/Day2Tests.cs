public class Day2Tests : PuzzleTest<Day2>
{
	[Fact]
	public void Part1_Example()
	{
		// A = Rock     = X, 1 Points
		// B = Paper    = Y, 2 Points
		// C = Scissors = Z, 3 Points
		// Lost = 0
		// Draw = 3
		// Won = 6
		// RoundScore = Shape + Outcome

		string[] inputLines =
		{
			"A Y", // 2 + 6 = 8
			"B X", // 1 + 0 = 1
			"C Z" // 3 + 3 = 6
		};
		Puzzle puzzle = CreateFromLines(inputLines);
		var result = puzzle.SolutionPart1();
		Assert.Equal(15L, result);
	}

	[Fact]
	public void Part1_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(13052L, result);
	}

	[Fact]
	public void Part2_Example()
	{
		// X = need to lose
		// Y = draw
		// Z = need to win

		string[] inputLines =
		{
			"A Y", // Chose rock (A) to end in draw 1 + 3 = 4
			"B X", // Chose rock (A) to lose 1 + 0 = 1
			"C Z" // Chose rock (A) to win 1 + 6 = 7
		};
		Puzzle puzzle = CreateFromLines(inputLines);
		var result = puzzle.SolutionPart2();
		Assert.Equal(12L, result);
	}

	[Fact]
	public void Part2_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(13693L, result);
	}
}