using System.Text;
using Day14Namespace;

public class ConsoleBuffer
{
	private (int Left, int Top)? cursorStartPosition;
	private StringBuilder stringBuilder = new();
	private readonly int left;
	private readonly int top;
	private readonly int width;
	private readonly int height;

	public ConsoleBuffer(int left, int top, int width, int height)
	{
		this.left = left;
		this.top = top;
		this.width = width;
		this.height = height;
	}

	public void Init()
	{
		if (cursorStartPosition.HasValue == false)
			cursorStartPosition = Console.GetCursorPosition();
	}

	public void Write(string s)
	{
		stringBuilder.Append(s);
	}

	public void Write(char c)
	{
		stringBuilder.Append(c);
	}

	public void WriteLine()
	{
		stringBuilder.AppendLine();
	}

	public void Flush()
	{
		Console.SetCursorPosition(
			cursorStartPosition.Value.Left,
			cursorStartPosition.Value.Top);

		Console.WriteLine(stringBuilder.ToString());
		stringBuilder.Clear();
	}
}

public class Day14_Interactive : Day14
{
	private ConsoleBuffer buffer;

	public Day14_Interactive(IInput input) : base(input)
	{
	}

	protected override void Part1Body()
	{
		int xMin = map.Select(s => s.Key.x).Min() - 10;
		int xMax = map.Select(s => s.Key.x).Max() + 12;
		int yMin = map.Select(s => s.Key.y).Min();
		int yMaxDrawing = Math.Max(yMax + 1, yFloor + 1);

		buffer = new ConsoleBuffer(
			left: 0,
			top: 1,
			width: xMax - xMin,
			height: yMaxDrawing - yMin);

		DrawMap(xMin, xMax, yMin, yMaxDrawing);

		// while (Console.ReadKey(intercept: true).Key != ConsoleKey.Q)
		while (simulating)
		{
			Simulate();
			DrawMap(xMin, xMax, yMin, yMaxDrawing);
			Thread.Sleep(10);
		}
	}

	private void DrawMap(int xMin, int xMax, int yMin, int yMax)
	{
		buffer.Init();

		DrawHeader(xMin, xMax);

		for (int y = yMin; y <= yMax; y++)
		{
			buffer.Write(y.ToString("000") + " ");
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

		for (int y = 0; y < 3; y++)
		{
			buffer.Write("   ");
			buffer.Write(labelMin[y]);

			for (int x = xMin + 1; x < xMid; x++)
				buffer.Write(" ");

			buffer.Write(labelMid[y]);

			for (int x = xMid + 1; x < xMax; x++)
				buffer.Write(" ");

			buffer.Write(labelMax[y]);
			buffer.WriteLine();
		}
	}

	private char GetSymbol(Coord coord)
	{
		if (map.TryGetValue(coord, out char c))
			return c;

		if (hasFloor && coord.y == yFloor)
			return 'm';

		return '.'; // Air
	}
}