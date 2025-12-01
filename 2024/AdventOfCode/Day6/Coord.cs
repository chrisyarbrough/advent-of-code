/// <summary>
/// Y-axis is down.
/// </summary>
public record Coord(int y, int x)
{
	public static Coord operator +(Coord a, Coord b)
	{
		return new(a.y + b.y, a.x + b.x);
	}

	public Coord TurnRight() => new(x, -y);
}