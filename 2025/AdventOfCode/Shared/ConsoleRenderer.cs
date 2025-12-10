public class ConsoleRenderer
{
	public bool Enabled { get; set; } = true;

	public void Render(char[,] grid)
	{
		if (Enabled == false)
			return;

		Console.Clear();
		string s = string.Empty;

		for (int y = 0; y < grid.GetLength(0); y++)
		{
			for (int x = 0; x < grid.GetLength(1); x++)
				s += grid[y, x];
			s += Environment.NewLine;
		}
		Console.WriteLine(s);
		Console.ReadKey(intercept: true);
	}

	public void Render(char[][] grid)
	{
		if (Enabled == false)
			return;

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