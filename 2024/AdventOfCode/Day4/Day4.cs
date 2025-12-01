using System.Diagnostics;

public class Day4 : Puzzle
{
	// ReSharper disable StringLiteralTypo
	// ReSharper disable StringLiteralTypo
	private readonly string[] searchPatternsPart1 =
	[
		"XMAS",
		"SAMX",
		"""
		X
		M
		A
		S
		""",
		"""
		S
		A
		M
		X
		""",
		"""
		X   
		 M  
		  A 
		   S
		""",
		"""
		S   
		 A  
		  M 
		   X
		""",
		"""
		   X
		  M 
		 A  
		S   
		""",
		"""
		   S
		  A 
		 M  
		X   
		""",
	];

	private readonly string[] searchPatternsPart2 =
	[
		"""
		M S
		 A 
		M S
		""",
		"""
		S M
		 A 
		S M
		""",
		"""
		M M
		 A 
		S S
		""",
		"""
		S S
		 A 
		M M
		""",
	];
	// ReSharper enable StringLiteralTypo

	public override object Part1(string input)
	{
		return Solve(input, searchPatternsPart1);
	}

	private static char[,] CreateGrid(string[] lines)
	{
		Debug.Assert(lines.Length > 0);
		char[,] grid = new char[lines.Length, lines[0].Length];

		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				grid[i, j] = lines[i][j];
			}
		}

		return grid;
	}

	private static bool IsMatch(char[,] searchPattern, int i, int j, char[,] grid)
	{
		bool isMatch = true;
		int width = grid.GetLength(0);
		int height = grid.GetLength(1);

		for (int l = 0; l < searchPattern.GetLength(0); l++)
		{
			for (int m = 0; m < searchPattern.GetLength(1); m++)
			{
				char patternChar = searchPattern[l, m];

				if (patternChar == ' ')
					continue;

				if (i + l >= width || j + m >= height || grid[i + l, j + m] != patternChar)
				{
					isMatch = false;
					break;
				}
			}
		}
		return isMatch;
	}

	public override object Part2(string input)
	{
		return Solve(input, searchPatternsPart2);
	}

	private static object Solve(string input, string[] searchPatterns)
	{
		char[,] grid = CreateGrid(input.Lines());

		int[] countsPerPattern = new int[searchPatterns.Length];

		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				for (int k = 0; k < searchPatterns.Length; k++)
				{
					char[,] searchPattern = CreateGrid(searchPatterns[k].Split('\n'));

					if (IsMatch(searchPattern, i, j, grid))
						countsPerPattern[k]++;
				}
			}
		}

		return countsPerPattern.Sum();
	}
}