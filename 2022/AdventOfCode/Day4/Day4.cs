public struct Range
{
	public int Start;
	public int End;
}

public class Day4 : Puzzle
{
	public Day4(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		int count = 0;
		foreach (string line in inputLines)
		{
			(Range a, Range b) = GetRanges(line);

			if ((b.Start >= a.Start && b.End <= a.End) ||
			    (a.Start >= b.Start && a.End <= b.End))
			{
				count++;
			}
		}

		return count;
	}

	public static (Range, Range) GetRanges(string line)
	{
		string[] split = line.Split(",");
		return (GetRange(split[0]), GetRange(split[1]));
	}

	public static Range GetRange(string input)
	{
		string[] split = input.Split("-");
		return new Range
		{
			Start = int.Parse(split[0]),
			End = int.Parse(split[1])
		};
	}

	public override object SolutionPart2()
	{
		int count = 0;
		foreach (string line in inputLines)
		{
			(Range a, Range b) = GetRanges(line);

			// Sort ranges to make the overlap check simpler.
			if (a.Start > b.Start)
			{
				(a, b) = (b, a);
			}

			if (a.End >= b.Start)
			{
				count++;
			}
		}

		return count;
	}
}