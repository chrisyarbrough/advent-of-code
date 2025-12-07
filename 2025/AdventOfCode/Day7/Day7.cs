using System.Diagnostics.CodeAnalysis;

public class Day7 : Puzzle
{
	public Action RenderGrid;

	private char[][] grid;

	public Day7()
	{
		RenderGrid = RenderToConsole;
	}

	public override object Part1(string input)
	{
		grid = input
			.Trim()
			.Split("\n")
			.Select(row => row.ToCharArray())
			.ToArray();

		RenderGrid();

		int startX = Array.IndexOf(grid[0], 'S');
		int splitCount = 0;
		Simulate(1, startX, ref splitCount);

		RenderGrid();

		return splitCount;
	}

	[SuppressMessage("ReSharper", "TailRecursiveCall")]
	private void Simulate(int y, int x, ref int splitCount)
	{
		grid[y][x] = '|';
		int nextY = y + 1;
		if (nextY >= grid.Length)
			return;

		char next = grid[nextY][x];

		if (next == '^')
		{
			// Split tachyon beam.
			splitCount++;
			Simulate(nextY, x - 1, ref splitCount);
			Simulate(nextY, x + 1, ref splitCount);
		}
		else if (next == '.')
		{
			Simulate(nextY, x, ref splitCount);
		}
	}

	public override object Part2(string input)
	{
		return "";
	}

	public void RenderToConsole()
	{
		Console.Clear();
		string s = string.Empty;
		for (int y = 0; y < grid.Length; y++)
		{
			for (int x = 0; x < grid[y].Length; x++)
				s += grid[y][x];
			s += Environment.NewLine;
		}
		Console.WriteLine(s);
		Console.ReadKey(intercept: true);
	}
}