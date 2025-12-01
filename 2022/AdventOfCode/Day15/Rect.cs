namespace AdventOfCode.Day15;

using Day14Namespace;

public record struct Rect(int x, int y, int width, int height)
{
	public int Left => x;
	public int Right => x + width - 1;
	public int Top => y;
	public int Bottom => y + height - 1;

	public IEnumerable<Coord> Corners
	{
		get
		{
			yield return new Coord(Left, Top);
			yield return new Coord(Right, Top);
			yield return new Coord(Right, Bottom);
			yield return new Coord(Left, Bottom);
		}
	}

	public IEnumerable<Rect> Split()
	{
		var w0 = width / 2;
		var w1 = width - w0;
		var h0 = height / 2;
		var h1 = height - h0;
		yield return new Rect(Left, Top, w0, h0);
		yield return new Rect(Left + w0, Top, w1, h0);
		yield return new Rect(Left, Top + h0, w0, h1);
		yield return new Rect(Left + w0, Top + h0, w1, h1);
	}
}