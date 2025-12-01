public class Day1Tests
{
	[Fact]
	public void Part1_Example()
	{
		var safe = new Day1.Safe1(50);

		string[] instructions =
		[
			"L68",
			"L30",
			"R48",
			"L5 ",
			"R60",
			"L55",
			"L1 ",
			"L99",
			"R14",
			"L82",
		];

		foreach (string instruction in instructions)
			safe.Rotate(instruction);

		Assert.Equal(3, safe.Password);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = new Day1().Solve(p => p.Part1);
		Assert.Equal(1139, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		var safe = new Day1.Safe2(50);

		string[] instructions =
		[
			"L68",
			"L30",
			"R48",
			"L5 ",
			"R60",
			"L55",
			"L1 ",
			"L99",
			"R14",
			"L82",
		];

		foreach (string instruction in instructions)
			safe.Rotate(instruction);

		Assert.Equal(6, safe.Password);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = new Day1().Solve(p => p.Part2);
		Assert.Equal(6684, solution);
	}

	[Fact]
	public void SimpleRotationInPositiveRealm()
	{
		var safe = new Day1.Safe1(11);
		var result = safe.Rotate("R8");
		Assert.Equal(19, result);

		result = safe.Rotate("L19");
		Assert.Equal(0, result);
	}

	[Fact]
	public void RotationAcrossZeroBoundary()
	{
		var safe = new Day1.Safe1(5);
		var result = safe.Rotate("L10");
		Assert.Equal(95, result);

		result = safe.Rotate("R5");
		Assert.Equal(0, result);
	}

	[Fact]
	public void RotateNumberCheck()
	{
		int result = Day1.Safe1.Rotate(5, 3);
		Assert.Equal(8, result);

		result = Day1.Safe1.Rotate(0, -3);
		Assert.Equal(97, result);

		result = Day1.Safe1.Rotate(5, -10);
		Assert.Equal(95, result);
	}
}