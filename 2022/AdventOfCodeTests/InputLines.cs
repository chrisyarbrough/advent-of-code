public class InputLines : IInput
{
	private readonly string[] lines;

	public InputLines(string[] lines)
	{
		this.lines = lines;
	}

	public string Text() => string.Join("\n", lines);

	public string[] Lines() => lines;

	public IEnumerable<string> EnumerateLines() => lines;
}