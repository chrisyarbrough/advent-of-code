using System.Text;

namespace AdventOfCode.Day15;

public class ConsoleBuffer
{
	private (int Left, int Top)? cursorStart;
	private StringBuilder stringBuilder = new();

	public void Init()
	{
		if (cursorStart.HasValue == false)
			cursorStart = Console.GetCursorPosition();
	}

	public void Write(string s)
	{
		stringBuilder.Append(s);
	}

	public void Write(char c)
	{
		stringBuilder.Append(c);
	}

	public void WriteLine()
	{
		stringBuilder.AppendLine();
	}

	public void Flush()
	{
		if (cursorStart == null)
			throw new InvalidOperationException("Must call Init before Flush.");

		Console.SetCursorPosition(
			cursorStart.Value.Left,
			cursorStart.Value.Top);

		Console.WriteLine(stringBuilder.ToString());
		stringBuilder.Clear();
	}
}