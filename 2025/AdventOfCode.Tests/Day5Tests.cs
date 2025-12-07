public class Day5Tests
{
	private readonly Puzzle puzzle = new Day5();

	// Fresh ingredient ID ranges, followed by available ingredient IDs.
	private const string input = """
	                             3-5
	                             10-14
	                             16-20
	                             12-18

	                             1
	                             5
	                             8
	                             11
	                             17
	                             32
	                             """;

	// Known:
	// - Ranges can overlap.
	// - Ranges can be identical.
	// - Ranges can be within other ranges.
	// - When ranges are sorted, the next range start is never lower than the previous start.

	// Range   Size
	// 3-5      3
	// 10-14    5
	// 12-18    7
	// 16-20    5

	//   ###
	//         #####
	//           #######
	//               #####

	// Extend ranges?
	// ########
	// ########
	//         ######...->...#.->..#
	//            ############
	//                 ### (skip)
	//                     #########
	// [      ][  [   [  ][  ]     ]
	// [      ][                   ]

	[Fact]
	public void Part1_Example()
	{
		// How many ingredients are fresh?
		var result = puzzle.Part1(input);
		Assert.Equal(3, result);
	}

	[Fact]
	public void Part1_Solution()
	{
		var solution = puzzle.Solve(p => p.Part1);
		Assert.Equal(577, solution);
	}

	[Fact]
	public void Part2_Example()
	{
		// How many unique fresh ingredient IDs?
		var result = puzzle.Part2(input);
		Assert.Equal(14L, result);
	}

	[Theory]
	[InlineData("""
	            1-10
	            1-10
	            """, 10L, "Same range counted once.")]
	[InlineData("11-11", 1L, " Range of same number is one id.")]
	[InlineData("""
	            1-10
	            5-8
	            """, 10L, "Fully contained range is ignored.")]
	[InlineData("""
	            1-10
	            5-15
	            """, 15L, "Overlap is merged.")]
	public void Part2_SameRange_CountedOnce(string input, long expected, string message)
	{
		var result = (long)puzzle.Part2(input);
		Assert.True(expected == result, message);
	}

	[Fact]
	public void Part2_Solution()
	{
		var solution = puzzle.Solve(p => p.Part2);
		Assert.Equal(350513176552950L, solution);

		// Failed attempts:
		Assert.NotEqual(318828221839831L, solution); // too low
		Assert.NotEqual(340433326438215L, solution); // wrong
		Assert.NotEqual(351151917905230L, solution); // wrong
		Assert.NotEqual(3188282218398311L, solution); // too high
	}
}