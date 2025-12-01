public class Day1 : Puzzle
{
	public override object Part1(string input)
	{
		FormatInput(input, out List<int> left, out List<int> right);

		left.Sort();
		right.Sort();

		int totalDistance = 0;
		for (int i = 0; i < left.Count; i++)
		{
			totalDistance += Math.Abs(right[i] - left[i]);
		}

		return totalDistance;
	}

	public override object Part2(string input)
	{
		FormatInput(input, out List<int> left, out List<int> right);

		Dictionary<int, int> rightCounts = new();

		foreach (int i in right)
		{
			rightCounts.TryAdd(i, 0);
			rightCounts[i]++;
		}

		return left.Sum(number => number * rightCounts.GetValueOrDefault(number, 0));
	}

	private void FormatInput(string input, out List<int> left, out List<int> right)
	{
		left = [];
		right = [];

		foreach (int[] split in input.Lines()
			         .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				         .Select(int.Parse).ToArray()))
		{
			left.Add(split[0]);
			right.Add(split[1]);
		}
	}
}