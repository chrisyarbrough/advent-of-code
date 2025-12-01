public class InputText : IInput
{
	private readonly string text;

	public InputText(string text)
	{
		this.text = text;
	}

	public string Text() => text;

	public string[] Lines() => text.Split("\n");

	public IEnumerable<string> EnumerateLines() => Lines();
}