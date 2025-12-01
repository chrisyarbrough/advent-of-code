using CommandLine;

[Verb("solve", HelpText = "Print the solution to a puzzle.")]
class SolveCommand : Command
{
	[Option("input")]
	public required string InputFileName { get; set; }

	[Option("part")]
	public int? Part { get; set; }

	public override void Run()
	{
		Type type = Type.GetType("Day" + Day) ?? throw new ArgumentException("Invalid day. Must be between 1 and 25.");
		var puzzle = (Puzzle)Activator.CreateInstance(type)!;

		if (InputFileName != null)
			puzzle.InputFileName = InputFileName;

		if (Part is 1 or null)
			Console.WriteLine("Solution 1: " + puzzle.Solve(p => p.Part1));

		if (Part is 2 or null)
			Console.WriteLine("Solution 2: " + puzzle.Solve(p => p.Part2));

		if (Part is not 1 and not 2)
			Console.WriteLine($"Unknown part: '{Part}'. Enter '1' or '2'.");
	}
}