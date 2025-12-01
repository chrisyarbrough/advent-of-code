public class Day9_Interactive : Day9
{
	public bool ConstantRedraw = false;
	
	// Example 1 = 5, Example 2 = 21
	public int Height = 5;
	
	// Example 1 : 6, Example 2 = 26
	public int Width = 6;

	public Day9_Interactive(IInput input) : base(input)
	{
	}

	private (int left, int top)? startCursor;

	private void PrepareForDrawing()
	{
		if (ConstantRedraw == false)
			return;

		Console.CursorVisible = false;

		if (startCursor.HasValue == false)
			startCursor = Console.GetCursorPosition();
		else
			Console.SetCursorPosition(startCursor.Value.left, startCursor.Value.top);
	}

	protected override void DrawBoard(Coord[] rope)
	{
		PrepareForDrawing();

		Coord head = rope[0];

		for (int y = -Height + 1; y <= 0; y++)
		{
			string line = "";
			for (int x = 0; x < Width; x++)
			{
				var coord = new Coord(y, x);

				int indexInRope = Array.IndexOf(rope, coord);

				if (coord == head)
					line += "H";
				else if (indexInRope != -1)
				{
					if (rope.Length <= 2)
						line += "T";
					else
						line += (indexInRope).ToString();
				}
				else
					line += ".";
			}

			Console.WriteLine(line);
		}

		Console.WriteLine();
		Console.ReadKey(intercept: true);
	}

	protected override void DrawVisitedPositions(HashSet<Coord> coords)
	{
		PrepareForDrawing();

		for (int y = -Height + 1; y <= 0; y++)
		{
			string line = "";
			for (int x = 0; x < Width; x++)
			{
				var coord = new Coord(y, x);
				if (coords.Contains(coord))
					line += "#";
				else
					line += ".";
			}

			Console.WriteLine(line);
		}

		Console.WriteLine();
	}
}