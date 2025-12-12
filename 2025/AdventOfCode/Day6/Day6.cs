using System.Diagnostics;

public class Day6 : Puzzle
{
	private Dictionary<string, Func<IEnumerable<long>, long>> operations = new()
	{
		{ "+", values => values.Sum() },
		{ "*", values => values.Aggregate((x, y) => x * y) },
	};

	public override object Part1(string input)
	{
		// Normally, I would prefer a 2D array for table data, but for AOC problems,
		// jagged arrays are more convenient due to LINQ.
		string[][] worksheet = ConvertToWorksheet(input);
		int columnCount = worksheet[0].Length;
		int rowCount = worksheet.Length;

		return Enumerable.Range(0, columnCount)
			.Select(column =>
			{
				List<long> values =
					(from row in Enumerable.Range(0, rowCount - 1)
						select long.Parse(worksheet[row][column])).ToList();

				string instruction = worksheet[^1][column];
				return operations[instruction].Invoke(values);
			})
			.Sum();
	}

	private static string[][] ConvertToWorksheet(string input)
	{
		return input
			.Split("\n")
			.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
			.ToArray();
	}

	public override object Part2(string input)
	{
		List<string[]> instructions = ConvertToInstructions(input);

		return instructions.Sum(instructionSet => operations[instructionSet[^1]]
			.Invoke(instructionSet.Take(instructionSet.Length - 1)
				.Select(long.Parse)));
	}

	private static List<string[]> ConvertToInstructions(string input)
	{
		string[] lines = input.Split('\n');
		int rows = lines.Length;
		int charsPerRow = lines[0].Length;
		List<string[]> problems = [];
		Debug.Assert(lines.All(l => l.Length == charsPerRow));

		List<string> nums = [];
		char lastInstruction = '\0';

		for (int x = charsPerRow - 1; x >= 0; x--)
		{
			string num = string.Empty;
			if (lines.All(l => l[x] == ' '))
			{
				// break column
				nums.Add(lastInstruction.ToString());
				problems.Add(nums.ToArray());
				nums.Clear();
			}
			else
			{
				for (int row = 0; row < rows - 1; row++)
				{
					num += lines[row][x];
				}
				nums.Add(num);

				if (lines[rows - 1][x] != ' ')
					lastInstruction = lines[rows - 1][x];
			}
		}
		nums.Add(lastInstruction.ToString());
		problems.Add(nums.ToArray());

		return problems;
	}
}