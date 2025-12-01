using System.Text.RegularExpressions;

namespace AdventOfCode.Day16;

public class Valve
{
	/// <summary>
	/// The name of the valve encoded as two uppercase letters, e.g. "AA".
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// The amount of pressure per minute this valve releases.
	/// </summary>
	public readonly int FlowRate;

	/// <summary>
	/// The number of tunnels this valve is connected to.
	/// </summary>
	public readonly int ConnectionCount;

	/// <summary>
	/// Returns the valve name the tunnel at index leads to.
	/// </summary>
	/// <param name="index">[0..<see cref="ConnectionCount"/>]</param>
	public string ConnectionAt(int index) => connections[index];

	public IEnumerable<string> Connections => connections;

	private readonly string[] connections;

	public Valve(string name, int flowRate, string[] connections)
	{
		this.Name = name;
		this.FlowRate = flowRate;
		this.ConnectionCount = connections.Length;
		this.connections = connections;
	}

	public static Valve Parse(string inputLine)
	{
		Match match = Regex.Match(inputLine, pattern: @"Valve ([A-Z]{2}).+rate=(\d+).+valves? (.+)");
		GroupCollection groups = match.Groups;
		return new Valve(
			name: groups[1].Value,
			flowRate: int.Parse(groups[2].Value),
			connections: groups[3].Value.Split(", ")
		);
	}
}