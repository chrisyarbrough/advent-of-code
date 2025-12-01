using AdventOfCode.Day17;

namespace AdventOfCodeTests;

public class Day17Tests : PuzzleTest<Day17>
{
	[Fact]
	public void RockSpawner_SpawnsFirstElement()
	{
		var input = new InputFile("Day17/Rocks.txt");
		var spawner = new RockSpawner(input.Text());
		Assert.Equal("####", spawner.Next().Visuals);
	}

	[Fact]
	public void RockSpawner_RepeatsElements()
	{
		var input = new InputFile("Day17/Rocks.txt");
		var spawner = new RockSpawner(input.Text());

		// Spawn each rock in the input.
		for (int i = 0; i < 5; i++)
			spawner.Next();

		// The spawner should loop back to the first.
		Assert.Equal("####", spawner.Next().Visuals);
	}

	[Fact]
	public void JetPatterns_ReturnsCorrectInstructions()
	{
		var input = new InputFile("Day17/Example.txt");
		var pattern = new JetPattern(input.Text());
		Assert.Equal(1, pattern.Next());
		Assert.Equal(1, pattern.Next());
		Assert.Equal(1, pattern.Next());
		Assert.Equal(-1, pattern.Next());
	}

	[Fact]
	public void JetPattern_RepeatsElements()
	{
		var input = new InputFile("Day17/Example.txt");
		var pattern = new JetPattern(input.Text());

		// Spawn each rock in the input.
		for (int i = 0; i < input.Text().Length; i++)
			pattern.Next();

		// The pattern should loop back to the first.
		Assert.Equal(1, pattern.Next());
		Assert.Equal(1, pattern.Next());
		Assert.Equal(1, pattern.Next());
		Assert.Equal(-1, pattern.Next());
	}
}