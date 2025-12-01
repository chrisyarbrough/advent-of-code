public class MapRenderer
{
	private (int left, int top)? initialCursorPosition;

	public virtual void Print(char[,] map, Guard guard)
	{
		initialCursorPosition ??= Console.GetCursorPosition();
		Console.SetCursorPosition(initialCursorPosition.Value.left, initialCursorPosition.Value.top);

		for (int y = 0; y < map.GetLength(0); y++)
		{
			for (int x = 0; x < map.GetLength(1); x++)
			{
				char symbol = map[y, x];
				if (symbol == Day6.Symbol.Guard)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					symbol = GetGuardSymbol(guard.Heading);
				}
				else
				{
					Console.ResetColor();
				}

				Console.Write(symbol);
			}
			Console.WriteLine();
		}

		Console.ReadKey(intercept: true);
	}

	private static char GetGuardSymbol(Coord heading)
	{
		return heading switch
		{
			(-1, 0) => '↑',
			(0, 1) => '→',
			(1, 0) => '↓',
			(0, -1) => '←',
			_ => throw new ArgumentOutOfRangeException(nameof(heading)),
		};
	}
}

public class NullRenderer : MapRenderer
{
	public override void Print(char[,] map, Guard guardHeading)
	{
	}
}