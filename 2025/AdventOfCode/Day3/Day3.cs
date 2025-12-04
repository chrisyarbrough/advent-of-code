using System.Diagnostics;

public class Day3 : Puzzle
{
	public override object Part1(string input)
	{
		return input
			.Split(Environment.NewLine)
			.Select(bank => FindLargestPossibleJoltage(bank))
			.Sum();
	}

	public override object Part2(string input)
	{
		return input
			.Split(Environment.NewLine)
			.Select(bank => FindLargestPossibleJoltage(bank, digits: 12))
			.Sum();
	}

	// First naive idea:
	// - loop through all combinations
	// - combine digits as strings and parse
	// private IEnumerable<long> FindPossibleJoltages(string bank)
	// {
	// 	string[] digits = bank.Select(char.ToString).ToArray();
	// 	for (long i = 0; i < digits.Length - 1; i++)
	// 	{
	// 		for (long j = i + 1; j < digits.Length; j++)
	// 		{
	// 			string candidate = digits[i] + digits[j];
	// 			yield return long.Parse(candidate);
	// 		}
	// 	}
	// }

	public long FindLargestPossibleJoltage(string bank)
	{
		return FindPossibleJoltages(bank).Max();
	}

	// We can make the algorithm more elegant by avoiding the string conversions.
	// However, this still works through all combinations, which is inefficient,
	// but ok for the low number of digits in the output.
	private IEnumerable<long> FindPossibleJoltages(string bank)
	{
		for (int i = 0; i < bank.Length - 1; i++)
		{
			for (int j = i + 1; j < bank.Length; j++)
			{
				// ASCII table math:
				long digit1 = bank[i] - '0';
				long digit2 = bank[j] - '0';
				yield return digit1 * 10 + digit2;
			}
		}
	}

	// Code golfing?
	// This saves on text characters, but is probably much harder to read for most developers.
	// private IEnumerable<long> FindPossibleJoltages(string bank) =>
	// 	bank.SelectMany((c1, i) =>
	// 		bank.Skip(i + 1)
	// 			.Select(c2 => (c1 - '0') * 10 + (c2 - '0')));

	// For part 2, we want to support 12 digits (which means arbitrary digits if we don't want to hardcode too much).
	public long FindLargestPossibleJoltage_FirstAttempt(string bank, int digits)
	{
		// return FindPossibleJoltages_BruteForce(bank, digits).Max();
		string s = new string(FindPossibleJoltages(bank, digits).ToArray());
		return long.Parse(s);
	}

	// The initial idea is to always extend the existing algorithm and just use brute force.
	// However, when we type it out, we immediately see, that the complexity is too high
	// and this solution, albeit correct, would not finish in time.
	// We don't bother rewriting is recursively or micro-optimizing the calls, because we know
	// that it's no use compared to the exponential complexity.
	private IEnumerable<long> FindPossibleJoltages_BruteForce(string bank, long digits)
	{
		Debug.Assert(digits == 12);
		int len = bank.Length;
		for (int i = 0; i < len - 1; i++)
		for (int j = i + 1; j < len; j++)
		for (int k = j + 1; k < len; k++)
		for (int l = k + 1; l < len; l++)
		for (int m = l + 1; m < len; m++)
		for (int n = m + 1; n < len; n++)
		for (int o = n + 1; o < len; o++)
		for (int p = o + 1; p < len; p++)
		for (int q = p + 1; q < len; q++)
		for (int r = q + 1; r < len; r++)
		for (int s = r + 1; s < len; s++)
		for (int t = s + 1; t < len; t++)
		{
			yield return
				(bank[i] - '0') * 100000000000L +
				(bank[j] - '0') * 10000000000L +
				(bank[k] - '0') * 1000000000L +
				(bank[l] - '0') * 100000000L +
				(bank[m] - '0') * 10000000L +
				(bank[n] - '0') * 1000000L +
				(bank[o] - '0') * 100000L +
				(bank[p] - '0') * 10000L +
				(bank[q] - '0') * 1000L +
				(bank[r] - '0') * 100L +
				(bank[s] - '0') * 10L +
				(bank[t] - '0') * 1L;
		}
	}

	// Instead, we need to use a greedy algorithm to solve the part 2 problem efficiently.
	// It's easier to think about this reversed: instead of starting with the input, we look at the ideal output.
	// - For the first digit in our output, find the highest digit of the input.
	//   But we need to leave enough digits to the right to find our other 11 digits.
	//   Hence, define a window within to search.
	// - With each iteration, the window left starts after the last pick. The window right advances by one step.
	private IEnumerable<char> FindPossibleJoltages(string bank, int digits)
	{
		// Example:
		// 234234234234278 (input  len 15)
		// 4   34234234278 (result len 12)
		//
		// [2342]34234234278 pick 4, leave 11 in rest -> window right 15 - (12 - 1) = 4
		// 234[23]4234234278 pick 3, leave 10         ->              15 - (12 - 2) = 5
		// 23423[4]234234278 pick 4, leave 9          -> window size is 1 and stays until end
		// 234234[2]34234278

		Debug.Assert(bank.Length >= digits);

		int windowStart = 0;
		for (int d = 0; d < digits; d++)
		{
			int windowEnd = bank.Length - (digits - (d + 1));

			long localMax = -1;
			char c = '\0';
			for (int j = windowStart; j < windowEnd; j++)
			{
				long digit = bank[j] - '0';
				if (digit > localMax)
				{
					localMax = digit;
					c = bank[j];
					windowStart = j + 1;
				}
			}

			yield return c;
		}
	}

	public long FindLargestPossibleJoltage(string bank, int digits)
	{
		return FindPossibleJoltages_Linq(bank, digits).Sum();
	}

	private IEnumerable<long> FindPossibleJoltages_Linq(string bank, int digits)
	{
		Debug.Assert(bank.Length >= digits);

		int windowStart = 0;
		for (int d = 0; d < digits; d++)
		{
			int windowEnd = bank.Length - (digits - (d + 1));

			var (maxDigit, maxIndex) = bank
				.Skip(windowStart).Take(windowEnd - windowStart)
				.Select((c, i) => (c - '0', i + windowStart))
				.MaxBy(x => x.Item1);

			yield return maxDigit * (long)Math.Pow(10, digits - d - 1);
			windowStart = maxIndex + 1;
		}
	}
}