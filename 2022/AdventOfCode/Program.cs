using System.Reflection;
using BenchmarkDotNet.Running;

public static class Program
{
	public static void Main(string[] args)
	{
		if (args.Length < 1)
		{
			throw new ArgumentException("Must provide a puzzle name, e.g. 'Day1'.");
		}

		if (args[0] == "Bench")
		{
			BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
		}
		else
		{
			Type type = Type.GetType(args[0]) ??
			            throw new ArgumentException("Must provide a valid puzzle name, e.g. 'Day1'.");

			string dayName = type.Name.Split("_").First();
			var puzzle = (Puzzle)Activator.CreateInstance(type, new InputFile($"{dayName}/{args[1]}.txt"))!;

			if (args[2] == "1")
				Console.WriteLine("Solution Part 1: " + puzzle.SolutionPart1());
			else if (args[2] == "2")
				Console.WriteLine("Solution Part 2: " + puzzle.SolutionPart2());
			else
				throw new ArgumentException("Must provide part 1 or 2. E.G. Day1 1");
		}
	}
}