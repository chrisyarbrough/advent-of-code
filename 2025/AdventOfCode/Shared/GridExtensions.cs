public static class GridExtensions
{
	public static IEnumerable<(int x, int y)> GetCoords<T>(this T[,] grid)
	{
		for (int y = 0; y < grid.GetLength(0); y++)
		{
			for (int x = 0; x < grid.GetLength(1); x++)
			{
				yield return (x, y);
			}
		}
	}
}