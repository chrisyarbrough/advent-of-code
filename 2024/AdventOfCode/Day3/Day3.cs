using System.Text.RegularExpressions;

public class Day3 : Puzzle
{
	public override object Part1(string input)
	{
		MatchCollection matches = Regex.Matches(
			input,
			pattern: @"mul\(\d+,\d+\)");

		return matches.Select(ParseMulExpression).Sum(x => x.a * x.b);
	}

	private (int a, int b) ParseMulExpression(Match match)
	{
		string expression = match.Value;
		expression = match.Value.Substring(4, expression.Length - 5);
		string[] split = expression.Split(",");
		return (int.Parse(split[0]), int.Parse(split[1]));
	}

	public override object Part2(string input)
	{
		MatchCollection matches = Regex.Matches(
			input: input,
			pattern: string.Join('|',
				@"mul\(\d{1,3},\d{1,3}\)",
				@"do\(\)",
				@"don't\(\)"));

		bool mulEnabled = true;

		int sum = 0;

		foreach (Match match in matches)
		{
			if (match.Value == "do()")
			{
				mulEnabled = true;
			}
			else if (match.Value == "don't()")
			{
				mulEnabled = false;
			}
			else if (mulEnabled)
			{
				(int a, int b) = ParseMulExpression(match);
				sum += a * b;
			}
		}
		return sum;
	}
}