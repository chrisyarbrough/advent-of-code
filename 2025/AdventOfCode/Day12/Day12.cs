public class Day12 : Puzzle
{
	private record struct Shape
	{
		private readonly bool[,] grid;

		public Shape(string input)
		{
			string[] lines = input.Split("\n");
			grid = new bool[lines.Length, lines[0].Length];
			for (int y = 0; y < lines.Length; y++)
			for (int x = 0; x < lines[0].Length; x++)
				grid[y, x] = lines[y][x] == '#';
		}
	}

	private record struct Region
	{
		public readonly int Width;

		public readonly int Height;

		// Quantity of each shape (same index as shape collection).
		public readonly int[] PresentCounts;

		public Region(string line)
		{
			string[] sections = line.Split(":");
			var dimensions = sections[0].Split("x");
			Width = int.Parse(dimensions[0]);
			Height = int.Parse(dimensions[1]);

			var presentCounts = sections[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
			PresentCounts = new int[6];
			for (int i = 0; i < presentCounts.Length; i++)
				PresentCounts[i] = int.Parse(presentCounts[i]);
		}
	}

	public override object Part1(string input)
	{
		Shape[] shapes = new Shape[6];
		string[] sections = input.Split("\n\n");
		for (int i = 0; i < shapes.Length; i++)
			shapes[i] = new Shape(sections[i][3..]);

		var regionLines = sections[^1].Split("\n");
		Region[] regions = new Region[regionLines.Length];
		for (int i = 0; i < regionLines.Length; i++)
			regions[i] = new Region(regionLines[i]);

		return "";
	}

	public override object Part2(string input)
	{
		return "";
	}
}