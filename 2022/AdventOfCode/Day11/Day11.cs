public class Day11 : Puzzle
{
	public Day11(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		// The level of monkey business:
		return MonkeyActivity(20, worryLevel => worryLevel / 3)
			.OrderByDescending(x => x)
			.Take(2).Aggregate(1L, (a, b) => a * b);
	}

	public override object SolutionPart2()
	{
		// Monkeys do not care about the actual worry level for each item.
		// Instead, they only test if it is divisible by some value.
		// To avoid a worry level from overflowing, we can modulo it at some (arbitrarily high)
		// value as long as that value is also divisible by the desired number.
		// For example: If the item value is 9 and should be divisible by 3 we can also do 9 % 6 % 3 == 0.
		// This reduces the size of the number 9, and as long as 6 is also divisible by 3, the test still works.
		// This way, we can simply do mod on some number to prevent integer overflow.
		// Because items are swapped between monkeys, we need to find a number that is divisible by all of the monkey's
		// test arguments. One way to achieve this, is by multiplying all test arguments.
		long highestPossibleTestArgument = Monkeys().Aggregate(
			1L, (testArgument, monkey) => testArgument * monkey.testArgument);
		
		return MonkeyActivity(10_000, worryLevel => worryLevel % highestPossibleTestArgument)
			.OrderByDescending(x => x)
			.Take(2).Aggregate(1L, (a, b) => a * b);
	}

	/// <summary>
	/// Returns the number of inspected items per monkey.
	/// </summary>
	private IEnumerable<long> MonkeyActivity(long rounds, Func<long, long> reliefFunction)
	{
		Simulate(rounds, reliefFunction);
		return Monkeys().Select(x => x.inspectCount);
	}

	private Monkey[] monkeys;

	public Monkey[] Monkeys()
	{
		if (monkeys != null)
			return monkeys;

		string[] monkeySections = input.Text().Split("\n\n");
		monkeys = new Monkey[monkeySections.Length];

		for (long i = 0; i < monkeySections.Length; i++)
		{
			monkeys[i] = new Monkey();
			string section = monkeySections[i];
			string[] lines = section.Split("\n");
			string name = lines[0];
			monkeys[i].name = name;
			string rawItems = lines[1].Split(":")[1];
			string[] rawItemsSplit = rawItems.Split(", ");
			monkeys[i].items = rawItemsSplit.Select(x => long.Parse(x)).ToList();

			string operationLine = lines[2];
			operationLine = operationLine.Replace("  Operation: new = old ", string.Empty);
			string argRaw = operationLine.Split(" ")[1];

			if (argRaw == "old")
			{
				switch (operationLine.Split(" ")[0])
				{
					case "*":
						monkeys[i].operation = worryLevel => worryLevel * worryLevel;
						monkeys[i].operationDebugString = "is multiplied by itself";
						break;
					case "+":
						monkeys[i].operation = worryLevel => worryLevel + worryLevel;
						monkeys[i].operationDebugString = "increases by itself";
						break;
				}
			}
			else
			{
				long arg = long.Parse(argRaw);
				switch (operationLine.Split(" ")[0])
				{
					case "*":
						monkeys[i].operation = worryLevel => worryLevel * arg;
						monkeys[i].operationDebugString = "is multiplied by " + arg;
						break;
					case "+":
						monkeys[i].operation = worryLevel => worryLevel + arg;
						monkeys[i].operationDebugString = "increases by " + arg;
						break;
				}
			}


			string testLine = lines[3];
			testLine = testLine.Replace("  Test: divisible by ", string.Empty);
			long testArg = long.Parse(testLine);
			monkeys[i].test = worryLevel => worryLevel % testArg == 0;
			monkeys[i].testArgument = testArg;

			monkeys[i].monkeyTargetOnTrue = long.Parse(
				lines[4].Replace("    If true: throw to monkey ", string.Empty));

			monkeys[i].monkeyTargetOnFalse = long.Parse(
				lines[5].Replace("    If false: throw to monkey ", string.Empty));
		}

		return monkeys;
	}

	public class Monkey
	{
		public string name;
		public List<long> items;
		public Func<long, long> operation;
		public string operationDebugString;
		public Func<long, bool> test;
		public long testArgument;
		public long monkeyTargetOnTrue;
		public long monkeyTargetOnFalse;

		// Number of times the monkey inspected items.
		public long inspectCount;
	}

	public void Simulate(long rounds, Func<long, long> reliefFunction)
	{
		for (long i = 0; i < rounds; i++)
		{
			Monkey[]? monkeys = Monkeys();
			for (long j = 0; j < monkeys.Length; j++)
			{
				Monkey? monkey = monkeys[j];
				SimulateTurn(monkey, monkeys, reliefFunction);
			}

			WriteLine();
			LogMonkeyItems(i + 1);
		}

		foreach (Monkey monkey in Monkeys())
		{
			WriteLine(monkey.name + $" inspected items {monkey.inspectCount} times.");
		}
	}

	private void LogMonkeyItems(long roundNumber)
	{
		WriteLine($"After round {roundNumber}, the monkeys are holding items with these worry levels:");
		foreach (Monkey monkey in Monkeys())
		{
			WriteLine(monkey.name + " " + string.Join(", ", monkey.items));
		}

		WriteLine();
	}

	private void SimulateTurn(Monkey monkey, Monkey[] monkeys, Func<long, long> reliefFunction)
	{
		WriteLine(monkey.name);

		var items = monkey.items;

		if (items.Count == 0)
			return;

		// Inspect items
		for (int i = 0; i < items.Count; i++)
		{
			// Inspect
			WriteLine($"  Monkey inspects an item with a worry level of {items[i]}.");

			items[i] = monkey.operation.Invoke(items[i]);
			WriteLine($"   Worry level {monkey.operationDebugString} to {items[i]}.");

			items[i] = reliefFunction.Invoke(items[i]);
			WriteLine($"   Monkey gets bored with item. Worry level is divided by 3 to {items[i]}.");
			// Test worry level
			bool testResult = monkey.test.Invoke(items[i]);
			if (testResult)
				WriteLine($"   Current worry level is divisible by {monkey.testArgument}.");
			else
				WriteLine($"   Current worry level is not divisible by {monkey.testArgument}.");
			// Throw
			if (testResult)
			{
				WriteLine(
					$"   Item with worry level {items[i]} is thrown to monkey {monkey.monkeyTargetOnTrue}.");

				monkeys[monkey.monkeyTargetOnTrue].items.Add(items[i]);
				items.RemoveAt(i);
				i--;
			}
			else
			{
				WriteLine(
					$"   Item with worry level {items[i]} is thrown to monkey {monkey.monkeyTargetOnFalse}.");


				monkeys[monkey.monkeyTargetOnFalse].items.Add(items[i]);
				items.RemoveAt(i);
				i--;
			}

			monkey.inspectCount++;
		}
	}

	private static void WriteLine(string? message = null)
	{
		//Console.WriteLine(message);
	}
}