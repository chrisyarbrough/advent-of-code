public class Day5 : Puzzle
{
	public override object Part1(string input)
	{
		string[] sections = input.Trim().Split("\n\n");

		List<(long start, long end)> freshIDRanges = sections[0]
			.Split(Environment.NewLine)
			.Select(line =>
			{
				var parts = line.Split("-");
				return (long.Parse(parts[0]), long.Parse(parts[1]));
			})
			.ToList();

		List<long> availableIDs = sections[1]
			.Split(Environment.NewLine)
			.Select(long.Parse)
			.ToList();

		return availableIDs
			.Count(id => freshIDRanges
				.Any(range => range.start <= id && id <= range.end));
	}

	public override object Part2(string input)
	{
		string topSection = input.Split("\n\n")[0];

		List<(long start, long end)> ranges = topSection
			.Split(Environment.NewLine)
			.Select(line =>
			{
				var parts = line.Split("-");
				return (long.Parse(parts[0]), long.Parse(parts[1]));
			})
			.OrderBy(r => r.Item1)
			.ToList();


		// Overlapping ranges need to be trimmed to remove duplicates.
		List<(long start, long end)> trimmedRanges = [];

		foreach (var range in ranges)
		{
			// Extend the previous range if it overlaps.
			// #####.....
			//   ########
			//       ##
			//            ##
			if (trimmedRanges.Count > 0 && range.start <= trimmedRanges[^1].end + 1)
			{
				trimmedRanges[^1] = (trimmedRanges[^1].start, Math.Max(range.end, trimmedRanges[^1].end));
				continue;
			}
			trimmedRanges.Add(range);
		}

		return trimmedRanges.Sum(range => range.end - range.start + 1);
	}

	// Solutions that I attempted:
	// - Naively walk through each range and check if the number is in any other. (much too slow on large input)
	// - Store ranges in HashSet for quick lookup of duplicates. (input is larger than HashSets int.Max capacity)
	// - Store ranges in multiple HashSets. (the largest individual range is already larger than HashSet capacity)
	// - Walk through all possible numbers and check range lookup. (too slow and doesn't fit in memory)
	// - Use a Stack- or Queue-based approach to merge ranges: [3 5]  [10 [12 14] [16 18] 20]
	// Problem: largets range has 44 bits:
	//         8_854_164_641_109 -> doesn't fit HashSet
	//             2_147_483_647 (int max)
	// 9_223_372_036_854_775_807 (long max)
}