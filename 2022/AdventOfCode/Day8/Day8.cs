public class Day8 : Puzzle
{
	public Day8(IInput input) : base(input)
	{
	}

	public struct Coord
	{
		public readonly int Y;
		public readonly int X;

		public Coord(int y, int x)
		{
			this.Y = y;
			this.X = x;
		}

		public static Coord operator +(Coord a, Coord b)
		{
			return new Coord
			(
				a.Y + b.Y,
				a.X + b.X
			);
		}

		public static IEnumerable<Coord> AllDirections()
		{
			yield return new Coord(-1, 0);
			yield return new Coord(0, 1);
			yield return new Coord(1, 0);
			yield return new Coord(0, -1);
		}
	}

	public class TreeMap
	{
		private int ySize => heights.GetLength(0);
		private int xSize => heights.GetLength(1);

		private readonly int[,] heights;

		public TreeMap(IEnumerable<string> inputLines)
		{
			string[][] trees = inputLines.Select(y => y.Select(
				x => x.ToString()).ToArray()).ToArray();

			// Assuming the input is rectangular.
			heights = new int[trees.Length, trees[0].Length];

			for (int y = 0; y < trees.Length; y++)
			{
				for (int x = 0; x < trees[y].Length; x++)
				{
					heights[y, x] = int.Parse(trees[y][x]);
				}
			}
		}

		public IEnumerable<(int y, int x)> AllCoords() =>
			from y in Enumerable.Range(0, ySize)
			from x in Enumerable.Range(0, xSize)
			select (y, x);

		public int TreeHeight(int y, int x) => heights[y, x];

		private bool InRange(int y, int x)
		{
			return y >= 0 && y < ySize &&
			       x >= 0 && x < xSize;
		}

		public IEnumerable<int> TreesInDirection(Coord tree, Coord direction)
		{
			Coord coord = tree + direction;
			while (InRange(coord.Y, coord.X))
			{
				yield return TreeHeight(coord.Y, coord.X);
				coord += direction;
			}
		}
	}

	public override object SolutionPart1()
	{
		// Find the number of trees that are visible from outside the grid.
		var treeMap = new TreeMap(inputLines);
		return treeMap.AllCoords()
			.Where(coord => IsVisible(treeMap, coord.y, coord.x)).Count();
	}

	private static bool IsVisible(TreeMap treeMap, int y, int x)
	{
		int treeHeight = treeMap.TreeHeight(y, x);

		foreach (Coord direction in Coord.AllDirections())
		{
			if (treeMap.TreesInDirection(new Coord(y, x), direction).All(i => i < treeHeight))
				return true;
		}

		return false;
	}

	public override object SolutionPart2()
	{
		// Find the tree with the highest scenic score.
		var treeMap = new TreeMap(inputLines);
		return treeMap.AllCoords()
			.Select(coord => ScenicScore(treeMap, coord.y, coord.x)).Max();
	}

	private static int ScenicScore(TreeMap treeMap, int y, int x)
	{
		int treeHeight = treeMap.TreeHeight(y, x);

		int score = 1;

		foreach (Coord direction in Coord.AllDirections())
		{
			int directionScore = ViewDistance(treeMap.TreesInDirection(new Coord(y, x), direction), treeHeight);
			score *= directionScore;
		}

		return score;
	}

	public static int ViewDistance(IEnumerable<int> heights, int referenceHeight)
	{
		int distance = 0;
		foreach (int height in heights)
		{
			if (height >= referenceHeight)
				return distance + 1;

			distance++;
		}

		return distance;
	}
}