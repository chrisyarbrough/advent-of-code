public class Day4 : Puzzle
{
	public ConsoleRenderer Renderer;

	private char[,] grid;

	public override object Part1(string input)
	{
		grid = ConvertToGrid(input);
		return GetAccessibleRolls(grid).Count();
	}

	private static char[,] ConvertToGrid(string input)
	{
		string[] lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		int height = lines.Length;
		int width = lines[0].Length;
		var grid = new char[height, width];

		for (int y = 0; y < height; y++)
		for (int x = 0; x < width; x++)
			grid[y, x] = lines[y][x];

		return grid;
	}

	private static IEnumerable<(int y, int x)> GetAccessibleRolls(char[,] grid)
	{
		int height = grid.GetLength(0);
		int width = grid.GetLength(1);
		bool WithinBounds(int y, int x) => y >= 0 && y < height && x >= 0 && x < width;

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				if (grid[y, x] != '@')
					continue;

				var rollNeighbourCount = Directions()
					.Select(direction => (y: y + direction.y, x: x + direction.x))
					.Count(neighbour => WithinBounds(neighbour.y, neighbour.x) &&
					                    grid[neighbour.y, neighbour.x] == '@');

				if (rollNeighbourCount < 4)
					yield return (y, x);
			}
		}
	}

	private static IEnumerable<(int y, int x)> Directions()
	{
		yield return (1, 0);
		yield return (1, 1);
		yield return (0, 1);
		yield return (-1, 1);

		yield return (-1, 0);
		yield return (-1, -1);
		yield return (0, -1);
		yield return (1, -1);
	}

	public override object Part2(string input)
	{
		grid = ConvertToGrid(input);
		Renderer.Render(grid);

		int accessibleRollsCountTotal = 0;

		removeRolls:
		int accessibleRollsCount = 0;
		foreach (var roll in GetAccessibleRolls(grid))
		{
			grid[roll.y, roll.x] = 'x';
			accessibleRollsCount++;
			accessibleRollsCountTotal++;
		}
		Renderer.Render(grid);
		if (accessibleRollsCount > 0)
			goto removeRolls;

		return accessibleRollsCountTotal;
	}
}