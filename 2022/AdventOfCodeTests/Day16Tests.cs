namespace AdventOfCode.Day16.Tests;

public class Day16Tests : PuzzleTest<Day16>
{
	[Fact]
	public void Part1_Example()
	{
		// The most pressure possible released in 30 minutes.
		// Move between values = 1 minute
		// Open valve = 1 minute
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(1651, result);
	}

	[Fact]
	public void Part1_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(0, result);
	}

	[Fact]
	public void Part2_Example()
	{
		var puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(0, result);
	}

	[Fact]
	public void Part2_Input()
	{
		var puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(0, result);
	}

	[Fact]
	public void ValveInputParsing()
	{
		string line = "Valve BB has flow rate=13; tunnels lead to valves CC, AA";
		Valve valve = Valve.Parse(line);
		Assert.Equal("BB", valve.Name);
		Assert.Equal(13, valve.FlowRate);
		Assert.Equal(2, valve.ConnectionCount);
		Assert.Equal("CC", valve.ConnectionAt(0));
		Assert.Equal("AA", valve.ConnectionAt(1));
	}

	[Fact]
	public void ValveInputParsing_SingleValve()
	{
		string line = "Valve HH has flow rate=22; tunnel leads to valve GG";
		Valve valve = Valve.Parse(line);
		Assert.Equal("HH", valve.Name);
		Assert.Equal(22, valve.FlowRate);
		Assert.Equal(1, valve.ConnectionCount);
		Assert.Equal("GG", valve.ConnectionAt(0));
	}

	[Fact]
	public void InputParsingExample()
	{
		var puzzle = CreateFromFile("Example");
		Valve valve = puzzle.ParseInput().ElementAt(2);
		Assert.Equal("CC", valve.Name);
		Assert.Equal(2, valve.FlowRate);
		Assert.Equal(2, valve.ConnectionCount);
	}
}