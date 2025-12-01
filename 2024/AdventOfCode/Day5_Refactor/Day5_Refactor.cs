using System.Diagnostics;

public class Day5_Refactor : Puzzle
{
	public override object Part1(string input)
	{
		var (updates, comparer) = ParseInput(input);
		return updates
			.Where(pages => Sorted(pages, comparer))
			.Sum(GetMiddle);
	}

	public override object Part2(string input)
	{
		var (updates, comparer) = ParseInput(input);
		return updates
			.Where(pages => !Sorted(pages, comparer))
			.Select(pages => pages.OrderBy(p => p, comparer).ToArray())
			.Select(GetMiddle)
			.Sum();
	}

	private static (int[][] updates, Comparer<int> comparer) ParseInput(string input)
	{
		string[] sections = input.Split("\n\n");
		Debug.Assert(sections.Length == 2);

		// Rules, e.g.: 42|67
		HashSet<(int, int)> rules = sections[0].Lines().Select(rule => rule.Split("|").Select(int.Parse).ToArray())
			.Select(ruleNumbers => (ruleNumbers[0], ruleNumbers[1])).ToHashSet();

		Comparer<int> comparer = Comparer<int>.Create((a, b) => rules.Contains((a, b)) ? -1 : 1);

		// Updates, e.g. page numbers: 75,47,61,53,29
		var updates = sections[1].Lines()
			.Select(
				update => update.Split(",").Select(int.Parse).ToArray()
			).ToArray();

		return (updates, comparer);
	}

	public static bool Sorted(int[] pages, Comparer<int> comparer)
	{
		return pages.SequenceEqual(pages.OrderBy(p => p, comparer));
	}

	private static int GetMiddle(int[] numbers)
	{
		Debug.Assert(numbers.Length % 2 != 0);
		return numbers[numbers.Length / 2];
	}
}