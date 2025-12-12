using System.Text.RegularExpressions;

public class Day10 : Puzzle
{
	public override object Part1(string input)
	{
		int totalCount = 0;
		foreach (string line in input.Trim().Split("\n"))
		{
			var match = Regex.Match(line, @"\[(.+)\]\s(.*)\s\{(.+)\}");

			var machine = new Machine(
				indicatorLightDiagram: match.Groups[1].Value,
				buttonWiring: match.Groups[2].Value);

			List<List<int[]>> solvingSequences = [];
			List<int[]> currentSequence = [];

			// Try all combinations and collect the sequences that yield a result.
			// At least for part 1, we can assume that we only ever need to press each button twice,
			// because the examples hint at it. If that fails for the real input, we could increase to 3 or 4,
			// but very likely, the time complexity would outgrow feasible durations quickly.
			var combinations = GetCombinations(2, machine.ButtonCount).ToArray();
			foreach (int[] combination in combinations)
			{
				for (int i = 0; i < combination.Length; i++)
				{
					int pressCount = combination[i];
					for (int j = 0; j < pressCount; j++)
					{
						machine.PressButton(machine.GetButton(i));
						currentSequence.Add(machine.GetButton(i));
					}
				}
				if (machine.IsInitialized())
				{
					solvingSequences.Add(currentSequence);
				}
				currentSequence = [];
				machine.Reset();
			}

			int count = solvingSequences.OrderBy(x => x.Count).First().Count;
			totalCount += count;
		}
		return totalCount;
	}

	private static IEnumerable<int[]> GetCombinations(int numValues, int numPositions)
	{
		IEnumerable<IEnumerable<int>> result = [[]];
		for (int i = 0; i < numPositions; i++)
		{
			result =
				from sequence in result
				from value in Enumerable.Range(0, numValues)
				select sequence.Append(value);
		}
		return result.Select(sequence => sequence.ToArray());
	}

	public override object Part2(string input)
	{
		return "";
	}
}