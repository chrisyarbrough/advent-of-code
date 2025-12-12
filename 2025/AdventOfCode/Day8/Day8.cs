using Position = (int x, int y, int z);
using Connection = ((int x, int y, int z), (int x, int y, int z));

public class Day8 : Puzzle
{
	public int MaxCount = 1000;

	public override object Part1(string input)
	{
		List<HashSet<Position>> circuits = [];

		HashSet<Position> FindCircuit(Position position)
		{
			return circuits.FirstOrDefault(circuit => circuit.Contains(position));
		}

		foreach (var connection in FindConnections(input))
		{
			var circuit1 = FindCircuit(connection.Item1);
			var circuit2 = FindCircuit(connection.Item2);

			// Merge circuits.
			if (circuit1 != null && circuit2 != null && circuit1 != circuit2)
			{
				foreach (var p in circuit2)
					circuit1.Add(p);
				circuits.Remove(circuit2);
				continue;
			}

			var circuit = circuit1 ?? circuit2;
			if (circuit != null)
			{
				// Add to existing circuit.
				circuit.Add(connection.Item1);
				circuit.Add(connection.Item2);
			}
			else
			{
				// Start new circuit.
				circuits.Add([connection.Item1, connection.Item2]);
			}
		}

		return circuits
			.OrderByDescending(c => c.Count)
			.Take(3)
			.Select(c => c.Count)
			.Aggregate((a, b) => a * b);
	}

	public List<Connection> FindConnections(string input)
	{
		HashSet<Connection> allConnections = FindAllConnections(input);

		// Starting with the shortest connection.
		List<Connection> shortestConnections = [];

		while (allConnections.Count > 0 && shortestConnections.Count < MaxCount)
		{
			double shortestLength = double.MaxValue;
			Connection shortestConnection = default;
			foreach (Connection connection in allConnections)
			{
				double length = LengthSquared(connection);
				if (length < shortestLength)
				{
					shortestLength = length;
					shortestConnection = connection;
				}
			}
			shortestConnections.Add(shortestConnection);
			allConnections.Remove(shortestConnection);
		}

		return shortestConnections;
	}

	private HashSet<Connection> FindAllConnections(string input)
	{
		Position[] positions = GetPositions(input);

		return positions
			.SelectMany((p1, i) => positions
				.Skip(i + 1)
				.Select(p2 => (p1, p2)))
			.ToHashSet();
	}

	private static Position[] GetPositions(string input) => input
		.Trim()
		.Split(Environment.NewLine)
		.Select(ParsePosition)
		.ToArray();

	private static Position ParsePosition(string line)
	{
		var split = line.Split(',');
		return (
			x: int.Parse(split[0]),
			y: int.Parse(split[1]),
			z: int.Parse(split[2])
		);
	}

	public static double LengthSquared(Connection connection)
	{
		var p1 = connection.Item1;
		var p2 = connection.Item2;
		// Implementing this manually is much faster than Math.Pow(p2.x - p1.x, 2).
		double x = p2.x - p1.x;
		double y = p2.y - p1.y;
		double z = p2.z - p1.z;
		return (x * x) + (y * y) + (z * z);
	}

	public override object Part2(string input)
	{
		List<HashSet<Position>> circuits = [];

		HashSet<Position> FindCircuit(Position position)
		{
			return circuits.FirstOrDefault(circuit => circuit.Contains(position));
		}

		int positionCount = GetPositions(input).Length;

		Connection closingConnection = default;

		foreach (var connection in FindConnections(input))
		{
			var circuit1 = FindCircuit(connection.Item1);
			var circuit2 = FindCircuit(connection.Item2);

			// Merge circuits.
			if (circuit1 != null && circuit2 != null && circuit1 != circuit2)
			{
				foreach (var p in circuit2)
					circuit1.Add(p);
				circuits.Remove(circuit2);
				continue;
			}

			var circuit = circuit1 ?? circuit2;
			if (circuit != null)
			{
				// Add to existing circuit.
				circuit.Add(connection.Item1);
				circuit.Add(connection.Item2);
			}
			else
			{
				// Start new circuit.
				circuits.Add([connection.Item1, connection.Item2]);
			}

			if (circuits.Count == 1 && circuits[0].Count == positionCount)
			{
				closingConnection = connection;
				break;
			}
		}

		return (long)closingConnection.Item1.x * closingConnection.Item2.x;
	}
}