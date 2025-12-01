[MemoryDiagnoser]
public class Day3 : Puzzle
{
	public Day3(IInput input) : base(input)
	{
	}

	public override object SolutionPart1() => SolutionPart1_Short();

	//[Benchmark]
	public long SolutionPart1_Old()
	{
		long prioritySum = 0;
		foreach (string line in inputLines)
		{
			string firstCompartment = line[..(line.Length / 2)];
			string secondCompartment = line[(line.Length / 2)..];

			char invalidItem = FindSharedItem(firstCompartment, secondCompartment);
			int itemPriority = GetPriority(invalidItem);
			prioritySum += itemPriority;
		}

		return prioritySum;
	}

	private static char FindSharedItem(string firstCompartment, string secondCompartment)
	{
		foreach (char c1 in firstCompartment)
		{
			foreach (char c2 in secondCompartment)
			{
				if (c1 == c2)
				{
					return c1;
				}
			}
		}

		throw new Exception();
	}

	public static int GetPriority(char c)
	{
		if (char.IsLower(c))
			return 1 + (c - 'a');
		else
			return 27 + (c - 'A');
	}

	//[Benchmark]
	public int SolutionPart1_Short()
	{
		return inputLines.Select(line =>
		{
			int midPoint = line.Length / 2;
			var set1 = new HashSet<char>(line[..midPoint]);
			set1.IntersectWith(line[midPoint..]);
			char invalidItem = set1.First();
			int itemPriority = GetPriority(invalidItem);
			return itemPriority;
		}).Sum();
	}

	[Benchmark]
	public override object SolutionPart2()
	{
		return inputLines.Chunk(3).Select(chunk =>
		{
			var set0 = new HashSet<char>(chunk[0]);
			var set1 = new HashSet<char>(chunk[1]);
			var set2 = new HashSet<char>(chunk[2]);

			set0.IntersectWith(set1);
			set0.IntersectWith(set2);

			char badgeItem = set0.First();
			int itemPriority = GetPriority(badgeItem);
			return itemPriority;
		}).Sum();
	}

	[Benchmark]
	public long SolutionPart2B()
	{
		return inputLines.Chunk(3).Select(chunk =>
		{
			var set0 = new HashSet<char>(chunk[0]);
			set0.IntersectWith(chunk[1]);
			set0.IntersectWith(chunk[2]);

			char badgeItem = set0.First();
			return GetPriority(badgeItem);
		}).Sum();
	}

	[Benchmark]
	public long SolutionPart2C()
	{
		return inputLines.Chunk(3).Select(chunk =>
		{
			char badgeItem = chunk[0]
				.Intersect(chunk[1])
				.Intersect(chunk[2])
				.First();

			return GetPriority(badgeItem);
		}).Sum();
	}
}