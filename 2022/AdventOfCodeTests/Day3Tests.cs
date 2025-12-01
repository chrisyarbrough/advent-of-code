public class Day3Tests : PuzzleTest<Day3>
{
	[Fact]
	public void Part1_Example()
	{
		string[] inputLines =
		{
			"vJrwpWtwJgWrhcsFMMfFFhFp",
			"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
			"PmmdzqPrVvPwwTWBwg",
			"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
			"ttgJtRGJQctTZtZT",
			"CrZsJsPPZsGzwwsLwLmpwMDw"
		};

		Puzzle puzzle = CreateFromLines(inputLines);
		var result = puzzle.SolutionPart1();
		Assert.Equal(157, result);
	}

	[Theory]
	[InlineData('p', 16)]
	[InlineData('L', 38)]
	[InlineData('P', 42)]
	[InlineData('v', 22)]
	[InlineData('t', 20)]
	[InlineData('s', 19)]
	public void GetPriority(char c, int expected)
	{
		int result = Day3.GetPriority(c);
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Part1_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(7691, result);
	}

	[Fact]
	public void Part2_Example()
	{
		string[] inputLines =
		{
			"vJrwpWtwJgWrhcsFMMfFFhFp",
			"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
			"PmmdzqPrVvPwwTWBwg",

			"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
			"ttgJtRGJQctTZtZT",
			"CrZsJsPPZsGzwwsLwLmpwMDw"
		};
		// First group of 3 lines:
		// Only r appears in all three. This is the badge.
		// Priority: 18

		// Second group:
		// Badge item type must be Z.
		// Priority: 52
		// Total: 70

		Puzzle puzzle = CreateFromLines(inputLines);
		var result = puzzle.SolutionPart2();
		Assert.Equal(70, result);
	}

	[Fact]
	public void Part2_Input()
	{
		Puzzle puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(2508, result);
	}
}