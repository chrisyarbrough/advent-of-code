using Position = (int x, int y, int z);
using Connection = ((int x, int y, int z), (int x, int y, int z));

public class Day8 : Puzzle
{
	public int MaxCount = 1000;

	public override object Part1(string input)
	{
		var connections = FindConnections(input);

		List<HashSet<Position>> circuits = [];

		HashSet<Position> FindCircuit(Position position)
		{
			return circuits.FirstOrDefault(circuit => circuit.Any(x => x == position));
		}

		foreach (var connection in connections)
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

	public Connection[] FindConnections(string input)
	{
		List<Connection> allConnections = FindAllConnections(input);
		List<Connection> shortestConnectionsInOrder = [];

		while (allConnections.Count > 0 && shortestConnectionsInOrder.Count < MaxCount)
		{
			double shortestLength = double.MaxValue;
			Connection shortestConnection = default;
			foreach (Connection connection in allConnections)
			{
				double length = Length(connection);
				if (length < shortestLength)
				{
					shortestLength = length;
					shortestConnection = connection;
				}
			}
			shortestConnectionsInOrder.Add(shortestConnection);
			allConnections.Remove(shortestConnection);
		}

		return shortestConnectionsInOrder.ToArray();
	}

	private static Position[] GetPositions(string input)
	{
		return input
			.Trim()
			.Split(Environment.NewLine)
			.Select(ParsePosition)
			.ToArray();
	}

	private List<Connection> FindAllConnections(string input)
	{
		Position[] positions = GetPositions(input);

		List<Connection> connections = [];

		for (int i = 0; i < positions.Length; i++)
		{
			var p1 = positions[i];
			for (int j = i + 1; j < positions.Length; j++)
			{
				var p2 = positions[j];
				connections.Add((p1, p2));
			}
		}

		return connections;
	}

	public static Connection FindClosestPositions(string input)
	{
		Position[] positions = GetPositions(input);

		double shortestDistance = float.MaxValue;
		Position closestA = default;
		Position closestB = default;
		for (int i = 0; i < positions.Length; i++)
		{
			var p1 = positions[i];
			for (int j = i + 1; j < positions.Length; j++)
			{
				var p2 = positions[j];
				double distance = DistanceBetween(p1, p2);
				if (distance < shortestDistance)
				{
					shortestDistance = distance;
					closestA = p1;
					closestB = p2;
				}
			}
		}
		return (closestA, closestB);
	}

	public static double Length(Connection connection)
		=> DistanceBetween(connection.Item1, connection.Item2);

	public static double DistanceBetween(Position p1, Position p2)
	{
		return Math.Sqrt(
			Math.Pow(p2.x - p1.x, 2) +
			Math.Pow(p2.y - p1.y, 2) +
			Math.Pow(p2.z - p1.z, 2)
		);
	}

	public override object Part2(string input)
	{
		return "";
	}

	private static Position ParsePosition(string line)
	{
		var split = line.Split(',');
		return (int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
	}
}