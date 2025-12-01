public class Day6Tests : PuzzleTest<Day6>
{
	[Theory]
	[InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
	[InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
	[InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
	[InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
	[InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
	public void Part1_Example(string input, int expectedPosition)
	{
		Day6 puzzle = CreateFromText(input);
		var result = puzzle.SolutionPart1();
		Assert.Equal(expectedPosition, result);
	}

	[Fact]
	public void Part1_Input()
	{
		Day6 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(1566, result);
	}

	[Theory]
	[InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
	[InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
	[InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
	[InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
	[InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
	public void Part2_Example(string input, int expectedPosition)
	{
		Day6 puzzle = CreateFromText(input);
		var result = puzzle.SolutionPart2();
		Assert.Equal(expectedPosition, result);
	}

	[Fact]
	public void Part2_Input()
	{
		Day6 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(2265, result);
	}
}