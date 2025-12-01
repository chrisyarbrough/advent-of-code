public class InputFile : IInput
{
	private readonly string fileName;

	public InputFile(string fileName)
	{
		this.fileName = fileName;
	}

	public string Text() => File.ReadAllText(fileName);

	public string[] Lines() => File.ReadAllLines(fileName);

	public IEnumerable<string> EnumerateLines()
	{
		using FileStream stream = File.OpenRead(fileName);
		using var reader = new StreamReader(stream);

		while (reader.ReadLine() is { } line)
			yield return line;
	}
}