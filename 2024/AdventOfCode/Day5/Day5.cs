using System.Diagnostics;

public class Day5 : Puzzle
{
	public override object Part1(string input)
	{
		ParseInput(input, out int[][] updates, out (int, int)[] orderingRules);

		int sum = 0;

		foreach (int[] update in updates)
		{
			if (HaveCorrectOrdering(update, orderingRules))
			{
				sum += FindMiddlePageNumber(update);
			}
		}

		return sum;
	}

	public static void ParseInput(string input, out int[][] updates, out (int, int)[] orderingRules)
	{
		string[] sections = input.Split("\n\n");
		Debug.Assert(sections.Length == 2);

		// Example rule: 42|67
		orderingRules = sections[0].Lines().Select(rule =>
		{
			int[] pages = rule.Split("|").Select(int.Parse).ToArray();
			return (pages[0], pages[1]);
		}).ToArray();

		// Example update: 75,47,61,53,29
		updates = sections[1].Lines()
			.Select(
				update => update.Split(",").Select(int.Parse).ToArray()
			).ToArray();
	}

	private bool HaveCorrectOrdering(int[] pageNumbers, (int, int)[] orderingRules)
	{
		foreach ((int, int) rule in orderingRules)
		{
			if (pageNumbers.Contains(rule.Item1) && pageNumbers.Contains(rule.Item2))
			{
				// Both numbers are in the update, the first must appear left of the second.
				int a = Array.IndexOf(pageNumbers, rule.Item1);
				int b = Array.IndexOf(pageNumbers, rule.Item2);
				if (a > b)
					return false;
			}
		}

		return true;
	}

	public static int FindMiddlePageNumber(IEnumerable<int> pageNumbers)
	{
		int[] pageNumbersArray = pageNumbers.ToArray();
		Debug.Assert(pageNumbersArray.Length % 2 != 0);
		return pageNumbersArray[pageNumbersArray.Length / 2];
	}

	public override object Part2(string input)
	{
		ParseInput(input, out int[][] updates, out (int, int)[] orderingRules);
		int sum = 0;
		foreach (int[] update in updates)
		{
			if (!HaveCorrectOrdering(update, orderingRules))
			{
				IEnumerable<int> fixedOrderUpdate = FixOrder(update, orderingRules);
				sum += FindMiddlePageNumber(fixedOrderUpdate);
			}
		}
		return sum;
	}

	public static IEnumerable<int> FixOrder(IEnumerable<int> pageNumbers, (int, int)[] orderingRules)
	{
		return pageNumbers.OrderBy(a => a, Comparer<int>.Create((a, b) =>
		{
			foreach ((int, int) rule in orderingRules)
			{
				if (a == rule.Item1 && b == rule.Item2)
				{
					return -1;
				}
				else if (a == rule.Item2 && b == rule.Item1)
				{
					return 1;
				}
			}
			return 0;
		}));
	}

	public static int[] SimpleSort(int[] input)
	{
		List<int> list = input.ToList();
		list.Sort((a, b) =>
		{
			if (a < b)
				return -1;
			else if (a > b)
				return 1;
			else
				return 0;
		});
		return list.ToArray();
	}
}