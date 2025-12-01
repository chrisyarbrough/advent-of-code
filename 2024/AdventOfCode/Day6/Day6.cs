using System.Diagnostics;

public class Guard
{
	public Coord Position;
	public Coord Heading;
}

public class Day6 : Puzzle
{
	public MapRenderer Renderer { get; init; } = new MapRenderer();

	public static class Symbol
	{
		public const char Guard = '^';
		public const char Obstacle = '#';
		public const char Free = '.';
	}

	public override object Part1(string input)
	{
		(char[,] map, Guard guard) = CreateMap(input.Lines());
		Renderer.Print(map, guard);
		return Simulate(map, guard).visited.Count;
	}

	private bool WithinBounds(Coord position, char[,] map)
	{
		return position.y >= 0 && position.y < map.GetLength(0) &&
		       position.x >= 0 && position.x < map.GetLength(1);
	}

	private (char[,], Guard) CreateMap(string[] lines)
	{
		Debug.Assert(lines.Length > 0);
		Debug.Assert(lines.All(line => line.Length == lines.First().Length));

		char[,] map = new char[lines.Length, lines.First().Length];
		Guard guard = new() { Heading = new(-1, 0) };

		for (int y = 0; y < lines.Length; y++)
		{
			string line = lines[y];
			for (int x = 0; x < line.Length; x++)
			{
				char symbol = line[x];
				map[y, x] = symbol;

				if (symbol == Symbol.Guard)
					guard.Position = new(y, x);
			}
		}

		return (map, guard);
	}

	public override object Part2(string input)
	{
		string[] lines = input.Lines();
		(char[,] map, Guard guard) = CreateMap(lines);



		int loopCount = 0;

		// Place an obstacle on any free spot.
		foreach (Coord coord in Simulate(map, guard).visited
			         .Where(coord => map[coord.y, coord.x] == Symbol.Free))
		{
			map[coord.y, coord.x] = Symbol.Obstacle;

			if (Simulate(map, guard).isLoop)
				loopCount++;

			// Reset map to original state.
			(map, guard) = CreateMap(lines);
		}

		// foreach (Coord coord in Simulate(map, guard).visited)
		// {
		// 	char symbol = map[coord.y, coord.x];
		// 	if (symbol != Symbol.Free)
		// 		continue;
		//
		// 	// Place an obstacle on any free spot.
		// 	map[coord.y, coord.x] = Symbol.Obstacle;
		// 	(_, bool isLoop) = Simulate(map, guard);
		// 	if (isLoop)
		// 		loopCount++;
		//
		// 	// Reset map to original state.
		// 	(map, guard) = CreateMap(lines);
		// }

		return loopCount;
	}

	private (HashSet<Coord> visited, bool isLoop) Simulate(char[,] map, Guard guard)
	{
		// Run the simulation until either the guard leaves the map, or a loop is detected.
		// Loop detection problems:
		// Revisiting the startPosition is not a sufficient condition, since the path could continue and loop later.
		// However, we can store the current path in a HashSet. Whenever the path starts to include visited nodes,
		// start keeping track of the re-visited nodes. Once we have re-visited all nodes of the set, it's a loop.

		HashSet<Coord> visited = [guard.Position];
		int revisitedNodeCount = 0;

		// Simulate movement.
		while (WithinBounds(guard.Position, map))
		{
			Coord nextPosition = guard.Position + guard.Heading;

			if (!WithinBounds(nextPosition, map))
				break;

			// If obstacle in front, change direction by rotating 90 degrees right.
			// Special case: handle dead ends by turning twice.
			while (map[nextPosition.y, nextPosition.x] == Symbol.Obstacle)
			{
				guard.Heading = guard.Heading.TurnRight();
				nextPosition = guard.Position + guard.Heading;
			}

			map[guard.Position.y, guard.Position.x] = Symbol.Free;
			guard.Position = nextPosition;
			map[guard.Position.y, guard.Position.x] = Symbol.Guard;

			if (visited.Add(guard.Position))
			{
				revisitedNodeCount = 0;
			}
			else
			{
				revisitedNodeCount++;
			}

			if (revisitedNodeCount == visited.Count)
				return (visited, isLoop: true);
		}

		return (visited, isLoop: false);
	}
}