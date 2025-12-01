using Day14Namespace;

public class Day14 : Puzzle
{
	public Day14(IInput input) : base(input)
	{
	}

	protected Dictionary<Coord, char> map = new();
	protected int yMax;
	protected bool simulating;
	protected bool hasFloor;
	protected int yFloor;

	private int restCount;
	private Coord activeSand;

	private readonly Coord[] directions = new Coord[]
	{
		new Coord(0, 1),
		new Coord(-1, 1),
		new Coord(1, 1),
	};

	public override object SolutionPart1()
	{
		hasFloor = false;
		CreateCaveMap();
		simulating = true;
		activeSand = new Coord(500, 0);
		Part1Body();
		return restCount;
	}

	public override object SolutionPart2()
	{
		hasFloor = true;
		CreateCaveMap();
		simulating = true;
		activeSand = new Coord(500, 0);
		Part1Body();
		return restCount;
	}

	protected virtual void Part1Body()
	{
		while (simulating)
		{
			Simulate();
		}
	}

	protected void Simulate()
	{
		foreach (Coord attempt in directions)
		{
			Coord targetCoord = activeSand + attempt;

			if (hasFloor == false && targetCoord.y >= yMax + 1)
			{
				// Falls into the abyss.
				simulating = false;
				return;
			}

			if (IsValidMove(targetCoord))
			{
				if (activeSand != new Coord(500, 0))
					map.Remove(activeSand);

				map[targetCoord] = 'o';
				activeSand = targetCoord;
				return;
			}
		}

		if (activeSand == new Coord(500, 0))
		{
			// Spawn point is blocked.
			simulating = false;
			map[activeSand] = 'o';
			restCount++;
			return;
		}

		// No move was possible, this sand is at rest.
		restCount++;
		// Spawn new sand
		activeSand = new Coord(500, 0);
	}

	private bool IsValidMove(Coord coord)
	{
		if (hasFloor && coord.y >= yFloor)
			return false;

		return map.ContainsKey(coord) == false;
	}

	private void CreateCaveMap()
	{
		foreach (string line in inputLines)
		{
			Coord[] path = ParseLineToPath(line).ToArray();

			foreach (Coord coord in GetRocksOnPath(path))
			{
				map[coord] = '#';
			}
		}

		// Spawn point.
		map[new Coord(500, 0)] = '+';

		yMax = map.Select(x => x.Key.y).Max();
		yFloor = yMax + 2;
	}

	private IEnumerable<Coord> ParseLineToPath(string line)
	{
		string[] rawCoords = line.Split(" -> ");
		foreach (string rawCoord in rawCoords)
		{
			yield return Coord.Parse(rawCoord);
		}
	}

	public IEnumerable<Coord> GetRocksOnPath(IList<Coord> path)
	{
		for (int i = 0; i < path.Count - 1; i++)
		{
			foreach (Coord coord in CreateRocksFromLine(path[i], path[i + 1]))
				yield return coord;
		}
	}

	public IEnumerable<Coord> CreateRocksFromLine(Coord start, Coord end)
	{
		var direction = new Coord(
			Math.Sign(end.x - start.x),
			Math.Sign(end.y - start.y));

		for (Coord coord = start; coord != end + direction; coord += direction)
		{
			yield return coord;
		}
	}
}