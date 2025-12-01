namespace Day14Namespace;

public struct Coord
{
	public readonly int x;
	public readonly int y;

	public Coord(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override string ToString()
	{
		return $"{x} | {y}";
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ (y.GetHashCode() << 2);
	}

	public bool Equals(Coord other)
	{
		return x == other.x && y == other.y;
	}

	public override bool Equals(object? obj)
	{
		return obj is Coord other && Equals(other);
	}

	public static bool operator ==(Coord a, Coord b)
	{
		return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=(Coord a, Coord b)
	{
		return a.x != b.x || a.y != b.y;
	}

	public static Coord operator +(Coord a, Coord b)
	{
		return new Coord(a.x + b.x, a.y + b.y);
	}

	public static Coord operator -(Coord a, Coord b)
	{
		return new Coord(a.x - b.x, a.y - b.y);
	}

	public static Coord Parse(string rawCoord)
	{
		var split = rawCoord.Split(",");
		return new Coord(int.Parse(split[0]), int.Parse(split[1]));
	}
}