using Coord = (int x, int y);

public class Day9 : Puzzle
{
	public readonly ConsoleRenderer Renderer = new();

	public override object Part1(string input)
	{
		List<Coord> redTileCoords = input
			.Trim()
			.Split("\n")
			.Select(line => line.Split(","))
			.Select(components => (int.Parse(components[0]), int.Parse(components[1])))
			.ToList();

		char[,] grid = new char[9, 14];
		if (Renderer.Enabled)
		{
			foreach ((int x, int y) in grid.GetCoords())
				grid[y, x] = '.';

			foreach ((int x, int y) in redTileCoords)
				grid[y, x] = '#';

			Renderer.Render(grid);
		}

		long largestArea = 0;
		(Coord, Coord) largestRect = default;

		for (int i = 0; i < redTileCoords.Count; i++)
		{
			Coord coord = redTileCoords[i];
			for (int j = i + 1; j < redTileCoords.Count; j++)
			{
				Coord nextCoord = redTileCoords[j];

				// Create a rectangle:
				long width = Math.Abs(nextCoord.x - coord.x) + 1;
				long height = Math.Abs(nextCoord.y - coord.y) + 1;
				long area = width * height;
				if (area > largestArea)
				{
					largestArea = area;
					largestRect = (coord, nextCoord);
				}
			}
		}
		if (Renderer.Enabled)
		{
			foreach ((int x, int y) in GetMinMaxRectCoords(largestRect.Item1, largestRect.Item2))
				grid[y, x] = 'o';
		}
		Renderer.Render(grid);
		Console.WriteLine($"Area: {largestArea}");
		return largestArea;
	}

	private static IEnumerable<Coord> GetMinMaxRectCoords(Coord cornerA, Coord cornerB)
	{
		int minY = Math.Min(cornerA.y, cornerB.y);
		int maxY = Math.Max(cornerA.y, cornerB.y);

		int minX = Math.Min(cornerA.x, cornerB.x);
		int maxX = Math.Max(cornerA.x, cornerB.x);

		for (int y = minY; y <= maxY; y++)
		for (int x = minX; x <= maxX; x++)
			yield return new Coord(x, y);
	}

	public override object Part2(string input)
	{
		return "";
	}
}