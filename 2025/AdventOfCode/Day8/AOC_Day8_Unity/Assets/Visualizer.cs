using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

class Visualizer : MonoBehaviour
{
	private List<(Vector3, Vector3)> connections = new();

	private void Start()
	{
		const string path = "../connections.txt";
		string[] lines = System.IO.File.ReadAllLines(path);
		foreach (string line in lines)
		{
			string[] parts = line.Split("->");
			Vector3 p1 = ParseToVector(parts[0]);
			Vector3 p2 = ParseToVector(parts[1]);
			connections.Add((p1, p2));
		}
	}

	private Vector3 ParseToVector(string input)
	{
		// Input like: (162, 817, 812)
		var match = Regex.Match(input, pattern: @"\((\d+), (\d+), (\d+)\)");
		return new Vector3(
			int.Parse(match.Groups[1].Value),
			int.Parse(match.Groups[2].Value),
			int.Parse(match.Groups[3].Value)
		);
	}

	private void OnDrawGizmos()
	{
		foreach (var (p1, p2) in connections)
		{
			const float size = 5f;
			Gizmos.DrawSphere(p1, size);
			Gizmos.DrawSphere(p2, size);
			Gizmos.DrawLine(p1, p2);
		}
	}
}