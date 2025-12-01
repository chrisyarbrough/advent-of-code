public class Day9 : Puzzle
{
	public Day9(IInput input) : base(input)
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

		public override string ToString()
		{
			return $"(y{Y}, x{X})";
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ (Y.GetHashCode() << 2);
		}

		public static Coord operator *(Coord a, int i)
		{
			return new Coord
			(
				a.Y * i,
				a.X * i
			);
		}

		public static Coord operator +(Coord a, Coord b)
		{
			return new Coord
			(
				a.Y + b.Y,
				a.X + b.X
			);
		}

		public static Coord operator -(Coord a, Coord b)
		{
			return new Coord
			(
				a.Y - b.Y,
				a.X - b.X
			);
		}

		public static bool AreTouching(Coord a, Coord b)
		{
			return Math.Abs(a.X - b.X) < 2 && Math.Abs(a.Y - b.Y) < 2;
		}

		public static bool operator ==(Coord a, Coord b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(Coord a, Coord b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

		public bool Equals(Coord other)
		{
			return Y == other.Y && X == other.X;
		}

		public override bool Equals(object? obj)
		{
			return obj is Coord other && Equals(other);
		}

		public static IEnumerable<Coord> AllDirections()
		{
			yield return new Coord(-1, 0);
			yield return new Coord(0, 1);
			yield return new Coord(1, 0);
			yield return new Coord(0, -1);
		}

		public Coord Normalized()
		{
			return new Coord(
				Math.Clamp(this.Y, -1, 1),
				Math.Clamp(this.X, -1, 1));
		}
	}

	public override object SolutionPart1()
	{
		// [0] is head
		// [1] is tail
		var rope = new Coord[] { new Coord(0, 0), new Coord(0, 0) };

		var visitedTailPositions = new HashSet<Coord>() { rope[1] };

		foreach (Coord moveCommand in ParseCommands(inputLines))
		{
			DrawBoard(rope);

			rope[0] += moveCommand;
			UpdateRope(rope);
			visitedTailPositions.Add(rope[1]);
		}

		DrawBoard(rope);
		DrawVisitedPositions(visitedTailPositions);
		return visitedTailPositions.Count;
	}

	protected virtual void DrawBoard(Coord[] rope)
	{
	}

	protected virtual void DrawVisitedPositions(HashSet<Coord> coords)
	{
	}

	private void UpdateRope(Coord[] rope)
	{
		for (int i = 1; i < rope.Length; i++)
		{
			rope[i] = Follow(rope[i], rope[i - 1]);
		}
	}

	private Coord Follow(Coord tail, Coord head)
	{
		/*
		// If head is two steps ahead in any straight direction, follow up.
		foreach (Coord direction in Coord.AllDirections())
		{
			if (tail + direction * 2 == head)
				return tail + direction;
		}

		// If head and tail aren't touching, follow diagonally.
		if (Coord.AreTouching(tail, head) == false)
		{
			return tail + (head - tail).Normalized();
		}

		return tail;
		*/

		int distanceX = head.X - tail.X;
		int distanceY = head.Y - tail.Y;

		if (Math.Abs(distanceX) > 1 || Math.Abs(distanceY) > 1)
		{
			return tail + new Coord(Math.Sign(distanceY), Math.Sign(distanceX));
		}

		return tail;
	}

	private IEnumerable<Coord> ParseCommands(IEnumerable<string> input)
	{
		foreach (string line in input)
		{
			string[] split = line.Split(" ");
			string directionCommand = split[0];
			int count = int.Parse(split[1]);

			for (int i = 0; i < count; i++)
			{
				if (directionCommand == "U")
					yield return new Coord(-1, 0);
				else if (directionCommand == "R")
					yield return new Coord(0, 1);
				else if (directionCommand == "D")
					yield return new Coord(1, 0);
				else if (directionCommand == "L")
					yield return new Coord(0, -1);
			}
		}
	}

	public override object SolutionPart2()
	{
		Coord[] rope = Enumerable.Repeat(new Coord(0, 0), 10).ToArray();

		var visitedTailPositions = new HashSet<Coord>() { rope[rope.Length - 1] };

		foreach (Coord moveCommand in ParseCommands(inputLines))
		{
			DrawBoard(rope);

			rope[0] += moveCommand;
			UpdateRope(rope);
			visitedTailPositions.Add(rope[rope.Length - 1]);
		}

		DrawBoard(rope);
		DrawVisitedPositions(visitedTailPositions);
		return visitedTailPositions.Count;
	}
}