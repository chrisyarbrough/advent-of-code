using Position = (int x, int y, int z);

public class Day8Tests
{
	private const string input = """
	                             162,817,812
	                             57,618,57
	                             906,360,560
	                             592,479,940
	                             352,342,300
	                             466,668,158
	                             542,29,236
	                             431,825,988
	                             739,650,466
	                             52,470,668
	                             216,146,977
	                             819,987,18
	                             117,168,530
	                             805,96,715
	                             346,949,466
	                             970,615,88
	                             941,993,340
	                             862,61,35
	                             984,92,344
	                             425,690,689
	                             """;

	private readonly Day8 puzzle = new Day8();

	[Fact]
	public void Part1_Example()
	{
		puzzle.MaxCount = 10;
		var result = puzzle.Part1(input);
		Assert.Equal(40, result);
	}

	[Theory]
	[InlineData(4,
		4, 0, 0,
		6, 0, 0)]
	[InlineData(4,
		4, 0, 0,
		2, 0, 0)]
	[InlineData(36,
		-4, 0, 0,
		+2, 0, 0)]
	public void Part1_LengthSquared(double expected, int x1, int y1, int z1, int x2, int y2, int z2)
	{
		var p1 = (x: x1, y: y1, z: z1);
		var p2 = (x: x2, y: y2, z: z2);

		double distance = Day8.LengthSquared((p1, p2));
		Assert.Equal(expected, distance);

		distance = Day8.LengthSquared((p2, p1));
		Assert.Equal(expected, distance);
	}

	[Fact]
	public void Part1_StreamClosestOneByOne()
	{
		// Should return a stream of pairs, starting with the closest pair, then the next closest etc.
		(Position, Position)[] pairs =
		[
			((162, 817, 812), (425, 690, 689)),
			((162, 817, 812), (431, 825, 988)),
			((906, 360, 560), (805, 96, 715)),
			((431, 825, 988), (425, 690, 689)),
		];

		Assert.Equal(pairs, puzzle.FindConnections(input).Take(4));
	}

	[Fact]
	public void Part1_Solution()
	{
		puzzle.MaxCount = 1000;
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(102816, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		var result = puzzle.Part2(input);
		Assert.Equal("XMAS", result);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(0, solution);
	}
}