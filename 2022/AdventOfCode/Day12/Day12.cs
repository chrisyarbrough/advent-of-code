using System.Diagnostics;

public class Day12 : Puzzle
{
	public Day12(IInput input) : base(input)
	{
	}

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
	}

	record Node
	{
		public Coord coord { get; set; }
		public char symbol { get; set; }

		public Node(Coord coord, char symbol)
		{
			this.coord = coord;
			this.symbol = symbol;
		}

		public Node(int x, int y, char symbol)
		{
			this.coord = new Coord(x, y);
			this.symbol = symbol;
		}
	}

	public override object SolutionPart1()
	{
		Node? maybeStart = null;
		Node? maybeGoal = null;

		string[] lines = input.Lines();
		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				char symbol = lines[y][x];

				if (symbol == 'S')
					maybeStart = new Node(x, y, 'a');
				else if (symbol == 'E')
					maybeGoal = new Node(x, y, 'z');
			}
		}

		Debug.Assert(maybeStart != null);
		Debug.Assert(maybeGoal != null);

		Node start = maybeStart;
		Node goal = maybeGoal;

		for (int i = 0; i < lines.Length; i++)
		{
			lines[i] = lines[i].Replace("S", "a").Replace("E", "z");
		}

		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				char symbol = lines[y][x];

				var neighborsList = new List<Node>();

				foreach (Coord coord in GetNeighbourCoords(new Coord(x, y)))
				{
					// Within bounds of map.
					if (coord.x >= 0 && coord.x < lines[y].Length &&
					    coord.y >= 0 && coord.y < lines.Length)
					{
						char otherSymbol = lines[coord.y][coord.x];
						if (otherSymbol <= symbol + 1)
							neighborsList.Add(new Node(coord, otherSymbol));
					}
				}

				this.neighboursLookup[new Node(x, y, symbol)] = neighborsList;
			}
		}

		return FindShortestPath(start, goal);
	}

	private Dictionary<Node, List<Node>> neighboursLookup = new();

	private IEnumerable<Coord> GetNeighbourCoords(Coord coord)
	{
		yield return new Coord(coord.x, coord.y + 1);
		yield return new Coord(coord.x + 1, coord.y);
		yield return new Coord(coord.x, coord.y - 1);
		yield return new Coord(coord.x - 1, coord.y);
	}

	public override object SolutionPart2()
	{
		var startNodes = new List<Node>();
		Node? maybeGoal = null;

		string[] lines = input.Lines();
		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				char symbol = lines[y][x];

				if (symbol == 'S' || symbol == 'a')
					startNodes.Add(new Node(x, y, 'a'));
				else if (symbol == 'E')
					maybeGoal = new Node(x, y, 'z');
			}
		}

		Debug.Assert(maybeGoal != null);

		for (int i = 0; i < lines.Length; i++)
		{
			lines[i] = lines[i].Replace("S", "a").Replace("E", "z");
		}

		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				char symbol = lines[y][x];

				var neighborsList = new List<Node>();

				foreach (Coord coord in GetNeighbourCoords(new Coord(x, y)))
				{
					// Within bounds of map.
					if (coord.x >= 0 && coord.x < lines[y].Length &&
					    coord.y >= 0 && coord.y < lines.Length)
					{
						char otherSymbol = lines[coord.y][coord.x];
						if (otherSymbol <= symbol + 1)
							neighborsList.Add(new Node(coord, otherSymbol));
					}
				}

				this.neighboursLookup[new Node(x, y, symbol)] = neighborsList;
			}
		}

		Node goal = maybeGoal;

		return startNodes.Select(x => FindShortestPath(x, goal)).Min();
	}

	private int FindShortestPath(Node start, Node goal)
	{
		// Breadth First Search
		var frontier = new Queue<Node>();
		frontier.Enqueue(start);
		// Asking from which node (value) a node (key) came from:
		var cameFrom = new Dictionary<Node, Node?>();
		cameFrom[start] = null;

		while (frontier.Count > 0)
		{
			Node current = frontier.Dequeue();
			foreach (Node neighbour in neighboursLookup[current])
			{
				if (cameFrom.ContainsKey(neighbour) == false)
				{
					frontier.Enqueue(neighbour);
					cameFrom[neighbour] = current;
				}
			}
		}

		// No path found.
		if (cameFrom.ContainsKey(goal) == false)
			return int.MaxValue;

		// To find the shortest path, traverse back from the goal to the start.
		Node currentOnPath = goal;
		var path = new List<Node>();
		while (currentOnPath != start)
		{
			path.Add(currentOnPath);
			currentOnPath = cameFrom[currentOnPath]!;
		}

		// Path is now in reverse order of course, but we don't care.
		return path.Count();
	}
}