[MemoryDiagnoser]
public class Day1 : Puzzle
{
	public Day1(IInput input) : base(input)
	{
	}

	public override object SolutionPart1() => SolutionD();
	public override object SolutionPart2() => SolutionPart2B();

	[Benchmark]
	public long SolutionA()
	{
		long currentElfCalories = 0;
		long maxCalories = 0;

		foreach (string line in inputLines)
		{
			if (long.TryParse(line, out long result))
			{
				// Sum calories for each group separated by a blank line.
				currentElfCalories += result;
			}
			else
			{
				SaveHighestTotal();

				// Another elf inventory might follow.
				currentElfCalories = 0;
			}
		}

		// If the file does not end in a blank line, finish processing the last inventory.
		SaveHighestTotal();

		void SaveHighestTotal()
		{
			if (currentElfCalories > maxCalories)
			{
				maxCalories = currentElfCalories;
			}
		}

		return maxCalories;
	}

	[Benchmark]
	public long SolutionB()
	{
		long currentElfCalories = 0;
		long maxCalories = 0;

		foreach (string line in inputLines)
		{
			if (long.TryParse(line, out long result))
			{
				// Sum calories for each group separated by a blank line.
				currentElfCalories += result;

				if (currentElfCalories > maxCalories)
				{
					maxCalories = currentElfCalories;
				}
			}
			else
			{
				// Another elf inventory might follow.
				currentElfCalories = 0;
			}
		}

		return maxCalories;
	}

	[Benchmark]
	public long SolutionD()
	{
		long currentElfCalories = 0;
		long maxCalories = 0;

		foreach (string line in inputLines)
		{
			if (long.TryParse(line, out long result))
			{
				// Sum calories for each group separated by a blank line.
				currentElfCalories += result;

				if (currentElfCalories > maxCalories)
				{
					maxCalories = currentElfCalories;
				}
			}
			else
			{
				// Another elf inventory might follow.
				currentElfCalories = 0;
			}
		}

		return maxCalories;
	}

	[Benchmark]
	public long SolutionPart2A()
	{
		long currentElfCalories = 0;
		var caloriesPerElf = new List<long>();

		foreach (string line in inputLines)
		{
			if (long.TryParse(line, out long result))
			{
				// Sum calories for each group separated by a blank line.
				currentElfCalories += result;
			}
			else
			{
				caloriesPerElf.Add(currentElfCalories);
				currentElfCalories = 0;
			}
		}

		if (currentElfCalories != 0)
		{
			caloriesPerElf.Add(currentElfCalories);
		}

		return caloriesPerElf.OrderByDescending(x => x).Take(3).Sum();
	}

	[Benchmark]
	public long SolutionPart2B()
	{
		long currentElfCalories = 0;
		long maxCalories1 = 0, maxCalories2 = 0, maxCalories3 = 0;

		foreach (string line in inputLines)
		{
			if (long.TryParse(line, out long result))
			{
				// Sum calories for each group separated by a blank line.
				currentElfCalories += result;
			}
			else
			{
				if (currentElfCalories > maxCalories1)
				{
					maxCalories3 = maxCalories2;
					maxCalories2 = maxCalories1;
					maxCalories1 = currentElfCalories;
				}
				else if (currentElfCalories > maxCalories2)
				{
					maxCalories3 = maxCalories2;
					maxCalories2 = currentElfCalories;
				}
				else if (currentElfCalories > maxCalories3)
				{
					maxCalories3 = currentElfCalories;
				}

				currentElfCalories = 0;
			}
		}

		if (currentElfCalories != 0)
		{
			if (currentElfCalories > maxCalories1)
			{
				maxCalories3 = maxCalories2;
				maxCalories2 = maxCalories1;
				maxCalories1 = currentElfCalories;
			}
			else if (currentElfCalories > maxCalories2)
			{
				maxCalories3 = maxCalories2;
				maxCalories2 = currentElfCalories;
			}
			else if (currentElfCalories > maxCalories3)
			{
				maxCalories3 = currentElfCalories;
			}
		}

		return maxCalories1 + maxCalories2 + maxCalories3;
	}
}