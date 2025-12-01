using System.Diagnostics;
using System.Text.Json.Nodes;

public class Day13 : Puzzle
{
	public Day13(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		return SortedIndices().Sum();
	}

	private IEnumerable<int> SortedIndices()
	{
		int index = 1;
		foreach ((string, string) pair in Pairs())
		{
			Console.WriteLine($"== Pair {index} ==");

			int sort = Sorted(
				JsonNode.Parse(pair.Item1)!,
				JsonNode.Parse(pair.Item2)!);

			Debug.Assert(sort != 0);

			if (sort < 0)
			{
				yield return index;
			}

			Console.WriteLine();
			index++;
		}
	}

	public IEnumerable<(string, string)> Pairs()
	{
		return input.Text().Split("\n\n").Select(x =>
		{
			var split = x.Split("\n");
			return (split[0], split[1]);
		});
	}

	public static int Sorted(JsonNode left, JsonNode right, int level = 0)
	{
		var indent = new string(' ', level * 2);
		Console.WriteLine($"{indent}- Compare {left.ToJsonString()} vs {right.ToJsonString()}");

		// Both are integers.
		if (left is JsonValue && right is JsonValue)
		{
			int sort = (int)left - (int)right;

			if (sort < 0)
			{
				Console.WriteLine($"{indent}- Left side is smaller, so inputs are in the right order.");
				return -1;
			}
			else if (sort > 0)
			{
				Console.WriteLine($"{indent}- Right side is smaller, so inputs are not in the right order.");
				return 1;
			}
			else
			{
				return 0;
			}
		}
		// Both are lists or convert to lists.
		else
		{
			JsonArray leftArray = left as JsonArray ?? new JsonArray(items: (int)left);
			JsonArray rightArray = right as JsonArray ?? new JsonArray(items: (int)right);

			// Compare the first value of each list, then the second and so on.
			for (int i = 0; i < leftArray.Count && i < rightArray.Count; i++)
			{
				int sort = Sorted(leftArray[i]!, rightArray[i]!, level + 1);

				if (sort != 0)
					return sort;
			}

			if (leftArray.Count < rightArray.Count)
				return -1;
			else if (leftArray.Count > rightArray.Count)
				return 1;

			return 0;
		}
	}

	public override object SolutionPart2()
	{
		var list = Part2Packets().ToList();
		list.Sort((a, b) =>
		{
			return Sorted(
				JsonNode.Parse(a)!,
				JsonNode.Parse(b)!);
		});

		foreach (string s in list)
			Console.WriteLine(s);


		return (1 + list.IndexOf("[[2]]")) * (1 + list.IndexOf("[[6]]"));
	}

	private IEnumerable<string> Part2Packets()
	{
		// Disregard blank lines.
		foreach (string line in inputLines.Where(l => l.Length > 0))
		{
			yield return line;
		}

		// Divider packets.
		yield return "[[2]]";
		yield return "[[6]]";
	}
}