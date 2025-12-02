public class Day2 : Puzzle
{
	public override object Part1(string input)
	{
		return input
			.Split(",")
			.SelectMany(range =>
			{
				var split = range.Split('-');
				return Range(long.Parse(split[0]), long.Parse(split[1]));
			})
			.Where(i => !IsValidID_Part1(i.ToString()))
			.Sum();
	}

	public object Part1_Old(string input)
	{
		long sum = 0;
		foreach (string range in input.Split(','))
		{
			var split = range.Split('-');
			var start = long.Parse(split[0]);
			var end = long.Parse(split[1]);
			for (long i = start; i <= end; i++)
			{
				if (!IsValidID_Part1(i.ToString()))
				{
					sum += i;
				}
			}
		}
		return sum;
	}

	private static IEnumerable<long> Range(long start, long end)
	{
		for (long i = start; i <= end; i++)
		{
			yield return i;
		}
	}

	public static bool IsValidID_Part1(string id)
	{
		int mid = id.Length / 2;
		var left = id[0..mid];
		var right = id[mid..id.Length];
		return left != right;
	}

	public override object Part2(string input)
	{
		long sum = 0;
		foreach (string range in input.Split(','))
		{
			var split = range.Split('-');
			sum += Range(long.Parse(split[0]), long.Parse(split[1]))
				.Where(x => !IsValidID_Part2_Old(x.ToString()))
				.Sum();
		}
		return sum;
	}

	public static bool IsValidID_Part2(string id)
	{
		int maxChunkSize = id.Length / 2;
		for (int i = 1; i <= maxChunkSize; i++)
		{
			var chunks = id.Chunk(i).Select(c => new string(c)).ToArray();
			if (chunks.All(x => x == chunks.First()))
				return false;
		}
		return true;
	}

	public static bool IsValidID_Part2_Old(string id)
	{
		for (int k = 7; k >= 2; k--)
		{
			int chunkSize = id.Length / k;

			if (chunkSize == 0 || id.Length % chunkSize != 0)
				continue;

			int chunkCount = id.Length / chunkSize;

			bool repeating = true;
			for (int i = 0; i < chunkCount - 1; i++)
			{
				int left = i * chunkSize;
				int right = left + chunkSize;

				string a = id[left..right];
				string b = id[right..(right + chunkSize)];

				if (a != b)
				{
					repeating = false;
					break;
				}
			}
			if (repeating)
				return false;
		}
		return true;
	}
}