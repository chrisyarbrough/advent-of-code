public abstract class Puzzle
{
	protected readonly IInput input;

	protected IEnumerable<string> inputLines => input.EnumerateLines();

	protected Puzzle(IInput input)
	{
		this.input = input ?? throw new ArgumentNullException(nameof(input));
	}

	public abstract object SolutionPart1();

	public abstract object SolutionPart2();
}