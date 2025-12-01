public class Day7Tests : PuzzleTest<Day7>
{
	[Fact]
	public void Part1_Example()
	{
/* Visual representation of the example input:
- / (dir)
- a (dir)
  - e (dir)
    - i (file, size=584)
  - f (file, size=29116)
  - g (file, size=2557)
  - h.lst (file, size=62596)
- b.txt (file, size=14848514)
- c.dat (file, size=8504156)
- d (dir)
  - j (file, size=4060174)
  - d.log (file, size=8033020)
  - d.ext (file, size=5626152)
  - k (file, size=7214296)
*/
		Day7 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1();
		Assert.Equal(95437L, result);
	}

	[Fact]
	public void Part1_B_Example()
	{
		Day7 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart1_B();
		Assert.Equal(95437L, result);
	}

	[Fact]
	public void Part1_Input()
	{
		Day7 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart1();
		Assert.Equal(1367870L, result);
	}

	[Fact]
	public void Part2_Example()
	{
		Day7 puzzle = CreateFromFile("Example");
		var result = puzzle.SolutionPart2();
		Assert.Equal(24933642L, result);
	}

	[Fact]
	public void Part2_Input()
	{
		Day7 puzzle = CreateFromFile("Input");
		var result = puzzle.SolutionPart2();
		Assert.Equal(549173L, result);
	}
}