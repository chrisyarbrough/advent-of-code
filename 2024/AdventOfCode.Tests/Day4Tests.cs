public class Day4Tests
{
	[Fact]
	public void Part1_Example()
	{
		// ReSharper disable once StringLiteralTypo
		const string example = """
		                       MMMSXXMASM
		                       MSAMXMSMSA
		                       AMXSXMAAMM
		                       MSAMASMSMX
		                       XMASAMXAMM
		                       XXAMMXXAMA
		                       SMSMSASXSS
		                       SAXAMASAAA
		                       MAMMMXMMMM
		                       MXMXAXMASX
		                       """;

		// ....XXMAS.
		// .SAMXMS...
		// ...S..A...
		// ..A.A.MS.X
		// XMASAMX.MM
		// X.....XA.A
		// S.S.S.S.SS
		// .A.A.A.A.A
		// ..M.M.M.MM
		// .X.X.XMASX

		// Horizontal: 3
		// HorizontalR: 2
		// Vertical: 1
		// VerticalR: 2
		// d1: 1
		// d2: 1
		// d3: 4
		// d4: 4

		Day4 puzzle = new();
		object result = puzzle.Part1(example);
		Assert.Equal(18, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		Day4 puzzle = new();
		object result = puzzle.Solve(p => p.Part1);
		Assert.Equal(2397, result);
	}

	[Fact]
	public void Part2_Example()
	{
		const string example = """
		                       MMMSXXMASM
		                       MSAMXMSMSA
		                       AMXSXMAAMM
		                       MSAMASMSMX
		                       XMASAMXAMM
		                       XXAMMXXAMA
		                       SMSMSASXSS
		                       SAXAMASAAA
		                       MAMMMXMMMM
		                       MXMXAXMASX
		                       """;

		/*
.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........
		 */

		Day4 puzzle = new();
		object result = puzzle.Part2(example);
		Assert.Equal(9, result);
	}

	[Fact]
	public void Part2_Solution()
	{
		Day4 puzzle = new();
		object result = puzzle.Solve(p => p.Part2);
		Assert.Equal(1824, result);
	}
}