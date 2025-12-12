public class Day10Tests
{
	private const string input = """
	                             [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
	                             [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
	                             [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
	                             """;

	private readonly Day10 puzzle = new Day10();

	[Fact]
	public void Part1_Example()
	{
		var result = puzzle.Part1(input);
		Assert.Equal(7, result);
	}

	[Fact]
	public void Part1_Example_Line1()
	{
		// [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
		// You could press the first three buttons once each, a total of 3 button presses.
		// You could press (1,3) once, (2,3) once, and (0,1) twice, a total of 4 button presses.
		// You could press all the buttons except (1,3) once each, a total of 5 button presses.
		var result = puzzle.Part1("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}");
		Assert.Equal(2, result);
	}

	[Fact]
	public void Part1_Example_Line2()
	{
		// One way to achieve this is by pressing the last three buttons ((0,4), (0,1,2), and (1,2,3,4)) once each.
		var result = puzzle.Part1("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
		Assert.Equal(3, result);
	}

	[Fact]
	public void Part1_Example_Line3()
	{
		// The fewest presses required to correctly configure it is 2; one way to do this is by pressing buttons (0,3,4) and (0,1,2,4,5) once each.
		var result = puzzle.Part1("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}");
		Assert.Equal(2, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(375, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		var result = puzzle.Part2(input);
		Assert.Equal("XMAS", result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}