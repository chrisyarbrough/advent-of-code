namespace AdventOfCode.Day15;

using Day14Namespace;

public class Day15_Interactive : Day15
{
	private ConsoleBuffer buffer = new();

	public Day15_Interactive(IInput input) : base(input)
	{
	}

	protected override void DrawMap()
	{
		int xMin = map.Select(s => s.Key.x).Min();
		int xMax = map.Select(s => s.Key.x).Max();
		int yMin = map.Select(s => s.Key.y).Min();
		int yMax = map.Select(s => s.Key.y).Max();

		DrawMap(xMin, xMax, yMin, yMax);
	}

	private void DrawMap(int xMin, int xMax, int yMin, int yMax)
	{
		buffer.Init();

		DrawHeader(xMin, xMax);

		for (int y = yMin; y <= yMax; y++)
		{
			buffer.Write(y.ToString().PadLeft(3) + " ");
			for (int x = xMin; x <= xMax; x++)
			{
				char symbol = GetSymbol(new Coord(x, y));
				buffer.Write(symbol);
			}

			buffer.WriteLine();
		}

		buffer.Flush();
	}

	private void DrawHeader(int xMin, int xMax)
	{
		int xMid = (xMin + xMax) / 2;
		string labelMin = xMin.ToString();
		string labelMid = xMid.ToString();
		string labelMax = xMax.ToString();

		int height = Math.Max(Math.Max(labelMin.Length, labelMid.Length), labelMax.Length);

		for (int y = 0; y < height; y++)
		{
			buffer.Write("    ");
			buffer.Write(labelMin[y]);

			for (int x = xMin + 1; x < xMid; x++)
				buffer.Write(" ");

			if (y < labelMid.Length)
				buffer.Write(labelMid[y]);

			for (int x = xMid + 1; x < xMax; x++)
				buffer.Write(" ");

			if (y < labelMax.Length)
				buffer.Write(labelMax[y]);

			buffer.WriteLine();
		}
	}

	private char GetSymbol(Coord coord)
	{
		if (map.TryGetValue(coord, out char c))
			return c;

		return '.';
	}
}

public class Day15_RectSplitTest : Puzzle
{
	public Day15_RectSplitTest(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		//DrawDemo();
		return 0;
	}

	public override object SolutionPart2()
	{
		//DrawDemo();
		
		
		

		return 0;
	}

	private void DrawDemo()
	{
		var rect = new Rect(0, 0, 3, 3);
		SplitAndDraw(rect);
	}

	private static void SplitAndDraw(Rect rect)
	{
		if (rect.width == 0 || rect.height == 0)
			return;

		Console.Clear();

		Rect[] subRects = rect.Split().ToArray();

		var symbols = new char[] { 'M', 'H', 'U', 'W' };

		for (int y = 0; y < rect.height; y++)
		{
			for (int x = 0; x < rect.width; x++)
			{
				for (int i = 0; i < symbols.Length; i++)
				{
					if (x >= subRects[i].Left && x <= subRects[i].Right &&
					    y >= subRects[i].Top && y <= subRects[i].Bottom)
					{
						Console.Write(symbols[i]);
					}
				}
			}

			Console.WriteLine();
		}

		Console.ReadKey();
		SplitAndDraw(subRects[0]);
	}
}