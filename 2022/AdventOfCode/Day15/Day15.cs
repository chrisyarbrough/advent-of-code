namespace AdventOfCode.Day15;

using System.Text.RegularExpressions;
using Day14Namespace;

public class Day15 : Puzzle
{
	public Day15(IInput input) : base(input)
	{
	}

	public int QueriedRow = 2_000_000;

	protected Dictionary<Coord, char> map = new();

	public override object SolutionPart1()
	{
		foreach (var pair in ParseInput())
		{
			map[pair.sensor] = 'S';
			map[pair.beacon] = 'B';
		}

		Console.WriteLine("Map parsed. Size: " + map.Count());

		int xMin = map.Select(s => s.Key.x).Min();
		int xMax = map.Select(s => s.Key.x).Max();
		int yMin = map.Select(s => s.Key.y).Min();
		int yMax = map.Select(s => s.Key.y).Max();

		Console.WriteLine("MinMax evaluated.");

		foreach (var pair in ParseInput())
		{
			Console.WriteLine(pair.sensor + " " + pair.beacon);

			int referenceDistance = ManhattenDistance(pair.sensor, pair.beacon);

			//for (int y = yMin; y < yMax; y++)
			int y = QueriedRow;
			{
				for (int x = xMin - 100_000_00; x < xMax + 100_000_000; x++)
				{
					Coord coord = new Coord(x, y);
					int distance = ManhattenDistance(coord, pair.sensor);

					if (distance <= referenceDistance &&
					    map.ContainsKey(coord) == false)
					{
						map[coord] = '#';
					}
				}
			}
		}

		DrawMap();

		return map.Where(kvp => kvp.Key.y == QueriedRow && kvp.Value != 'B').Count();
	}

	protected virtual void DrawMap()
	{
	}

	// Maximum possible rect.
	public Rect StartingRect = new Rect(0, 0, 4000000, 4000000);

	public override object SolutionPart2()
	{
		Coord result = FindUncoveredPosition(ParseInput(), StartingRect)!.Value;
		return TuningFrequency(result);
	}

	private void FillMap()
	{
		foreach ((Coord sensor, Coord beacon) pair in ParseInput())
		{
			map[pair.sensor] = 'S';
			map[pair.beacon] = 'B';
		}
	}

	private Coord? FindUncoveredPosition(IEnumerable<(Coord sensor, Coord beacon)> pairs, Rect rect)
	{
		// Rects are all covered until here.
		if (rect.width == 0 || rect.height == 0)
			return null;

		foreach (var pair in pairs)
		{
			// If rect fits within covered diamond area, we know the beacon is not here and can stop.
			if (rect.Corners.All(c => InRange(pair, c)))
				return null;
		}

		// Found the single coord that is uncovered.
		if (rect.width == 1 && rect.height == 1)
		{
			return new Coord(rect.x, rect.y);
		}


		// Continue searching in smaller sub-rects.
		foreach (Rect subRect in rect.Split())
		{
			Coord? found = FindUncoveredPosition(pairs, subRect);
			if (found.HasValue)
				return found;
		}

		return null;
	}

	private bool InRange((Coord, Coord) pair, Coord point)
	{
		int distance = ManhattenDistance(pair.Item1, pair.Item2);
		return ManhattenDistance(pair.Item1, point) <= distance;
	}

	public IEnumerable<(Coord sensor, Coord beacon)> ParseInput()
	{
		foreach (string line in inputLines)
		{
			var matches = Regex.Matches(line, @"-?\d+")
				.Select(x => int.Parse(x.Value)).ToArray();

			var sensor = new Coord(x: matches[0], y: matches[1]);
			var beacon = new Coord(x: matches[2], y: matches[3]);

			yield return (sensor, beacon);
		}
	}

	public static int ManhattenDistance(Coord a, Coord b)
	{
		return Math.Abs(b.x - a.x) + Math.Abs(a.y - b.y);
	}

	public static long TuningFrequency(Coord beacon)
	{
		return beacon.x * 4_000_000L + beacon.y;
	}
}