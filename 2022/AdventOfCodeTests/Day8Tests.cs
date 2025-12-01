public class Day8Tests : PuzzleTest<Day8>
{
	[Fact]
	public void Part1_Example()
	{
		string[] input =
		{
			"30373",
			"25512",
			"65332",
			"33549",
			"35390"
		};

		// Tree size:
		// 0 shortest
		// 9 tallest

		// Tree is visible if all trees between it and the edge are shorter.
		// E.g.: top-left tree number 5 is visible
		// 16 on the edge + 5 trees are visible in the interior

		Day8 puzzle = CreateFromLines(input);
		var visibleTreeCount = puzzle.SolutionPart1();
		Assert.Equal(21, visibleTreeCount);
	}

	[Fact]
	public void Part1_Input()
	{
		Day8 puzzle = CreateFromFile("Input");
		var visibleTreeCount = puzzle.SolutionPart1();
		Assert.Equal(1695, visibleTreeCount);
	}

	[Fact]
	public void Part2_Example()
	{
		string[] input =
		{
			"30373",
			"25512",
			"65332",
			"33549",
			"35390"
		};

		Day8 puzzle = CreateFromLines(input);
		var highestScenicScore = puzzle.SolutionPart2();
		Assert.Equal(8, highestScenicScore);
	}

	[Fact]
	public void Part2_Input()
	{
		Day8 puzzle = CreateFromFile("Input");
		var highestScenicScore = puzzle.SolutionPart2();
		Assert.Equal(287040, highestScenicScore);
	}

	[Fact]
	public void TreeMapTests()
	{
		string[] input =
		{
			"123",
			"456",
			"789",
		};
		var treeMap = new Day8.TreeMap(input);

		Assert.Equal(9, treeMap.AllCoords().Count());

		Assert.Equal(1, treeMap.TreeHeight(y: 0, x: 0));
		Assert.Equal(3, treeMap.TreeHeight(y: 0, x: 2));
		Assert.Equal(5, treeMap.TreeHeight(y: 1, x: 1));
		Assert.Equal(7, treeMap.TreeHeight(y: 2, x: 0));
		Assert.Equal(9, treeMap.TreeHeight(y: 2, x: 2));

		// Assert.Equal(new int[] { 1, 2, 3 }, treeMap.GetRow(y: 0, xStart: 0, xEnd: 2));
		// Assert.Equal(new int[] { 4, 5, 6 }, treeMap.GetRow(y: 1, xStart: 0, xEnd: 2));
		// Assert.Equal(new int[] { 7, 8, 9 }, treeMap.GetRow(y: 2, xStart: 0, xEnd: 2));
		//
		// Assert.Equal(new int[] { 1, 2 }, treeMap.GetRow(y: 0, xStart: 0, xEnd: 1));
		// Assert.Equal(new int[] { 1 }, treeMap.GetRow(y: 0, xStart: 0, xEnd: 0));
		//
		// Assert.Equal(new int[] { 2, 3 }, treeMap.GetRow(y: 0, xStart: 1, xEnd: 2));
		// Assert.Equal(new int[] { 3 }, treeMap.GetRow(y: 0, xStart: 2, xEnd: 2));
	}

	[Fact]
	public void TreeMapReversedTests()
	{
		string[] input =
		{
			"123",
			"456",
			"789",
		};
		var treeMap = new Day8.TreeMap(input);
		// Assert.Equal(new int[] { 1, 2, 3 }, treeMap.GetRow(y: 0, xStart: 0, xEnd: 2));
		// Assert.Equal(new int[] { 3, 2, 1 }, treeMap.GetRow(y: 0, xStart: 2, xEnd: 0));
		//
		// Assert.Equal(new int[] { 2, 5, 8 }, treeMap.GetColumn(x: 1, yStart: 0, yEnd: 2));
		// Assert.Equal(new int[] { 8, 5, 2 }, treeMap.GetColumn(x: 1, yStart: 2, yEnd: 0));
	}

	[Fact]
	public void ViewingDistance()
	{
		// Up
		Assert.Equal(1, Day8.ViewDistance(new[] { 3 }, 5));

		// Left
		Assert.Equal(1, Day8.ViewDistance(new[] { 5, 2 }, 5));

		// Right
		Assert.Equal(2, Day8.ViewDistance(new[] { 1, 2 }, 5));

		// Down
		Assert.Equal(2, Day8.ViewDistance(new[] { 3, 5, 3 }, 5));

		// Edge
		Assert.Equal(0, Day8.ViewDistance(new int[0], 5));
	}
}