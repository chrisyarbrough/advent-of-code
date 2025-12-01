public class Day10 : Puzzle
{
	private Queue<Instruction> instructions;

	private class Instruction
	{
		public bool IsDone { get; private set; }

		private readonly int requiredCycles;
		private readonly int argument;

		private int cycleCount;

		public Instruction(int requiredCycles, int argument)
		{
			this.requiredCycles = requiredCycles;
			this.argument = argument;
		}

		public void Tick()
		{
			cycleCount++;

			if (cycleCount == requiredCycles)
			{
				IsDone = true;
			}
		}

		public int ApplyResult(int registerX)
		{
			return registerX + argument;
		}
	}

	public Day10(IInput input) : base(input)
	{
		instructions = new Queue<Instruction>();

		foreach (string line in inputLines)
		{
			string[] split = line.Split(" ");

			if (split[0] == "noop")
				instructions.Enqueue(new Instruction(requiredCycles: 1, argument: 0));
			else if (split[0] == "addx")
				instructions.Enqueue(new Instruction(requiredCycles: 2, argument: int.Parse(split[1])));
		}
	}

	public int CycleNumber { get; private set; }

	public int RegisterX { get; set; } = 1;
	public int SignalStrength => CycleNumber * RegisterX;

	private Instruction? currentInstruction;

	public void Tick(int count)
	{
		for (int i = 0; i < count; i++)
		{
			if (currentInstruction != null && currentInstruction.IsDone)
			{
				RegisterX = currentInstruction.ApplyResult(RegisterX);
				currentInstruction = null;
			}

			CycleNumber++;

			if (currentInstruction == null && instructions.Count > 0)
				currentInstruction = instructions.Dequeue();

			if (currentInstruction != null)
				currentInstruction.Tick();
		}
	}

	public override object SolutionPart1()
	{
		/*
		int sum = 0;
		Tick(20);
		sum += SignalStrength;
		for (int i = 0; i < 5; i++)
		{
			Tick(40);
			sum += SignalStrength;
		}

		return sum;
		*/

		int[] interestingCycles = { 20, 60, 100, 140, 180, 220 };
		return AsStream()
			.Where(tick => interestingCycles.Contains(tick.cycle))
			.Select(tick => tick.cycle * tick.x)
			.Sum();
	}

	public IEnumerable<(int cycle, int x)> AsStream()
	{
		(int cycle, int x) = (1, 1);
		foreach (string line in inputLines)
		{
			string[] split = line.Split(" ");
			switch (split[0])
			{
				case "noop":
					yield return (cycle++, x);
					break;
				case "addx":
					yield return (cycle++, x);
					yield return (cycle++, x);
					x += int.Parse(split[1]);
					break;
			}
		}
	}

	public override object SolutionPart2()
	{
		foreach (var tick in AsStream())
		{
			int pixelPosition = (tick.cycle - 1) % 40;
			//Console.Write("Sprite position: ");
			// for (int i = 0; i < 40; i++)
			// {
			// 	string symbol = i >= tick.x - 1 && i <= tick.x + 1 ? "#" : ".";
			// 	Console.Write(symbol);
			// }

			//Console.WriteLine();
			//Console.WriteLine($"Start cycle {tick.cycle}");
			//Console.WriteLine("CRT draws pixel position: " + pixelPosition);
			//Console.Write("CRT row: ");

			if (pixelPosition >= tick.x - 1 && pixelPosition <= tick.x + 1)
			{
				Console.Write("██");
			}
			else
			{
				Console.Write("  ");
			}

			if (pixelPosition == 39)
			{
				Console.WriteLine();
			}
		}

		return null;
	}
}