public class Day11 : Puzzle
{
	// Devices and their output connections.
	private readonly Dictionary<string, IEnumerable<string>> graph = [];

	public override object Part1(string input)
	{
		graph.Clear();
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
		else if(current != "out")
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
		graph.Clear();
		foreach (string line in input.Trim().Split("\n"))
		{
			var split = line.Split(":");
			string deviceName = split[0];
			string[] connections = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
			graph.Add(deviceName, connections);
		}

		// With the more complex part 2 graph, it's no longer feasible to find all paths,
		// just to throw away most of those calculations to find the ones that also visit the two special nodes.
		// If we just wanted a single path, we could simply try:
		// svr -> dac -> fft -> out
		// svr -> fft -> dac -> out
		// But we need all paths, so we might try to find all paths for each sub-path:
		// svr -> dac
		// dac -> fft
		// fft -> out
		//
		// svr -> fft
		// fft -> dac
		// dac -> out
		// From all the sub-paths, we can reconstruct all paths that contain both nodes?
		HashSet<string> visited = [];
		List<string> path = [];
		List<List<string>> allPaths = [];
		FindAllPaths_Recursive(current: "svr", target: "dac", visited, path, allPaths);
		// Problem: still very slow to find svr -> dac

		return allPaths.Count(p => p.Contains("dac") && p.Contains("fft"));
	}
}