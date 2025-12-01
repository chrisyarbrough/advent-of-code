public class Day5_RefactorTests
{
	private Day5_Refactor day5 = new();
	private string example => Day5Tests.example;

	[Fact]
	public void Part1_Example()
	{
		Assert.Equal(143, day5.Part1(example));
	}

	[Fact]
	public void Part1_Solution()
	{
		Assert.Equal(5713, day5.Solve(p => p.Part1));
	}

	[Fact]
	public void Part2_Example()
	{
		Assert.Equal(123, day5.Part2(example));
	}

	[Fact]
	public void Part2_Solution()
	{
		Assert.Equal(5180, day5.Solve(p => p.Part2));
	}
}