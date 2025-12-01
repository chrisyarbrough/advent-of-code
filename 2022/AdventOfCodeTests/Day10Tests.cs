public class Day10Tests : PuzzleTest<Day10>
{
	[Fact]
	public void Part1_SuperSimpleExample()
	{
		string[] lines =
		{
			"noop",
			"addx 3",
			"addx -5"
		};

		Day10 puzzle = CreateFromLines(lines);

		// Starting values:
		Assert.Equal(0, puzzle.CycleNumber);
		Assert.Equal(1, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(1, puzzle.CycleNumber);
		Assert.Equal(1, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(2, puzzle.CycleNumber);
		Assert.Equal(1, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(3, puzzle.CycleNumber);
		Assert.Equal(1, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(4, puzzle.CycleNumber);
		Assert.Equal(4, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(5, puzzle.CycleNumber);
		Assert.Equal(4, puzzle.RegisterX);

		puzzle.Tick(1);
		Assert.Equal(6, puzzle.CycleNumber);
		Assert.Equal(-1, puzzle.RegisterX);
	}

	[Fact]
	public void Part1_Example()
	{
		// Single register X.
		// addx V takes two cycles. X register is increased by V (but can be negative).
		// noop takes one cycle and does nothing.

		// Example:
		// noop
		// addx 3
		// addx -5

		// X is 1
		// addx 3 starts during second cycle. X is still 1.
		// During third cycle, X is still 1. After the third cycle. X is 4.
		// At start of fourth cycle, X is 4
		// During fifth cycles, X is 4, after fifth cycle, X is -1.

		// Signal strength cycle number multiplied by X value in register
		// During 20th cycles and every 40th cycles after that (20, 60, 100, 140, 180, 220)

		Day10 puzzle = CreateFromFile("Example");
		var signalStrength = puzzle.SolutionPart1();
		Assert.Equal(13140, signalStrength);
	}

	[Fact]
	public void Part1_ExampleCycles()
	{
		Day10 puzzle = CreateFromFile("Example");

		// 20th cycle
		puzzle.Tick(20);
		Assert.Equal(20, puzzle.CycleNumber);
		Assert.Equal(21, puzzle.RegisterX);
		Assert.Equal(420, puzzle.SignalStrength);

		// 60th cycle
		puzzle.Tick(40);
		Assert.Equal(60, puzzle.CycleNumber);
		Assert.Equal(19, puzzle.RegisterX);
		Assert.Equal(1140, puzzle.SignalStrength);

		// 100th cycle
		puzzle.Tick(40);
		Assert.Equal(100, puzzle.CycleNumber);
		Assert.Equal(18, puzzle.RegisterX);
		Assert.Equal(1800, puzzle.SignalStrength);

		// 140th cycle
		puzzle.Tick(40);
		Assert.Equal(140, puzzle.CycleNumber);
		Assert.Equal(21, puzzle.RegisterX);
		Assert.Equal(2940, puzzle.SignalStrength);

		// 180th cycle
		puzzle.Tick(40);
		Assert.Equal(180, puzzle.CycleNumber);
		Assert.Equal(16, puzzle.RegisterX);
		Assert.Equal(2880, puzzle.SignalStrength);

		// 220th cycle
		puzzle.Tick(40);
		Assert.Equal(220, puzzle.CycleNumber);
		Assert.Equal(18, puzzle.RegisterX);
		Assert.Equal(3960, puzzle.SignalStrength);

		// Sum of all is 13140
	}

	[Fact]
	public void Part1_Input()
	{
		Day10 puzzle = CreateFromFile("Input");
		var signalStrength = puzzle.SolutionPart1();
		Assert.Equal(14760, signalStrength);
	}

	[Fact]
	public void Part2_Example()
	{
		// Input result: EFGERURE

		// Day10 puzzle = CreateFromFile("Example");
		// var signalStrength = puzzle.SolutionPart1();
		// Assert.Equal(14760, signalStrength);
	}
}