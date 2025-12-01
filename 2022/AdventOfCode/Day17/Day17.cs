using Day14Namespace;

namespace AdventOfCode.Day17;

public class Day17 : Puzzle
{
	public Day17(IInput input) : base(input)
	{
	}

	public override object SolutionPart1()
	{
		throw new NotImplementedException();
	}

	public override object SolutionPart2()
	{
		throw new NotImplementedException();
	}
}

public struct Rock
{
	// The rock pivot should be in the bottom left corner to
	// make it easy to define the spawn position within the chamber.
	public Coord Coord;
	public string Visuals;

	public Rock(string input)
	{
		this.Visuals = input;
		foreach (string line in input.Split("\n"))
		{
			foreach (char c in line)
			{
				if (c == '#')
				{
					
				}
			}
		}
	}


	public bool Overlaps(Rock other)
	{
		return false;
	}
}

public class Chamber
{
	public const int Width = 7;
	public int Height => rows.Count - 1;

	private RockSpawner rockSpawner;
	private JetPattern jetPattern;

	private readonly List<string> rows = new();
	private List<Rock> rocks = new List<Rock>();

	private Rock activeRock;
	private int highestY = 1;

	public Chamber(RockSpawner rockSpawner, JetPattern jetPattern)
	{
		this.rockSpawner = rockSpawner;
		this.jetPattern = jetPattern;
		CreateFloor();
	}

	private void CreateFloor()
	{
		this.rows.Add($"+{new string('-', Width - 2)}+");
	}

	public void StepSimulation()
	{
		// if (activeRock == null)
		// {
		// 	activeRock = rockSpawner.Next();
		// 	this.rocks.Add(activeRock);
		// 	activeRock.Coord = new Coord(2, highestY + 3);
		// }

		Draw();
		ApplyJetMove();
		Draw();
		ApplyGravity();
	}

	private void ApplyJetMove()
	{
		int move = jetPattern.Next();
		Coord targetCoord = activeRock.Coord + new Coord(move, 0);

		// Ignore movement if it would move into the walls.
		if (targetCoord.x < 0 || targetCoord.x > 6)
			return;

		// Ignore movement if it would collide with existing rocks.
		if (CollidesWithExistingRocks(targetCoord))
			return;

		activeRock.Coord = targetCoord;
	}

	private void ApplyGravity()
	{
		Coord targetCoord = activeRock.Coord + new Coord(0, -1);

		// Floor or other rocks.
		if (targetCoord.y < 0 || CollidesWithExistingRocks(targetCoord))
		{
			//activeRock = null;
			return;
		}

		activeRock.Coord = targetCoord;
	}

	private bool CollidesWithExistingRocks(Coord targetCoord)
	{
		return false;
	}

	private void Draw()
	{
		throw new NotImplementedException();
	}
}