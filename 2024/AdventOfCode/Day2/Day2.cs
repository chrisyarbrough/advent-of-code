using System.Diagnostics;

public class Day2 : Puzzle
{
	public override object Part1(string input)
	{
		var watch = Stopwatch.StartNew();
		int a = input.Lines().Select(x => x.Split(' ').Select(int.Parse).ToArray())
			.Count(IsSafe);
		watch.Stop();
		Console.WriteLine("Time: " + watch.ElapsedMilliseconds);
		return a;
	}

	private bool IsSafe(int[] report)
	{
		int[] differences = report.Zip(report.Skip(1), (a, b) => b - a).ToArray();
		bool isMonotonic = differences.All(x => x > 0) || differences.All(x => x < 0);
		bool isInRange = differences.All(x => Math.Abs(x) > 0 && Math.Abs(x) <= 3);
		return isMonotonic && isInRange;
	}

	private bool IsSafeFast(int[] report)
	{
		int? lastDirection = null;
		for (int i = 0; i < report.Length - 1; i++)
		{
			int difference = report[i + 1] - report[i];
			int direction = Math.Sign(difference);

			lastDirection ??= direction;

			if (direction != lastDirection ||
			    difference == 0 ||
			    Math.Abs(difference) > 3)
			{
				return false;
			}
		}

		return true;
	}

	public override object Part2(string input)
	{
		return input.Lines().Select(x => x.Split(' ').Select(int.Parse).ToArray())
			.Count(IsSafeWithTolerance);
	}

	private bool IsSafeWithTolerance(int[] report)
	{
		if (IsSafe(report))
			return true;

		for (int i = 0; i < report.Length; i++)
		{
			List<int> list = report.ToList();
			list.RemoveAt(i);

			if (IsSafe(list.ToArray()))
				return true;
		}

		return false;
	}
}