using JetBrains.Annotations;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public abstract class Puzzle
{
	public string InputFileName { get; set; } = "Input.txt";

	/// <summary>
	/// Uses the file Input.txt next to the script.
	/// </summary>
	public object Solve(Func<Puzzle, Func<string, object>> function)
	{
		string input = File.ReadAllText($"{GetType().Name}/{InputFileName}");
		object result;
		try
		{
			Console.CancelKeyPress += CancelKeyPressHandler;
			Console.CursorVisible = false;
			result = function(this).Invoke(input);
		}
		finally
		{
			Console.CursorVisible = true;
		}

		return result;
	}

	private void CancelKeyPressHandler(object sender, ConsoleCancelEventArgs e)
	{
		Console.CursorVisible = true;
	}

	public abstract object Part1(string input);
	public abstract object Part2(string input);
}