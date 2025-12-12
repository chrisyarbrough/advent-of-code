public class Day11 : Puzzle
{
	// Devices and their output connections.
	private readonly Dictionary<string, IEnumerable<string>> graph = [];

	public override object Part1(string input)
	{
		foreach (string line in input.Trim().Split("\n"))
		{
			var split = line.Split(":");
			string deviceName = split[0];
			string[] connections = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
			graph.Add(deviceName, connections);
		}

		HashSet<string> visited = [];
		List<string> path = [];
		List<List<string>> allPaths = [];
		FindAllPaths_Recursive(current: "you", target: "out", visited, path, allPaths);

		return allPaths.Count;
	}

	// Depth-First-Search with back-tracking.
	private void FindAllPaths_Recursive(
		string current,
		string target,
		HashSet<string> visited,
		List<string> path,
		List<List<string>> allPaths)
	{
		path.Add(current);
		visited.Add(current);

		if (current == target)
		{
			allPaths.Add(path.ToList());
		}
		else
		{
			foreach (string connection in graph[current])
			{
				if (!visited.Contains(connection))
					FindAllPaths_Recursive(connection, target, visited, path, allPaths);
			}
		}

		visited.Remove(current);
		path.Remove(current);
	}

	public override object Part2(string input)
	{
		return "";
	}
}