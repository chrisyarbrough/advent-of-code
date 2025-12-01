namespace AdventOfCode.Day16;

public class Day16 : Puzzle
{
	public Day16(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		Dictionary<string, Valve> valvesByName = ParseInput()
			.ToDictionary(v => v.Name);

		Valve start = valvesByName[ParseInput().First().Name];

		var frontier = new Queue<Valve>();
		frontier.Enqueue(start);

		var visited = new HashSet<Valve>();
		visited.Add(start);

		while (frontier.Count > 0)
		{
			Valve current = frontier.Dequeue();
			foreach (string connection in current.Connections)
			{
				Valve other = valvesByName[connection];
				if (visited.Contains(other) == false)
				{
					frontier.Enqueue(other);
					visited.Add(other);
				}
			}
		}

		throw new NotImplementedException();
	}

	public override object SolutionPart2()
	{
		throw new NotImplementedException();
	}

	public IEnumerable<Valve> ParseInput()
	{
		foreach (string line in inputLines)
			yield return Valve.Parse(line);
	}
}