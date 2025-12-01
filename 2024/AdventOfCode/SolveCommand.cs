using CommandLine;

[Verb("solve", HelpText = "Print the solution to a puzzle.")]
class SolveCommand : Command
{
	[Option("input")]
	public string InputFileName { get; set; }

	[Option("part")]
	public int? Part { get; set; } = null;

	public override void Run()
	{
		Type type = Type.GetType("Day" + Day) ?? throw new ArgumentException("Invalid day. Must be between 1 and 25.");
		var puzzle = (Puzzle)Activator.CreateInstance(type);

		if (InputFileName != null)
			puzzle.InputFileName = InputFileName;

		if (Part is null or 1)
			Console.WriteLine("Solution 1: " + puzzle.Solve(p => p.Part1));

		if (Part is null or 2)
			Console.WriteLine("Solution 2: " + puzzle.Solve(p => p.Part2));
	}
}