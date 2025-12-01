using System.Text.RegularExpressions;

public class Day5 : Puzzle
{
	public Day5(IInput input) : base(input)
	{
	}

	private readonly struct Instruction
	{
		/// <summary>
		/// The number of crates to move.
		/// </summary>
		public readonly int Count;

		/// <summary>
		/// The stack column number (starting at 1) to pop from.
		/// </summary>
		public readonly int From;

		/// <summary>
		/// The stack column number (starting at 1) to push to.
		/// </summary>
		public readonly int To;

		public Instruction(int count, int from, int to)
		{
			Count = count;
			From = from;
			To = to;
		}

		public void ApplyTo(IReadOnlyList<Stack<char>> stacks)
		{
			for (int i = 0; i < Count; i++)
			{
				char crate = stacks[From - 1].Pop();
				stacks[To - 1].Push(crate);
			}
		}

		public void ApplyToPart2(IReadOnlyList<Stack<char>> stacks)
		{
			var crates = new Stack<char>(Count);
			for (int i = 0; i < Count; i++)
			{
				char crate = stacks[From - 1].Pop();
				crates.Push(crate);
			}

			foreach (char c in crates)
			{
				stacks[To - 1].Push(c);
			}
		}

		public override string ToString()
		{
			return $"move {Count} from {From} to {To}";
		}
	}

	private class Parser
	{
		public Stack<char>[] stacks;
		public List<Instruction> instructions;

		public void Parse(IEnumerable<string> inputLines)
		{
			var lexer = new Lexer();
			lexer.Parse(inputLines);

			instructions = new List<Instruction>(lexer.instructionTokens.Count);

			foreach ((string, string, string) token in lexer.instructionTokens)
			{
				instructions.Add(new Instruction(
					count: int.Parse(token.Item1),
					from: int.Parse(token.Item2),
					to: int.Parse(token.Item3)));
			}

			stacks = new Stack<char>[lexer.stackTokens[0].Length];
			for (int i = 0; i < stacks.Length; i++)
			{
				stacks[i] = new Stack<char>();
			}

			lexer.stackTokens.Reverse();

			foreach (char[] line in lexer.stackTokens)
			{
				for (int i = 0; i < line.Length; i++)
				{
					if (line[i] > 0)
					{
						stacks[i].Push(line[i]);
					}
				}
			}
		}
	}

	private class Lexer
	{
		public readonly List<char[]> stackTokens = new();
		public readonly List<(string, string, string)> instructionTokens = new();

		private enum ParsingState
		{
			Skip,
			Crates,
			Instructions
		}

		public void Parse(IEnumerable<string> inputLines)
		{
			var state = ParsingState.Crates;

			foreach (string line in inputLines)
			{
				if (state == ParsingState.Crates)
				{
					char[] chars = new char[(line.Length + 1) / 4];
					for (int i = 0; i < chars.Length; i++)
					{
						char c = line[1 + i * 4];
						if (char.IsLetter(c))
						{
							chars[i] = c;
						}
					}

					if (chars.All(x => x == 0))
					{
						state = ParsingState.Skip;
						continue;
					}

					stackTokens.Add(chars);
				}

				else if (state == ParsingState.Skip)
				{
					if (line.StartsWith("move"))
					{
						state = ParsingState.Instructions;
					}
				}

				if (state == ParsingState.Instructions)
				{
					string[] split = line.Split(" ");
					instructionTokens.Add((split[1], split[3], split[5]));
				}
			}
		}
	}

	[Benchmark]
	public override object SolutionPart1()
	{
		var parser = new Parser();
		parser.Parse(inputLines);

		foreach (Instruction instruction in parser.instructions)
		{
			instruction.ApplyTo(parser.stacks);
		}

		return string.Join(string.Empty, parser.stacks.Select(x => x.Peek()));
	}

	//[Benchmark]
	public override object SolutionPart2()
	{
		var parser = new Parser();
		parser.Parse(inputLines);

		foreach (Instruction instruction in parser.instructions)
		{
			instruction.ApplyToPart2(parser.stacks);
		}

		return string.Join(string.Empty, parser.stacks.Select(x => x.Peek()));
	}
	
	//[Benchmark]
	public object PartOne() => MoveCrates(File.ReadAllText("Day5/Input.txt"), CrateMover9000);
	
	//[Benchmark]
	public object PartTwo() => MoveCrates(File.ReadAllText("Day5/Input.txt"), CrateMover9001);

	record struct Move(int count, Stack<char> source, Stack<char> target);

	void CrateMover9000(Move move) {
		for (var i = 0; i < move.count; i++) {
			move.target.Push(move.source.Pop());
		}
	}

	void CrateMover9001(Move move) {
		// same as CrateMover9000 but keeps element order
		var helper = new Stack<char>();
		CrateMover9000(move with {target=helper});
		CrateMover9000(move with {source=helper});
	}

	string MoveCrates(string input, Action<Move> crateMover)  {
		var parts = input.Split("\n\n");

		var stackDefs = parts[0].Split("\n");
        
		// process each line by 4 character wide columns
		// last line defines the number of stacks:
		var stacks = stackDefs.Last().Chunk(4).Select(i => new Stack<char>()).ToArray();
		// bottom-up: push the next element to the the correspoing stack (' ' means no more elements).
		foreach (var line in stackDefs.Reverse().Skip(1)) {
			foreach (var (stack, item) in stacks.Zip(line.Chunk(4))) {
				if (item[1] != ' ') {
					stack.Push(item[1]);
				}
			}
		}

		try
		{
// parse the 'moves' with regex, and use 'crateMover' on them:
			foreach (var line in parts[1].Split("\n")) {
				var m = Regex.Match(line, @"move (.*) from (.*) to (.*)");
				var count = int.Parse(m.Groups[1].Value);
				var from = int.Parse(m.Groups[2].Value) - 1;
				var to = int.Parse(m.Groups[3].Value) - 1;
				crateMover(new Move(count:count, source: stacks[from], target: stacks[to]));
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		

		// assuming that the stacks are not empty at the end, concatenate the top of each:
		return string.Join("", stacks.Select(stack => stack.Pop()));
	}
}